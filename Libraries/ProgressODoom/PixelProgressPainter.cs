using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Collections.Generic;

namespace ProgressODoom {
	/// <summary>
	/// 8-bit (NES/SNES era) pixel-art progress painter. Renders the progress bar
	/// as a row of discrete pixel blocks (like classic NES health bars / life meters).
	/// Each block has a 1px highlight on top-left and 1px shadow on bottom-right,
	/// giving a chunky "3D pixel" look. Block color shifts red -> yellow -> green
	/// based on remaining progress, mirroring classic NES health-bar behavior.
	/// </summary>
	[ToolboxBitmapAttribute(typeof(ProgressODoom.PixelProgressPainter), "Icons.PixelProgressPainter.ico")]
	public class PixelProgressPainter : AbstractProgressPainter, IProgressPainter, IAnimatedProgressPainter, IDisposable {
		// NES color palette (subset relevant to health bars)
		private static readonly Color NesRed       = Color.FromArgb(0xE4, 0x00, 0x58);
		private static readonly Color NesYellow    = Color.FromArgb(0xFC, 0xBC, 0x3C);
		private static readonly Color NesGreen     = Color.FromArgb(0x00, 0xA8, 0x00);
		private static readonly Color NesLightGreen= Color.FromArgb(0x58, 0xD8, 0x54);
		private static readonly Color NesLightRed  = Color.FromArgb(0xF8, 0x78, 0x98);
		private static readonly Color NesLightYel  = Color.FromArgb(0xF8, 0xB8, 0x00);
		private static readonly Color NesWhite     = Color.FromArgb(0xFC, 0xFC, 0xFC);
		private static readonly Color NesBlack     = Color.FromArgb(0x0C, 0x0C, 0x0C);

		private int pixelCount = 20;
		private int pixelGap = 2;
		private bool blinkLeading = true;
		private bool isAnimated = true;
		private int animationSpeed = 8;
		private int blinkPhase = 0;
		private int frameCounter = 0;

		// Cached brushes — allocated once in property setters, disposed in DisposeThis.
		private SolidBrush redBrush;
		private SolidBrush yellowBrush;
		private SolidBrush greenBrush;
		private SolidBrush redHiBrush;
		private SolidBrush yellowHiBrush;
		private SolidBrush greenHiBrush;
		private SolidBrush redLoBrush;
		private SolidBrush yellowLoBrush;
		private SolidBrush greenLoBrush;
		private SolidBrush whiteBrush;
		private SolidBrush blackBrush;

		/// <summary></summary>
		public PixelProgressPainter() {
			InitializeBrushes();
		}

		private void InitializeBrushes() {
			redBrush     = new SolidBrush(NesRed);
			yellowBrush  = new SolidBrush(NesYellow);
			greenBrush   = new SolidBrush(NesGreen);
			redHiBrush   = new SolidBrush(NesLightRed);
			yellowHiBrush= new SolidBrush(NesLightYel);
			greenHiBrush = new SolidBrush(NesLightGreen);
			redLoBrush   = new SolidBrush(Darken(NesRed, 0.5f));
			yellowLoBrush= new SolidBrush(Darken(NesYellow, 0.5f));
			greenLoBrush = new SolidBrush(Darken(NesGreen, 0.5f));
			whiteBrush   = new SolidBrush(NesWhite);
			blackBrush   = new SolidBrush(NesBlack);
		}

		/// <summary>Number of discrete pixel blocks across the bar (default 20).</summary>
		[Category("Appearance"), Description("Number of discrete pixel blocks"), Browsable(true)]
		public int PixelCount {
			get { return pixelCount; }
			set { pixelCount = Math.Max(1, value); FireChange(); }
		}

		/// <summary>Pixel gap between blocks (default 2). 0 = solid bar.</summary>
		[Category("Appearance"), Description("Pixel gap between blocks"), Browsable(true)]
		public int PixelGap {
			get { return pixelGap; }
			set { pixelGap = Math.Max(0, value); FireChange(); }
		}

		/// <summary>If true, the leading block (current progress boundary) blinks.</summary>
		[Category("Appearance"), Description("Blink the leading block when Animating"), Browsable(true)]
		public bool BlinkLeading {
			get { return blinkLeading; }
			set { blinkLeading = value; FireChange(); }
		}

		/// <summary>Animation speed (frames per blink cycle, lower = faster). Default 8.</summary>
		[Category("Behavior"), Description("Blink speed — frames per half-cycle, lower = faster"), Browsable(true)]
		public int AnimationSpeed {
			get { return animationSpeed; }
			set { animationSpeed = Math.Max(1, value); FireChange(); }
		}

		/// <summary>Enable/disable the leading-block blink animation.</summary>
		[Category("Behavior"), Description("Enable animation"), Browsable(true)]
		public bool Animating {
			get { return isAnimated; }
			set { isAnimated = value; }
		}

