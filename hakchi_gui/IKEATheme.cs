using System;
using System.Drawing;
using System.Windows.Forms;

namespace com.clusterrr.hakchi_gui
{
    /// <summary>
    /// —ветла¤ современна¤ тема "јкварель" с пастельными тонами и эргономичным дизайном.
    /// </summary>
    public static class IKEATheme
    {
        #region ÷ветова¤ палитра
        public static class Colors
        {
            public static readonly Color FormBg = Color.FromArgb(245, 246, 248);
            public static readonly Color ControlBg = Color.White;
            public static readonly Color PanelBg = Color.White;
            public static readonly Color GroupBoxBg = Color.FromArgb(245, 246, 248);
            public static readonly Color StatusBarBg = Color.FromArgb(74, 144, 217);
            public static readonly Color MenuBg = Color.White;
            public static readonly Color MenuBarBg = Color.FromArgb(245, 246, 248);
            public static readonly Color TextPrimary = Color.FromArgb(44, 62, 80);
            public static readonly Color TextSecondary = Color.FromArgb(127, 140, 141);
            public static readonly Color TextDisabled = Color.FromArgb(189, 195, 199);
            public static readonly Color TextOnAccent = Color.White;
            public static readonly Color AccentBlue = Color.FromArgb(74, 144, 217);
            public static readonly Color AccentBlueHover = Color.FromArgb(100, 170, 240);
            public static readonly Color AccentBluePress = Color.FromArgb(52, 110, 180);
            public static readonly Color Border = Color.FromArgb(200, 210, 220);
            public static readonly Color BorderLight = Color.FromArgb(230, 235, 240);
            public static readonly Color SelectionBg = Color.FromArgb(74, 144, 217);
            public static readonly Color ListViewSelect = Color.FromArgb(74, 144, 217);
            public static readonly Color ListViewSelectText = Color.White;
            public static readonly Color ProgressTrack = Color.FromArgb(230, 235, 240);
            public static readonly Color ProgressFill = Color.FromArgb(74, 144, 217);
            public static readonly Color AlternateRow = Color.FromArgb(240, 242, 245);
        }
        #endregion

        #region Ўрифты
        public static class Fonts
        {
            public static readonly Font UI = new Font("Segoe UI", 9f);
            public static readonly Font UIBold = new Font("Segoe UI", 9f, FontStyle.Bold);
            public static readonly Font Title = new Font("Segoe UI", 12f, FontStyle.Bold);
            public static readonly Font Mono = new Font("Consolas", 9f);
        }
        #endregion

        public static void Apply(Form form)
        {
            StyleControl(form);
            Walk(form);
        }

        private static void Walk(Control parent)
        {
            foreach (Control child in parent.Controls)
            {
                StyleControl(child);
                Walk(child);
            }
        }

