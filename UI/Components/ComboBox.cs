using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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

        protected override void WndProc(ref Message m) {
            if (m.Msg == DrawUtils.WM_PAINT && DropDownStyle != ComboBoxStyle.Simple) {
                const int borderSize = 2;
                // draws background and text
                base.WndProc(ref m);
                var s = new DrawUtils.Paintstruct();
                DrawUtils.IntBeginPaint(Handle, ref s);
                using var g = Graphics.FromHwnd(Handle);
                var d = FlatStyle == FlatStyle.Popup ? 1 : 0;
                var dropButtonRect =
                    new Rectangle(Width - _buttonWidth - d, 0, _buttonWidth, Height);
                // Draw border
                using (var borderPen = new Pen(BorderColor, borderSize)) {
                    g.DrawRectangle(borderPen, ClientRectangle);
                    g.DrawLine(borderPen, Width - _buttonWidth - d, 0, Width - _buttonWidth - d, Height);
                }

                var pointer = PointToClient(MousePosition);
                if (Enabled) {
                    // Draw button background
                    using var highlightBrush =
                        new SolidBrush(ClientRectangle.Contains(pointer) ? ButtonHighlightColor : BackColor);
                    g.FillRectangle(highlightBrush, dropButtonRect);
                }

                using (var borderPen = new Pen(BorderColor, 2)) {
                    g.DrawRectangle(borderPen, dropButtonRect);
                }

                // draw arrow button
                using var arrowBrush = new SolidBrush(ForeColor);
                g.FillPolygon(arrowBrush, DrawUtils.GetDownArrow(dropButtonRect));
                m.Result = (IntPtr)1;
                DrawUtils.IntEndPaint(Handle, ref s);
            } else if (m.Msg == DrawUtils.WM_ERASEBKGND) {
                using (var g = Graphics.FromHdcInternal(m.WParam)) {
                    using var backBrush = new SolidBrush(BackColor);
                    g.FillRectangle(backBrush, ClientRectangle);
                }

                m.Result = (IntPtr)1;
            } else {
                base.WndProc(ref m);
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
    }
}