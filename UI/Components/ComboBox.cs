using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DOS2Randomizer.UI.Components {
    public class ComboBox : System.Windows.Forms.ComboBox, IChoosableDesign {
        private DesignType _design = DesignType.Dark;
        private readonly int _buttonWidth = SystemInformation.HorizontalScrollBarArrowWidth;
        private Color _borderColor;

        public ComboBox() {
            //DrawMode = DrawMode.OwnerDrawFixed;
        }

        public Color ButtonHighlightColor => UI.Design.Get(Design).SelectedColor;

        protected override void OnDrawItem(DrawItemEventArgs e) {
            var design = UI.Design.Get(Design);
            bool selected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;
            var selectColor = selected ? design.SelectedColor : BackColor;
            var state = selected ? e.State ^ DrawItemState.Selected : e.State;
            var eventArg = new DrawItemEventArgs(e.Graphics, e.Font, e.Bounds, e.Index,
                state, e.ForeColor, selectColor);
            base.OnDrawItem(e);
        }

        public Color BorderColor {
            get => _borderColor;
            set {
                _borderColor = value;
                Invalidate();
            }
        }

        public DesignType Design {
            get => _design;
            set {
                _design = value;
                var design = UI.Design.Get(_design);
                BackColor = design.EditBackColor;
                ForeColor = design.TextColor;
                FlatStyle = design.FlatStyle;
                BorderColor = design.BorderStyle == BorderStyle.FixedSingle ? design.ControlColor : design.BackColor;
            }
        }

        public Color ButtonColor {
            get {
                var pointer = PointToClient(MousePosition);
                return ClientRectangle.Contains(pointer) ? ButtonHighlightColor : BackColor;
            }
        }

        // stolen from https://stackoverflow.com/questions/65976232/how-to-change-the-combobox-dropdown-button-color/65976649#65976649
        protected override void WndProc(ref Message m) {
            if (m.Msg == DrawUtils.WM_PAINT && DropDownStyle != ComboBoxStyle.Simple) {
                var dropDownButtonWidth = SystemInformation.HorizontalScrollBarArrowWidth;
                var outerBorder = new Rectangle(ClientRectangle.Location,
                    new Size(ClientRectangle.Width - 1, ClientRectangle.Height - 1));
                var innerBorder = new Rectangle(outerBorder.X + 1, outerBorder.Y + 1,
                    outerBorder.Width - dropDownButtonWidth - 2, outerBorder.Height - 2);
                var innerInnerBorder = new Rectangle(innerBorder.X + 1, innerBorder.Y + 1,
                    innerBorder.Width - 2, innerBorder.Height - 2);
                var dropDownRect = new Rectangle(innerBorder.Right + 1, innerBorder.Y,
                    dropDownButtonWidth, innerBorder.Height + 1);
                if (RightToLeft == RightToLeft.Yes) {
                    innerBorder.X = ClientRectangle.Width - innerBorder.Right;
                    innerInnerBorder.X = ClientRectangle.Width - innerInnerBorder.Right;
                    dropDownRect.X = ClientRectangle.Width - dropDownRect.Right;
                    dropDownRect.Width += 1;
                }

                var innerBorderColor = Enabled ? BackColor : SystemColors.Control;
                var outerBorderColor = Enabled ? BorderColor : SystemColors.ControlDark;
                var buttonColor = Enabled ? ButtonColor : SystemColors.Control;
                var arrow = DrawUtils.GetDownArrow(dropDownRect);
                var ps = new DrawUtils.Paintstruct();
                bool shouldEndPaint = false;
                IntPtr dc;
                if (m.WParam == IntPtr.Zero) {
                    dc = DrawUtils.IntBeginPaint(Handle, ref ps);
                    m.WParam = dc;
                    shouldEndPaint = true;
                } else {
                    dc = m.WParam;
                }

                var rgn = DrawUtils.CreateRectRgn(innerInnerBorder.Left, innerInnerBorder.Top,
                    innerInnerBorder.Right, innerInnerBorder.Bottom);
                DrawUtils.SelectClipRgn(dc, rgn);
                DefWndProc(ref m);
                DrawUtils.DeleteObject(rgn);
                rgn = DrawUtils.CreateRectRgn(ClientRectangle.Left, ClientRectangle.Top,
                    ClientRectangle.Right, ClientRectangle.Bottom);
                DrawUtils.SelectClipRgn(dc, rgn);
                using (var g = Graphics.FromHdc(dc)) {
                    using (var b = new SolidBrush(buttonColor)) {
                        g.FillRectangle(b, dropDownRect);
                    }

                    using (var b = new SolidBrush(ForeColor)) {
                        g.FillPolygon(b, arrow);
                    }

                    using (var p = new Pen(innerBorderColor)) {
                        g.DrawRectangle(p, innerBorder);
                        g.DrawRectangle(p, innerInnerBorder);
                    }

                    using (var p = new Pen(outerBorderColor)) {
                        g.DrawRectangle(p, outerBorder);
                    }
                }

                if (shouldEndPaint) {
                    DrawUtils.IntEndPaint(Handle, ref ps);
                }

                DrawUtils.DeleteObject(rgn);
            } else {
                base.WndProc(ref m);
            }
        }
    }
}