        private static void StyleControl(Control c)
        {
            if (c is WebBrowser) return;

            if (c.Font == null || c.Font.Name != "Segoe UI")
                c.Font = Fonts.UI;

            if (c is Form frm)
            {
                frm.BackColor = Colors.FormBg;
                frm.ForeColor = Colors.TextPrimary;
                return;
            }

            if (c is Panel pnl)
            {
                pnl.BackColor = Colors.PanelBg;
                pnl.ForeColor = Colors.TextPrimary;
                return;
            }

            if (c is GroupBox grp)
            {
                grp.BackColor = Colors.GroupBoxBg;
                grp.ForeColor = Colors.TextPrimary;
                return;
            }

            if (c is TabControl tab)
            {
                tab.BackColor = Colors.FormBg;
                tab.ForeColor = Colors.TextPrimary;
                tab.Padding = new Point(10, 5);
                foreach (TabPage tp in tab.TabPages)
                {
                    tp.BackColor = Colors.ControlBg;
                    tp.ForeColor = Colors.TextPrimary;
                }
                return;
            }

            if (c is TabPage page)
            {
                page.BackColor = Colors.ControlBg;
                page.ForeColor = Colors.TextPrimary;
                return;
            }

            if (c is TextBoxBase tb)
            {
                tb.BackColor = Colors.ControlBg;
                tb.ForeColor = Colors.TextPrimary;
                tb.BorderStyle = BorderStyle.FixedSingle;
                return;
            }

            if (c is ComboBox cb)
            {
                cb.BackColor = Colors.ControlBg;
                cb.ForeColor = Colors.TextPrimary;
                cb.FlatStyle = FlatStyle.Flat;
                return;
            }

            if (c is Button btn)
            {
                btn.BackColor = Colors.AccentBlue;
                btn.ForeColor = Colors.TextOnAccent;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderColor = Colors.AccentBlue;
                btn.FlatAppearance.MouseOverBackColor = Colors.AccentBlueHover;
                btn.FlatAppearance.MouseDownBackColor = Colors.AccentBluePress;
                btn.FlatAppearance.BorderSize = 0;
                btn.Cursor = Cursors.Hand;
                btn.TextAlign = ContentAlignment.MiddleCenter;
                btn.Font = Fonts.UIBold;
                return;
            }

            if (c is CheckBox chk)
            {
                chk.BackColor = Color.Transparent;
                chk.ForeColor = Colors.TextPrimary;
                chk.FlatStyle = FlatStyle.Flat;
                return;
            }

            if (c is RadioButton rbtn)
            {
                rbtn.BackColor = Color.Transparent;
                rbtn.ForeColor = Colors.TextPrimary;
                rbtn.FlatStyle = FlatStyle.Flat;
                return;
            }

            if (c is ListBox lb)
            {
                lb.BackColor = Colors.ControlBg;
                lb.ForeColor = Colors.TextPrimary;
                lb.BorderStyle = BorderStyle.FixedSingle;
                lb.DrawMode = DrawMode.OwnerDrawFixed;
                lb.DrawItem += DrawListBoxItem;
                return;
            }

            if (c is CheckedListBox clb)
            {
                clb.BackColor = Colors.ControlBg;
                clb.ForeColor = Colors.TextPrimary;
                clb.BorderStyle = BorderStyle.FixedSingle;
                return;
            }

            if (c is ListView lv)
            {
                lv.BackColor = Colors.ControlBg;
                lv.ForeColor = Colors.TextPrimary;
                lv.BorderStyle = BorderStyle.FixedSingle;
                lv.OwnerDraw = true;
                lv.DrawColumnHeader += LvDrawHeader;
                lv.DrawSubItem += LvDrawItem;
                return;
            }

            if (c is TreeView tv)
            {
                tv.BackColor = Colors.ControlBg;
                tv.ForeColor = Colors.TextPrimary;
                tv.BorderStyle = BorderStyle.FixedSingle;
                tv.LineColor = Colors.Border;
                return;
            }

            if (c is TrackBar track)
            {
                track.BackColor = Colors.FormBg;
                track.ForeColor = Colors.TextPrimary;
                return;
            }

            if (c is ProgressBar prog)
            {
                prog.BackColor = Colors.ProgressTrack;
                prog.ForeColor = Colors.ProgressFill;
                prog.Style = ProgressBarStyle.Continuous;
                return;
            }

            if (c is PictureBox pic)
            {
                pic.BackColor = Colors.FormBg;
                return;
            }

            if (c is Label lbl)
            {
                lbl.BackColor = Color.Transparent;
                lbl.ForeColor = Colors.TextPrimary;
                return;
            }

            if (c is LinkLabel ll)
            {
                ll.BackColor = Color.Transparent;
                ll.LinkColor = Colors.AccentBlue;
                ll.VisitedLinkColor = Colors.AccentBluePress;
                return;
            }

            if (c is NumericUpDown nud)
            {
                nud.BackColor = Colors.ControlBg;
                nud.ForeColor = Colors.TextPrimary;
                nud.BorderStyle = BorderStyle.FixedSingle;
                nud.UpDownAlign = LeftRightAlignment.Right;
                return;
            }

            if (c is DateTimePicker dtp)
            {
                dtp.BackColor = Colors.ControlBg;
                dtp.ForeColor = Colors.TextPrimary;
                dtp.CalendarForeColor = Colors.TextPrimary;
                dtp.CalendarMonthBackground = Colors.ControlBg;
                dtp.CalendarTitleBackColor = Colors.ControlBg;
                dtp.CalendarTitleForeColor = Colors.TextPrimary;
                dtp.CalendarTrailingForeColor = Colors.TextDisabled;
                return;
            }

            if (c is MonthCalendar mc)
            {
                mc.BackColor = Colors.ControlBg;
                mc.ForeColor = Colors.TextPrimary;
                mc.TitleBackColor = Colors.ControlBg;
                mc.TitleForeColor = Colors.TextPrimary;
                mc.TrailingForeColor = Colors.TextDisabled;
                return;
            }

            if (c is SplitContainer sc)
            {
                sc.BackColor = Colors.FormBg;
                sc.ForeColor = Colors.TextPrimary;
                sc.Panel1.BackColor = Colors.ControlBg;
                sc.Panel2.BackColor = Colors.ControlBg;
                sc.SplitterWidth = 6;
                return;
            }

            if (c is MenuStrip ms)
            {
                ms.BackColor = Colors.MenuBarBg;
                ms.ForeColor = Colors.TextPrimary;
                ms.Renderer = new AquaRenderer();
                return;
            }

            if (c is ContextMenuStrip cms)
            {
                cms.BackColor = Colors.MenuBg;
                cms.ForeColor = Colors.TextPrimary;
                cms.Renderer = new AquaRenderer();
                return;
            }

            if (c is StatusStrip ss)
            {
                ss.BackColor = Colors.StatusBarBg;
                ss.ForeColor = Colors.TextOnAccent;
                ss.Renderer = new AquaRenderer();
                foreach (ToolStripItem item in ss.Items)
                {
                    item.ForeColor = Colors.TextOnAccent;
                    if (item is ToolStripStatusLabel statusLabel)
                    {
                        statusLabel.BackColor = Color.Transparent;
                        statusLabel.TextAlign = ContentAlignment.MiddleLeft;
                    }
                }
                return;
            }

            if (c is ToolStrip ts)
            {
                ts.BackColor = Colors.MenuBarBg;
                ts.ForeColor = Colors.TextPrimary;
                ts.Renderer = new AquaRenderer();
                return;
            }

            if (c is PropertyGrid pg)
            {
                pg.BackColor = Colors.ControlBg;
                pg.ForeColor = Colors.TextPrimary;
                pg.LineColor = Colors.Border;
                pg.ViewBackColor = Colors.ControlBg;
                pg.ViewForeColor = Colors.TextPrimary;
                pg.CategoryForeColor = Colors.TextSecondary;
                pg.HelpBackColor = Colors.ControlBg;
                pg.HelpForeColor = Colors.TextPrimary;
                return;
            }

            c.BackColor = Colors.ControlBg;
            c.ForeColor = Colors.TextPrimary;
        }

