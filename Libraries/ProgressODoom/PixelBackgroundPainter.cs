using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Collections.Generic;

namespace ProgressODoom {
	/// <summary>
	/// 8-bit (NES/SNES era) pixel-art background painter. Renders the "empty"
	/// portion of the progress bar with a dark base color, optional pixel-grid
	/// lines (suggesting the underlying pixel resolution), and optional CRT-style
	/// horizontal scanlines (every other row slightly darker).
	/// </summary>
	[ToolboxBitmapAttribute(typeof(ProgressODoom.PixelBackgroundPainter), "Icons.PixelBackgroundPainter.ico")]
	public class PixelBackgroundPainter : Component, IProgressBackgroundPainter, IDisposable {
		// NES dark blue/black — the "void" behind classic NES UI panels.
		private static readonly Color NesDarkBg = Color.FromArgb(0x1C, 0x1C, 0x2C);
		private static readonly Color NesGridColor = Color.FromArgb(0x2C, 0x2C, 0x3C);
		private static readonly Color NesScanlineColor = Color.FromArgb(0x10, 0x10, 0x18);

		private Color color = NesDarkBg;
		private Color gridColor = NesGridColor;
		private Color scanlineColor = NesScanlineColor;
		private int pixelSize = 8;
		private bool showGrid = true;
		private bool showScanlines = true;
		private IGlossPainter gloss;

		// Cached brushes/pens — allocated in property setters, disposed in Dispose().
		private SolidBrush bgBrush;
		private Pen gridPen;
		private Pen scanlinePen;

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
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected virtual void component_PropertiesChanged(object sender, EventArgs e) {
			FireChange();
		}

		/// <summary></summary>
		public PixelBackgroundPainter() {
			InitializeBrushes();
		}

		/// <summary></summary>
		/// <param name="color"></param>
		public PixelBackgroundPainter(Color color) {
			this.Color = color;
		}

		private void InitializeBrushes() {
			bgBrush = new SolidBrush(color);
			gridPen = new Pen(gridColor, 1f);
			scanlinePen = new Pen(scanlineColor, 1f);
		}

		/// <summary></summary>
		[Category("Painters"), Description("Gets or sets the chain of gloss painters"), Browsable(true)]
		public IGlossPainter GlossPainter {
			get { return this.gloss; }
			set {
				this.gloss = value;
				if (this.gloss != null) { this.gloss.PropertiesChanged += new EventHandler(component_PropertiesChanged); }
				FireChange();
			}
		}

		/// <summary>Base background color (default: NES dark blue/black).</summary>
		[Category("Appearance"), Description("Base background color"), Browsable(true)]
		public Color Color {
			get { return color; }
			set {
				color = value;
				bgBrush?.Dispose();
				bgBrush = new SolidBrush(color);
				FireChange();
			}
		}

		/// <summary>Color of the faint pixel grid lines.</summary>
		[Category("Appearance"), Description("Pixel grid line color"), Browsable(true)]
		public Color GridColor {
			get { return gridColor; }
			set {
				gridColor = value;
				gridPen?.Dispose();
				gridPen = new Pen(gridColor, 1f);
				FireChange();
			}
		}

		/// <summary>Color of the horizontal scanline overlay.</summary>
		[Category("Appearance"), Description("Scanline overlay color"), Browsable(true)]
		public Color ScanlineColor {
			get { return scanlineColor; }
			set {
				scanlineColor = value;
				scanlinePen?.Dispose();
				scanlinePen = new Pen(scanlineColor, 1f);
				FireChange();
			}
		}

		/// <summary>Pixel grid step size in pixels (default 8).</summary>
		[Category("Appearance"), Description("Pixel grid step in pixels"), Browsable(true)]
		public int PixelSize {
			get { return pixelSize; }
			set { pixelSize = Math.Max(2, value); FireChange(); }
		}

		/// <summary>Show the faint pixel grid (default true).</summary>
		[Category("Appearance"), Description("Show the pixel grid"), Browsable(true)]
		public bool ShowGrid {
			get { return showGrid; }
			set { showGrid = value; FireChange(); }
		}

		/// <summary>Show CRT-style horizontal scanlines (default true).</summary>
		[Category("Appearance"), Description("Show CRT scanlines"), Browsable(true)]
		public bool ShowScanlines {
			get { return showScanlines; }
			set { showScanlines = value; FireChange(); }
		}

		/// <summary></summary>
		/// <param name="box"></param>
		/// <param name="g"></param>
		public void PaintBackground(Rectangle box, Graphics g) {
			// Pixel-perfect rendering.
			var prevSmoothing = g.SmoothingMode;
			var prevOffset = g.PixelOffsetMode;
			g.SmoothingMode = SmoothingMode.None;
			g.PixelOffsetMode = PixelOffsetMode.None;

			// Fill base color.
			g.FillRectangle(bgBrush, box);

			// Draw pixel grid (vertical lines every PixelSize, horizontal lines every PixelSize).
			if (showGrid) {
				for (int x = box.X + pixelSize; x < box.Right; x += pixelSize) {
					g.DrawLine(gridPen, x, box.Y, x, box.Bottom - 1);
				}
				for (int y = box.Y + pixelSize; y < box.Bottom; y += pixelSize) {
					g.DrawLine(gridPen, box.X, y, box.Right - 1, y);
				}
			}

			// Draw CRT scanlines — every other horizontal row darker.
			if (showScanlines) {
				for (int y = box.Y + 1; y < box.Bottom; y += 2) {
					g.DrawLine(scanlinePen, box.X, y, box.Right - 1, y);
				}
			}

			g.SmoothingMode = prevSmoothing;
			g.PixelOffsetMode = prevOffset;

			if (gloss != null) {
				gloss.PaintGloss(box, g);
			}
		}

		/// <summary></summary>
		public void Resize(Rectangle box) {
		}

		/// <summary></summary>
		protected override void Dispose(bool disposing) {
			base.Dispose(disposing);
			bgBrush?.Dispose();
			gridPen?.Dispose();
			scanlinePen?.Dispose();
		}
	}
}
