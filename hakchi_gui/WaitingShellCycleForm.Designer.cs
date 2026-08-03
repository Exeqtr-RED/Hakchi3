namespace com.clusterrr.hakchi_gui
{
    partial class WaitingShellCycleForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WaitingShellCycleForm));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.progressBarEx1 = new ProgressODoom.ProgressBarEx();
            this.pixelBackgroundPainter1 = new ProgressODoom.PixelBackgroundPainter();
            this.pixelBorderPainter1 = new ProgressODoom.PixelBorderPainter();
            this.pixelProgressPainter1 = new ProgressODoom.PixelProgressPainter();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::com.clusterrr.hakchi_gui.Properties.Resources.sign_sync;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // progressBarEx1
            // 
            resources.ApplyResources(this.progressBarEx1, "progressBarEx1");
            this.progressBarEx1.BackgroundPainter = this.pixelBackgroundPainter1;
            this.progressBarEx1.BorderPainter = this.pixelBorderPainter1;
            this.progressBarEx1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.progressBarEx1.MarqueePercentage = 25;
            this.progressBarEx1.MarqueeSpeed = 30;
            this.progressBarEx1.MarqueeStep = 1;
            this.progressBarEx1.Maximum = 100;
            this.progressBarEx1.Minimum = 0;
            this.progressBarEx1.Name = "progressBarEx1";
            this.progressBarEx1.ProgressPadding = 0;
            this.progressBarEx1.ProgressPainter = this.pixelProgressPainter1;
            this.progressBarEx1.ProgressType = ProgressODoom.ProgressType.Smooth;
            this.progressBarEx1.ShowPercentage = false;
            this.progressBarEx1.Value = 30;
            // 
            // pixelBackgroundPainter1
            // 
            this.pixelBackgroundPainter1.ShowGrid = true;
            this.pixelBackgroundPainter1.ShowScanlines = true;
            this.pixelBackgroundPainter1.PixelSize = 8;
            this.pixelBackgroundPainter1.GlossPainter = null;
            // 
            // pixelBorderPainter1
            // 
            this.pixelBorderPainter1.BorderWidth = 2;
            // 
            // pixelProgressPainter1
            // 
            this.pixelProgressPainter1.PixelCount = 20;
            this.pixelProgressPainter1.PixelGap = 2;
            this.pixelProgressPainter1.BlinkLeading = true;
            this.pixelProgressPainter1.Animating = true;
            this.pixelProgressPainter1.AnimationSpeed = 8;
            this.pixelProgressPainter1.GlossPainter = null;
            this.pixelProgressPainter1.ProgressBorderPainter = null;
            // 
            // WaitingShellCycleForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.progressBarEx1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = global::com.clusterrr.hakchi_gui.Properties.Resources.icon;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WaitingShellCycleForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WaitingShellCycle_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.WaitingShellCycle_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private ProgressODoom.ProgressBarEx progressBarEx1;
        private ProgressODoom.PixelBackgroundPainter pixelBackgroundPainter1;
        private ProgressODoom.PixelBorderPainter pixelBorderPainter1;
        private ProgressODoom.PixelProgressPainter pixelProgressPainter1;
    }
}