        #region ќтрисовка ListView
        private static void LvDrawHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            using (var brush = new SolidBrush(Colors.MenuBarBg))
                e.Graphics.FillRectangle(brush, e.Bounds);
            using (var pen = new Pen(Colors.Border))
                e.Graphics.DrawLine(pen, e.Bounds.Left, e.Bounds.Bottom - 1,
                    e.Bounds.Right, e.Bounds.Bottom - 1);
            using (var textBrush = new SolidBrush(Colors.TextPrimary))
            {
                var sf = new StringFormat
                {
                    Alignment = StringAlignment.Near,
                    LineAlignment = StringAlignment.Center
                };
                e.Graphics.DrawString(e.Header.Text, Fonts.UIBold, textBrush, e.Bounds, sf);
            }
            e.DrawDefault = false;
        }

        private static void LvDrawItem(object sender, DrawListViewSubItemEventArgs e)
        {
            Color backColor = (e.ItemIndex % 2 == 0) ? Colors.ControlBg : Colors.AlternateRow;
            if (e.Item.Selected)
                backColor = Colors.ListViewSelect;

            using (var brush = new SolidBrush(backColor))
                e.Graphics.FillRectangle(brush, e.Bounds);

            Color textColor = e.Item.Selected ? Colors.ListViewSelectText : Colors.TextPrimary;
            using (var textBrush = new SolidBrush(textColor))
            {
                var sf = new StringFormat
                {
                    Alignment = StringAlignment.Near,
                    LineAlignment = StringAlignment.Center
                };
                e.Graphics.DrawString(e.SubItem.Text ?? "", Fonts.UI, textBrush, e.Bounds, sf);
            }
            e.DrawDefault = false;
        }
        #endregion

        #region ќтрисовка ListBox
        private static void DrawListBoxItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;
            var lb = sender as ListBox;
            if (lb == null) return;

