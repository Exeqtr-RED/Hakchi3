using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Collections.Generic;

namespace ProgressODoom {
	/// <summary>
	/// Retro 8-bit segmented progress painter, styled after classic loading
	/// screens (Undertale / NES / demoscene). Renders the progress bar as a row
	/// of N discrete segments separated by 1px dark-blue dividers, filled with a
	/// bright cyan color. No anti-aliasing — all lines are crisp 1px, evoking the
	/// chunky pixel aesthetic of 8-bit / 16-bit console UIs.
	///
	/// Default color scheme mirrors a typical retro loading screen:
	///   - Fill:       bright cyan #00D4FF (with optional glow)
	///   - Dividers:   dark blue #003D5C (1px vertical lines between segments)
	///   - Leading edge: lighter cyan/white #E0F7FF (1px on the right of the last
	///     filled segment, gives the 'glowing edge' look)
	/// </summary>
	[ToolboxBitmapAttribute(typeof(ProgressODoom.RetroSegmentedProgressPainter), "Icons.RetroSegmentedProgressPainter.ico")]
	public class RetroSegmentedProgressPainter : AbstractProgressPainter, IProgressPainter, IDisposable {
		// Default retro palette (cyan on dark blue, like classic loading screens)
		private Color fillColor       = Color.FromArgb(0x00, 0xD4, 0xFF);
		private Color leadingColor    = Color.FromArgb(0xE0, 0xF7, 0xFF);
		private Color dividerColor    = Color.FromArgb(0x00, 0x3D, 0x5C);
		private Color glowColor       = Color.FromArgb(0x00, 0xD4, 0xFF);
		private int segmentCount      = 20;
		private int dividerWidth      = 1;
		private bool showGlow         = true;
		private bool showLeadingEdge  = true;

		// Cached brushes — allocated once, disposed in DisposeThis.
		private SolidBrush fillBrush;
		private SolidBrush leadingBrush;
		private Pen dividerPen;
		private Pen glowPen;

		/// <summary></summary>
		public RetroSegmentedProgressPainter() {
			InitializeBrushes();
		}

		private void InitializeBrushes() {
			fillBrush    = new SolidBrush(fillColor);
			leadingBrush = new SolidBrush(leadingColor);
			dividerPen   = new Pen(dividerColor, dividerWidth);
			glowPen      = new Pen(glowColor, 1f);
		}

		/// <summary>Fill color of the segments (default: bright cyan #00D4FF).</summary>
		[Category("Appearance"), Description("Fill color of the segments"), Browsable(true)]
		public Color FillColor {
			get { return fillColor; }
			set {
				fillColor = value;
				fillBrush?.Dispose();
				fillBrush = new SolidBrush(fillColor);
				glowPen?.Dispose();
				glowPen = new Pen(fillColor, 1f);
				FireChange();
			}
		}

		/// <summary>Leading edge color (1px highlight on the right of the last filled segment).</summary>
		[Category("Appearance"), Description("Leading edge color"), Browsable(true)]
		public Color LeadingColor {
			get { return leadingColor; }
			set {
				leadingColor = value;
				leadingBrush?.Dispose();
				leadingBrush = new SolidBrush(leadingColor);
				FireChange();
			}
		}

		/// <summary>Color of the 1px dividers between segments (default: dark blue #003D5C).</summary>
		[Category("Appearance"), Description("Divider color"), Browsable(true)]
		public Color DividerColor {
			get { return dividerColor; }
			set {
				dividerColor = value;
				dividerPen?.Dispose();
				dividerPen = new Pen(dividerColor, dividerWidth);
				FireChange();
			}
		}

		/// <summary>Number of segments across the bar (default 20).</summary>
		[Category("Appearance"), Description("Number of segments"), Browsable(true)]
		public int SegmentCount {
			get { return segmentCount; }
			set { segmentCount = Math.Max(1, value); FireChange(); }
		}

		/// <summary>Divider thickness in pixels (default 1).</summary>
		[Category("Appearance"), Description("Divider thickness in pixels"), Browsable(true)]
		public int DividerWidth {
			get { return dividerWidth; }
			set {
				dividerWidth = Math.Max(1, Math.Min(4, value));
				dividerPen?.Dispose();
				dividerPen = new Pen(dividerColor, dividerWidth);
				FireChange();
			}
		}

