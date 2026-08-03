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
            doc.Write(string.Empty);

            clear();
        }

        private string formatReadme(string name, ref HmodReadme hReadme)
        {
            string markdownTitle = (name != null && name.Trim() != "" ? $"# {name}\n\n" : "");
            return Markdown.ToHtml(markdownTitle + string.Join("  \n", hReadme.headingLines) + "\n\n" + (hReadme.isMarkdown || hReadme.readme.Length == 0 ? hReadme.readme : $"```\n{hReadme.readme}\n```"));
        }

        private string buildHTML(string css, string bodyContent)
        {
            Color color = this.BackColor;
            string bgColor = $"rgb({color.R},{color.G},{color.B})";
            // Using .Replace() instead of String.Format to avoid curly brace conflicts with CSS
            return Properties.Resources.readmeTemplateHTML
                .Replace("{0}", css)
                .Replace("{1}", bodyContent)
                .Replace("{2}", bgColor);
        }

        private void setReadmeHTML(string name, ref HmodReadme hReadme)
        {
            string html = buildHTML(Properties.Resources.readmeTemplateCSS, formatReadme(name, ref Readme));
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
            string html = buildHTML(Properties.Resources.readmeTemplateCSS, "");
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