		/// <summary></summary>
		/// <param name="box"></param>
		/// <param name="g"></param>
		protected override void PaintThisProgress(Rectangle box, Graphics g) {
			if (box.Width <= 1 || box.Height <= 1) {
				return;
			}

			// Pixel-perfect rendering: no anti-aliasing, no smoothing.
			var prevSmoothing = g.SmoothingMode;
			var prevOffset = g.PixelOffsetMode;
			g.SmoothingMode = SmoothingMode.None;
			g.PixelOffsetMode = PixelOffsetMode.None;

			// Compute block geometry.
			// Total width = pixelCount * blockW + (pixelCount - 1) * gap
			// Solve for blockW: blockW = (totalW - (pixelCount - 1) * gap) / pixelCount
			int totalW = box.Width;
			int blockW = (totalW - (pixelCount - 1) * pixelGap) / pixelCount;
			if (blockW < 2) blockW = 2;
			int blockH = box.Height;

			// Determine how many blocks are filled based on box.Width relative to
			// the full bar width. The AbstractProgressPainter already clips box to
			// the filled portion, so we compute fillRatio from actual pixel coverage.
			// We don't know the full bar width here, so we approximate by drawing
			// blocks left-to-right until we run out of width.
			int filledBlocks = 0;
			int x = box.X;
			for (int i = 0; i < pixelCount; i++) {
				int blockRight = x + blockW;
				if (blockRight > box.Right) {
					// This block is partially or fully outside the filled region.
					// Draw it as the "leading" block (the leading edge of progress).
					if (x < box.Right) {
						filledBlocks = i + 1; // count it as leading
					}
					break;
				}
				filledBlocks = i + 1;
				x = blockRight + pixelGap;
			}

			// Pick the base color based on fill ratio (NES health-bar convention).
			double fillRatio = (double)filledBlocks / pixelCount;
			SolidBrush baseBrush, hiBrush, loBrush;
			if (fillRatio <= 0.25) {
				baseBrush = redBrush; hiBrush = redHiBrush; loBrush = redLoBrush;
			} else if (fillRatio <= 0.5) {
				baseBrush = yellowBrush; hiBrush = yellowHiBrush; loBrush = yellowLoBrush;
			} else {
				baseBrush = greenBrush; hiBrush = greenHiBrush; loBrush = greenLoBrush;
			}

			// Animation: blink the leading block.
			bool leadingVisible = true;
			if (isAnimated && blinkLeading && filledBlocks > 0 && filledBlocks <= pixelCount) {
				frameCounter++;
				if (frameCounter >= animationSpeed * 2) {
					frameCounter = 0;
				}
				blinkPhase = (frameCounter < animationSpeed) ? 1 : 0;
				leadingVisible = (blinkPhase == 1);
			}

			// Draw each filled block.
			for (int i = 0; i < filledBlocks; i++) {
				int bx = box.X + i * (blockW + pixelGap);
				int by = box.Y;
				var blockRect = new Rectangle(bx, by, blockW, blockH);

				bool isLeading = (i == filledBlocks - 1);

				// Skip drawing the leading block during the "off" blink phase.
				if (isLeading && !leadingVisible) {
					continue;
				}

				// Fill block body.
				g.FillRectangle(baseBrush, blockRect);

				// 1px highlight on top edge.
				g.FillRectangle(hiBrush, bx, by, blockW, 1);
				// 1px highlight on left edge.
				g.FillRectangle(hiBrush, bx, by, 1, blockH);
				// 1px shadow on bottom edge.
				g.FillRectangle(loBrush, bx, by + blockH - 1, blockW, 1);
				// 1px shadow on right edge.
				g.FillRectangle(loBrush, bx + blockW - 1, by, 1, blockH);

				// Leading block: extra white outline to draw attention.
				if (isLeading && blinkLeading) {
					g.DrawRectangle(new Pen(whiteBrush, 1), bx, by, blockW - 1, blockH - 1);
				}
			}

			if (gloss != null) {
				gloss.PaintGloss(box, g);
			}

			g.SmoothingMode = prevSmoothing;
			g.PixelOffsetMode = prevOffset;
		}

		private static Color Darken(Color c, float factor) {
			return Color.FromArgb(
				(int)(c.R * factor),
				(int)(c.G * factor),
				(int)(c.B * factor)
			);
		}

		/// <summary></summary>
		protected override void DisposeThis(bool disposing) {
			redBrush?.Dispose();
			yellowBrush?.Dispose();
			greenBrush?.Dispose();
			redHiBrush?.Dispose();
			yellowHiBrush?.Dispose();
			greenHiBrush?.Dispose();
			redLoBrush?.Dispose();
			yellowLoBrush?.Dispose();
			greenLoBrush?.Dispose();
			whiteBrush?.Dispose();
			blackBrush?.Dispose();
		}
	}
}
