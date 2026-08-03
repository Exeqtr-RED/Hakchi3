namespace com.clusterrr.hakchi_gui.Tasks
{
    partial class TaskerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaskerForm));
            this.statusLabel = new System.Windows.Forms.Label();
            this.progressBarEx1 = new ProgressODoom.ProgressBarEx();
            this.plainBackgroundPainter1 = new ProgressODoom.PlainBackgroundPainter();
            this.plainBorderPainter1 = new ProgressODoom.PlainBorderPainter();
            this.plainProgressPainter1 = new ProgressODoom.PlainProgressPainter();
            this.statusPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.statusPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // statusLabel
            // 
            resources.ApplyResources(this.statusLabel, "statusLabel");
            this.statusLabel.Name = "statusLabel";
            // 
            // progressBarEx1
            // 
            this.progressBarEx1.BackgroundPainter = this.plainBackgroundPainter1;
            this.progressBarEx1.BorderPainter = this.plainBorderPainter1;
            resources.ApplyResources(this.progressBarEx1, "progressBarEx1");
            this.progressBarEx1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.progressBarEx1.MarqueePercentage = 25;
            this.progressBarEx1.MarqueeSpeed = 30;
            this.progressBarEx1.MarqueeStep = 1;
            this.progressBarEx1.Maximum = 100;
            this.progressBarEx1.Minimum = 0;
            this.progressBarEx1.Name = "progressBarEx1";
            this.progressBarEx1.ProgressPadding = 0;
            this.progressBarEx1.ProgressPainter = this.plainProgressPainter1;
            this.progressBarEx1.ProgressType = ProgressODoom.ProgressType.Smooth;
            this.progressBarEx1.ShowPercentage = true;
            this.progressBarEx1.Value = 0;
            // 
            // plainBackgroundPainter1
            // 
            this.plainBackgroundPainter1.Color = System.Drawing.Color.FromArgb(230, 235, 240);
            this.plainBackgroundPainter1.GlossPainter = null;
            // 
            // plainBorderPainter1
            // 
            this.plainBorderPainter1.Color = System.Drawing.Color.FromArgb(200, 210, 220);
            this.plainBorderPainter1.Style = ProgressODoom.PlainBorderPainter.PlainBorderStyle.Flat;
            // 
            // plainProgressPainter1
            // 
            this.plainProgressPainter1.Color = System.Drawing.Color.FromArgb(74, 144, 217);
            this.plainProgressPainter1.LeadingEdge = System.Drawing.Color.FromArgb(100, 170, 240);
            this.plainProgressPainter1.GlossPainter = null;
            this.plainProgressPainter1.ProgressBorderPainter = null;
            // 
            // statusPictureBox
            // 
            resources.ApplyResources(this.statusPictureBox, "statusPictureBox");
            this.statusPictureBox.Name = "statusPictureBox";
            this.statusPictureBox.TabStop = false;
            // 
            // TaskerForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.statusPictureBox);
            this.Controls.Add(this.progressBarEx1);
            this.Controls.Add(this.statusLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = global::com.clusterrr.hakchi_gui.Properties.Resources.icon;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TaskerForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TaskerForm_FormClosing);
            this.Shown += new System.EventHandler(this.TaskerForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.statusPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label statusLabel;
        private ProgressODoom.ProgressBarEx progressBarEx1;
        private ProgressODoom.PlainBackgroundPainter plainBackgroundPainter1;
        private ProgressODoom.PlainProgressPainter plainProgressPainter1;
        private ProgressODoom.PlainBorderPainter plainBorderPainter1;
        private System.Windows.Forms.PictureBox statusPictureBox;
    }
}