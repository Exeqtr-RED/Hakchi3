using Markdig;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace com.clusterrr.hakchi_gui
{
    public partial class Motd : Form
    {
        private string html;
        WebBrowser webBrowser;
        TextBox textBox;
        public Motd(string message)
        {
            InitializeComponent();

            var position = new Point(12, 12);
            var size = new Size(472, 304);

            if (Shared.isWindows)
            {
                webBrowser = new WebBrowser() { Location = position, Size = size, Dock = DockStyle.Fill, Url = new Uri("about:blank") };
                webBrowser.Navigating += webBrowser_Navigating;
                webBrowser.DocumentCompleted += WebBrowser_DocumentCompleted;
                panel1.Controls.Add(webBrowser);
                Color color = this.BackColor;
                string text = Markdown.ToHtml(message);
                string bgColor = $"rgb({color.R},{color.G},{color.B})";
                // Using .Replace() instead of String.Format to avoid curly brace conflicts
                this.html = Properties.Resources.motdTemplateHTML
                    .Replace("{0}", Properties.Resources.motdTemplateCSS)
                    .Replace("{1}", this.Text)
                    .Replace("{2}", text)
                    .Replace("{3}", bgColor);
            }
            else
            {
                textBox = new TextBox() { Location = position, Size = size, ReadOnly = true, BackColor = SystemColors.Window, Multiline = true, ScrollBars = ScrollBars.Both, Dock = DockStyle.Fill };
                panel1.Controls.Add(textBox);
                textBox.Text = message;
            }
        }

        private void WebBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (e.Url.ToString() == "about:blank") return;
            try
            {
                dynamic domDoc = webBrowser.Document.DomDocument;
                Trace.WriteLine($"[MOTD] documentMode={domDoc.documentMode}, compatMode={domDoc.compatMode}");
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"[MOTD] Failed to get documentMode: {ex.Message}");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Motd_Shown(object sender, EventArgs e)
        {
            if (webBrowser != null)
            {
                webBrowser.DocumentText = html;
            }
        }

        private void webBrowser_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            if (e.Url.ToString() == "about:blank") return;

            //cancel the current event
            e.Cancel = true;

            //this opens the URL in the user's default browser
            Process.Start(e.Url.ToString());
        }
    }
}