		/// <summary>Show a 1px glow outline around the filled area (default true).</summary>
		[Category("Appearance"), Description("Show glow around filled area"), Browsable(true)]
		public bool ShowGlow {
			get { return showGlow; }
			set { showGlow = value; FireChange(); }
		}

		/// <summary>Show a brighter leading edge on the last filled segment (default true).</summary>
		[Category("Appearance"), Description("Show leading edge highlight"), Browsable(true)]
		public bool ShowLeadingEdge {
			get { return showLeadingEdge; }
			set { showLeadingEdge = value; FireChange(); }
		}

		/// <summary></summary>
		/// <param name="box"></param>
		/// <param name="g"></param>
		protected override void PaintThisProgress(Rectangle box, Graphics g) {
			if (box.Width <= 1 || box.Height <= 1) {
				return;
			}

			// Pixel-perfect rendering: no anti-aliasing.
			var prevSmoothing = g.SmoothingMode;
			var prevOffset = g.PixelOffsetMode;
			g.SmoothingMode = SmoothingMode.None;
			g.PixelOffsetMode = PixelOffsetMode.None;

			// Compute segment geometry.
			// totalW = segmentCount * segW + (segmentCount - 1) * dividerWidth
			// segW   = (totalW - (segmentCount - 1) * dividerWidth) / segmentCount
			int totalW = box.Width;
			int segW = (totalW - (segmentCount - 1) * dividerWidth) / segmentCount;
			if (segW < 2) segW = 2;

			// Determine how many segments are filled based on the actual filled
			// pixel width (box.Width is already clipped to the filled portion by
			// AbstractProgressPainter).
			int filledSegments = 0;
			int x = box.X;
			for (int i = 0; i < segmentCount; i++) {
				int segRight = x + segW;
				if (segRight > box.Right) {
					// This segment straddles the leading edge — count it as the
					// last filled one (its leading edge will be highlighted).
					if (x < box.Right) {
						filledSegments = i + 1;
					}
					break;
				}
				filledSegments = i + 1;
				x = segRight + dividerWidth;
			}

			// Optional glow: 1px outline around the entire filled area, drawn
			// first so the fill sits on top.
			if (showGlow && filledSegments > 0) {
				int glowRight = box.X + filledSegments * segW + (filledSegments - 1) * dividerWidth;
				if (glowRight > box.Right) glowRight = box.Right;
				var glowRect = new Rectangle(box.X, box.Y, glowRight - box.X, box.Height);
				// Top edge
				g.DrawLine(glowPen, glowRect.X, glowRect.Y, glowRect.Right - 1, glowRect.Y);
				// Bottom edge
				g.DrawLine(glowPen, glowRect.X, glowRect.Bottom - 1, glowRect.Right - 1, glowRect.Bottom - 1);
				// Left edge
				g.DrawLine(glowPen, glowRect.X, glowRect.Y, glowRect.X, glowRect.Bottom - 1);
				// Right edge (only if not at the bar's right end)
				if (glowRight < box.Right) {
					g.DrawLine(glowPen, glowRect.Right - 1, glowRect.Y, glowRect.Right - 1, glowRect.Bottom - 1);
				}
			}

			// Draw each filled segment.
			for (int i = 0; i < filledSegments; i++) {
				int sx = box.X + i * (segW + dividerWidth);
				var segRect = new Rectangle(sx, box.Y, segW, box.Height);
				g.FillRectangle(fillBrush, segRect);

				// Leading edge: 1px brighter highlight on the right side of the
				// last filled segment.
				if (showLeadingEdge && i == filledSegments - 1) {
					g.FillRectangle(leadingBrush, sx + segW - 1, box.Y, 1, box.Height);
				}
			}

			// Draw dividers BETWEEN filled segments (not on the edges).
			for (int i = 1; i < filledSegments; i++) {
				int dx = box.X + i * (segW + dividerWidth) - dividerWidth;
				g.FillRectangle(new SolidBrush(dividerColor), dx, box.Y, dividerWidth, box.Height);
			}

			if (gloss != null) {
				gloss.PaintGloss(box, g);
			}

			g.SmoothingMode = prevSmoothing;
			g.PixelOffsetMode = prevOffset;
		}

		/// <summary></summary>
		protected override void DisposeThis(bool disposing) {
			fillBrush?.Dispose();
			leadingBrush?.Dispose();
			dividerPen?.Dispose();
			glowPen?.Dispose();
		}
	}
}