            bool selected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;
            Color back = selected ? Colors.ListViewSelect :
                         (e.Index % 2 == 0 ? Colors.ControlBg : Colors.AlternateRow);

            using (var brush = new SolidBrush(back))
                e.Graphics.FillRectangle(brush, e.Bounds);

            Color fore = selected ? Colors.ListViewSelectText : Colors.TextPrimary;
            using (var textBrush = new SolidBrush(fore))
            {
                string text = lb.Items[e.Index]?.ToString() ?? "";
                e.Graphics.DrawString(text, Fonts.UI, textBrush, e.Bounds);
            }
        }
        #endregion
    }

    #region –ендерер дл¤ меню и тулбаров
    public class AquaColorTable : ProfessionalColorTable
    {
        public override Color ToolStripGradientBegin => IKEATheme.Colors.MenuBarBg;
        public override Color ToolStripGradientMiddle => IKEATheme.Colors.MenuBarBg;
        public override Color ToolStripGradientEnd => IKEATheme.Colors.MenuBarBg;
        public override Color MenuStripGradientBegin => IKEATheme.Colors.MenuBarBg;
        public override Color MenuStripGradientEnd => IKEATheme.Colors.MenuBarBg;
        public override Color ImageMarginGradientBegin => IKEATheme.Colors.MenuBg;
        public override Color ImageMarginGradientMiddle => IKEATheme.Colors.MenuBg;
        public override Color ImageMarginGradientEnd => IKEATheme.Colors.MenuBg;
        public override Color SeparatorDark => IKEATheme.Colors.Border;
        public override Color SeparatorLight => IKEATheme.Colors.BorderLight;
        public override Color ButtonSelectedHighlight => IKEATheme.Colors.AccentBlueHover;
        public override Color ButtonSelectedBorder => IKEATheme.Colors.AccentBlue;
        public override Color ButtonPressedGradientBegin => IKEATheme.Colors.AccentBluePress;
        public override Color ButtonPressedGradientMiddle => IKEATheme.Colors.AccentBluePress;
        public override Color ButtonPressedGradientEnd => IKEATheme.Colors.AccentBluePress;
        public override Color CheckBackground => IKEATheme.Colors.ControlBg;
        public override Color CheckSelectedBackground => IKEATheme.Colors.AccentBlue;
        public override Color ButtonSelectedGradientBegin => IKEATheme.Colors.AccentBlueHover;
        public override Color ButtonSelectedGradientMiddle => IKEATheme.Colors.AccentBlueHover;
        public override Color ButtonSelectedGradientEnd => IKEATheme.Colors.AccentBlueHover;
        public override Color OverflowButtonGradientBegin => IKEATheme.Colors.MenuBarBg;
        public override Color OverflowButtonGradientMiddle => IKEATheme.Colors.MenuBarBg;
        public override Color OverflowButtonGradientEnd => IKEATheme.Colors.MenuBarBg;
        public override Color StatusStripGradientBegin => IKEATheme.Colors.StatusBarBg;
        public override Color StatusStripGradientEnd => IKEATheme.Colors.StatusBarBg;
    }

    public class AquaRenderer : ToolStripProfessionalRenderer
    {
        public AquaRenderer() : base(new AquaColorTable()) { }

        protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
        {
            e.Graphics.FillRectangle(
                new SolidBrush(IKEATheme.Colors.MenuBarBg), e.AffectedBounds);
        }

        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            var rect = new Rectangle(Point.Empty, e.Item.Size);
            if (e.Item.Selected)
                e.Graphics.FillRectangle(
                    new SolidBrush(IKEATheme.Colors.AccentBlueHover), rect);
            else
                e.Graphics.FillRectangle(
                    new SolidBrush(IKEATheme.Colors.MenuBg), rect);
        }

        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            e.TextColor = IKEATheme.Colors.TextPrimary;
            base.OnRenderItemText(e);
        }

        protected override void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e)
        {
            var bounds = e.Item.Bounds;
            using (var pen = new Pen(IKEATheme.Colors.Border))
                e.Graphics.DrawLine(pen, bounds.Left + 4, bounds.Height / 2,
                    bounds.Right - 4, bounds.Height / 2);
        }

        protected override void OnRenderToolStripStatusLabelBackground(ToolStripItemRenderEventArgs e) { }
    }
    #endregion
}
