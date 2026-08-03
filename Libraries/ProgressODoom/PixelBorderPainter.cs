using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Collections.Generic;

namespace ProgressODoom {
	/// <summary>
	/// 8-bit (NES/SNES era) pixel-art border painter. Renders a chunky 2px-thick
	/// beveled border with "staircase" corners (the classic NES UI frame look).
	/// The outer border is white, the inner shadow (bottom + right) is gray,
	/// giving the "raised pixel button" appearance.
	/// </summary>
	[ToolboxBitmapAttribute(typeof(ProgressODoom.PixelBorderPainter), "Icons.PixelBorderPainter.ico")]
	public class PixelBorderPainter : Component, IProgressBorderPainter, IDisposable {
		// NES palette for the border.
		private static readonly Color NesWhite = Color.FromArgb(0xFC, 0xFC, 0xFC);
		private static readonly Color NesGray  = Color.FromArgb(0x7C, 0x7C, 0x7C);
		private static readonly Color NesDark  = Color.FromArgb(0x44, 0x44, 0x44);
		private static readonly Color NesBlack = Color.FromArgb(0x0C, 0x0C, 0x0C);

		private Color color = NesWhite;
		private Color shadowColor = NesGray;
		private Color darkColor = NesDark;
		private Color innerColor = NesBlack;
		private int borderWidth = 2;

		// Cached pens — allocated in property setters, disposed in Dispose().
		private Pen outerPen;
		private Pen shadowPen;
		private Pen darkPen;
		private Pen innerPen;

		private EventHandler onPropertiesChanged;
		/// <summary></summary>
		public event EventHandler PropertiesChanged {
			add {
				if (onPropertiesChanged != null) {
					foreach (Delegate d in onPropertiesChanged.GetInvocationList()) {
						if (object.ReferenceEquals(d, value)) { return; }
					}
				}
				onPropertiesChanged = (EventHandler)Delegate.Combine(onPropertiesChanged, value);
			}
			remove { onPropertiesChanged = (EventHandler)Delegate.Remove(onPropertiesChanged, value); }
		}

		private void FireChange() {
			if (onPropertiesChanged != null) { onPropertiesChanged(this, EventArgs.Empty); }
		}

		/// <summary></summary>
		public PixelBorderPainter() {
			InitializePens();
		}

		/// <summary></summary>
		/// <param name="color"></param>
		public PixelBorderPainter(Color color) {
			this.Color = color;
		}

		private void InitializePens() {
			outerPen = new Pen(color, 1f);
			shadowPen = new Pen(shadowColor, 1f);
			darkPen = new Pen(darkColor, 1f);
			innerPen = new Pen(innerColor, 1f);
		}

		/// <summary>Outer border color (default: NES white).</summary>
		[Category("Appearance"), Description("Outer border color"), Browsable(true)]
		public Color Color {
			get { return color; }
			set {
				color = value;
				outerPen?.Dispose();
				outerPen = new Pen(color, 1f);
				FireChange();
			}
		}

		/// <summary>Inner shadow color (bottom + right inner edge).</summary>
		[Category("Appearance"), Description("Inner shadow color"), Browsable(true)]
		public Color ShadowColor {
			get { return shadowColor; }
			set {
				shadowColor = value;
				shadowPen?.Dispose();
				shadowPen = new Pen(shadowColor, 1f);
				FireChange();
			}
		}

		/// <summary>Dark accent color (used for the corner pixels).</summary>
		[Category("Appearance"), Description("Dark accent color for corners"), Browsable(true)]
		public Color DarkColor {
			get { return darkColor; }
			set {
				darkColor = value;
				darkPen?.Dispose();
				darkPen = new Pen(darkColor, 1f);
				FireChange();
			}
		}

		/// <summary>Innermost color (the "hole" inside the frame).</summary>
		[Category("Appearance"), Description("Innermost border color"), Browsable(true)]
		public Color InnerColor {
			get { return innerColor; }
			set {
				innerColor = value;
				innerPen?.Dispose();
				innerPen = new Pen(innerColor, 1f);
				FireChange();
			}
		}

