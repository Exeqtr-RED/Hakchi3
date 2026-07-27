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
                panel1.Controls.Add(webBrowser);
                Color color = this.BackColor;
                string text = Markdown.ToHtml(message);
                var css = Properties.Resources.motdTemplateCSS;
                var tmpl = Properties.Resources.motdTemplateHTML;
                Trace.WriteLine($"[MOTD] CSS length={css?.Length ?? -1}, Template length={tmpl?.Length ?? -1}");
                this.html = String.Format(
                    tmpl,
                    css,
                    this.Text,
                    text,
                    $"rgb({color.R},{color.G},{color.B})");
            }
            else
            {
                textBox = new TextBox() { Location = position, Size = size, ReadOnly = true, BackColor = SystemColors.Window, Multiline = true, ScrollBars = ScrollBars.Both, Dock = DockStyle.Fill };
                panel1.Controls.Add(textBox);
                textBox.Text = message;
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
