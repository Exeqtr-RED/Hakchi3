namespace com.clusterrr.hakchi_gui.Controls
{
    partial class ImageGoogler
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (searchCts != null)
                {
                    searchCts.Cancel();
                    searchCts.Dispose();
                    searchCts = null;
                }
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            listView = new System.Windows.Forms.ListView();
            imageList = new System.Windows.Forms.ImageList(components);
            SuspendLayout();
            // 
            // listView
            // 
            listView.Dock = System.Windows.Forms.DockStyle.Fill;
            listView.HideSelection = false;
            listView.LargeImageList = imageList;
            listView.Location = new System.Drawing.Point(0, 0);
            listView.Name = "listView";
            listView.Size = new System.Drawing.Size(442, 365);
            listView.SmallImageList = imageList;
            listView.TabIndex = 1;
            listView.UseCompatibleStateImageBehavior = false;
            listView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(listView_ItemSelectionChanged);
            listView.DoubleClick += new System.EventHandler(listView_DoubleClick);
            // 
            // imageList
            // 
            imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            imageList.ImageSize = new System.Drawing.Size(204, 204);
            imageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // ImageGoogler
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(listView);
            Name = "ImageGoogler";
            Size = new System.Drawing.Size(442, 365);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ImageList imageList;
    }
}