		/// <summary>Border thickness in pixels (default 2). 1 = thin, 2 = chunky NES, 3 = SNES.</summary>
		[Category("Appearance"), Description("Border thickness in pixels"), Browsable(true)]
		public int BorderWidth {
			get { return borderWidth; }
			set { borderWidth = Math.Max(1, Math.Min(4, value)); FireChange(); }
		}

		/// <summary></summary>
		/// <param name="box"></param>
		/// <param name="g"></param>
		public void PaintBorder(Rectangle box, Graphics g) {
			// Pixel-perfect rendering: no anti-aliasing.
			var prevSmoothing = g.SmoothingMode;
			var prevOffset = g.PixelOffsetMode;
			g.SmoothingMode = SmoothingMode.None;
			g.PixelOffsetMode = PixelOffsetMode.None;

			// The 'box' is the inner area (already inflated by 1px by AbstractProgressPainter).
			// We draw the border just inside the outer edge of 'box'.
			int x = box.X;
			int y = box.Y;
			int w = box.Width;
			int h = box.Height;

			if (borderWidth >= 1) {
				// Outer 1px white frame — but with NES "staircase" corners:
				// the corner pixels are NOT drawn, so the corners look beveled.
				// Top edge (skip first and last pixel).
				g.DrawLine(outerPen, x + 1, y, x + w - 2, y);
				// Bottom edge.
				g.DrawLine(outerPen, x + 1, y + h - 1, x + w - 2, y + h - 1);
				// Left edge (skip first and last pixel).
				g.DrawLine(outerPen, x, y + 1, x, y + h - 2);
				// Right edge.
				g.DrawLine(outerPen, x + w - 1, y + 1, x + w - 1, y + h - 2);

				// Corner pixels: dark accent.
				g.DrawRectangle(darkPen, x, y, 0, 0);                       // top-left
				g.DrawRectangle(darkPen, x + w - 1, y, 0, 0);               // top-right
				g.DrawRectangle(darkPen, x, y + h - 1, 0, 0);               // bottom-left
				g.DrawRectangle(darkPen, x + w - 1, y + h - 1, 0, 0);       // bottom-right
			}

			if (borderWidth >= 2) {
				// Inner shadow on bottom + right (gives the "raised pixel button" look).
				// Inner bottom edge (1px inside the outer bottom).
				g.DrawLine(shadowPen, x + 1, y + h - 2, x + w - 2, y + h - 2);
				// Inner right edge.
				g.DrawLine(shadowPen, x + w - 2, y + 1, x + w - 2, y + h - 2);
				// Inner top + left: lighter (use the outer color again, dimmer).
				g.DrawLine(shadowPen, x + 1, y + 1, x + w - 2, y + 1);
				g.DrawLine(shadowPen, x + 1, y + 1, x + 1, y + h - 2);
			}

			if (borderWidth >= 3) {
				// Third layer: innermost black line (the "hole" inside the frame).
				g.DrawLine(innerPen, x + 2, y + 2, x + w - 3, y + 2);
				g.DrawLine(innerPen, x + 2, y + h - 3, x + w - 3, y + h - 3);
				g.DrawLine(innerPen, x + 2, y + 2, x + 2, y + h - 3);
				g.DrawLine(innerPen, x + w - 3, y + 2, x + w - 3, y + h - 3);
			}

			g.SmoothingMode = prevSmoothing;
			g.PixelOffsetMode = prevOffset;
		}

		/// <summary></summary>
		public void Resize(Rectangle box) {
		}

		/// <summary></summary>
		protected override void Dispose(bool disposing) {
			base.Dispose(disposing);
			outerPen?.Dispose();
			shadowPen?.Dispose();
			darkPen?.Dispose();
			innerPen?.Dispose();
		}
	}
}
