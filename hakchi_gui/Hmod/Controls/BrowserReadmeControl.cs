using Markdig;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace com.clusterrr.hakchi_gui.Hmod.Controls
{
    public partial class BrowserReadmeControl : UserControl, IReadmeControl
    {
        private HmodReadme Readme;

        public BrowserReadmeControl()
        {
            InitializeComponent();

            wbReadme.Navigate("about:blank");
            HtmlDocument doc = wbReadme.Document;
            doc.Write(String.Empty);

            wbReadme.DocumentCompleted += WbReadme_DocumentCompleted;

            clear();
        }

        private void WbReadme_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (e.Url.ToString() == "about:blank") return;
            try
            {
                dynamic domDoc = wbReadme.Document.DomDocument;
                Trace.WriteLine($"[Readme] documentMode={domDoc.documentMode}, compatMode={domDoc.compatMode}");
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"[Readme] Failed to get documentMode: {ex.Message}");
            }
        }

        private string formatReadme(string name, ref HmodReadme hReadme)
        {
            string markdownTitle = (name != null && name.Trim() != "" ? $"# {name}\n\n" : "");
            return Markdown.ToHtml(markdownTitle + String.Join("  \n", hReadme.headingLines) + "\n\n" + (hReadme.isMarkdown || hReadme.readme.Length == 0 ? hReadme.readme : $"```\n{hReadme.readme}\n```"));
        }

        private void setReadmeHTML(string name, ref HmodReadme hReadme)
        {
            Color color = this.BackColor;
            var css = Properties.Resources.readmeTemplateCSS;
            var tmpl = Properties.Resources.readmeTemplateHTML;
            Trace.WriteLine($"[Readme] CSS length={css?.Length ?? -1}, Template length={tmpl?.Length ?? -1}");
            string html = String.Format(tmpl, css, formatReadme(name, ref Readme), $"rgb({color.R},{color.G},{color.B})");
            wbReadme.DocumentText = html;
        }

        public void setReadme(string name, string readme = "", bool markdown = false)
        {
            setReadme(name, new HmodReadme(readme, markdown));
        }

        public void setReadme(string name, HmodReadme hReadme)
        {
            Readme = hReadme;
            setReadmeHTML(name, ref Readme);
        }

        public void clear()
        {
            Readme = new HmodReadme("");

            Color color = this.BackColor;
            var css = Properties.Resources.readmeTemplateCSS;
            var tmpl = Properties.Resources.readmeTemplateHTML;
            Trace.WriteLine($"[Readme:clear] CSS length={css?.Length ?? -1}, Template length={tmpl?.Length ?? -1}");
            string html = String.Format(tmpl, css, "", $"rgb({color.R},{color.G},{color.B})");
            wbReadme.DocumentText = html;
        }

        private void wbReadme_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            if (e.Url.ToString() == "about:blank") return;

            //cancel the current event
            e.Cancel = true;

            //this opens the URL in the user's default browser
            Process.Start(e.Url.ToString());
        }
    }
}
