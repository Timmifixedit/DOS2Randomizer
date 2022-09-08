﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DOS2Randomizer.UI.Components {
    public class IntegerField : NumericUpDown, IChoosableDesign {
        private DesignType _design = DesignType.Dark;
        private FlatStyle _flatStyle;

        public FlatStyle FlatStyle {
            get => _flatStyle;
            set {
                _flatStyle = value;
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
                BorderStyle = design.BorderStyle;
                FlatStyle = design.FlatStyle;
            }
        }

        public Color BorderColor => UI.Design.Get(Design).ControlColor;

        public Color ButtonHighlightColor => UI.Design.Get(Design).SelectedColor;

        public IntegerField() {
            var renderer = new UpDownButtonRenderer(Controls[0]);
        }

        protected override CreateParams CreateParams {
            get {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000; // WS_EX_COMPOSITED       
                return cp;
            }
        }

        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);
            if (BorderStyle == BorderStyle.FixedSingle) {
                using var pen = new Pen(BorderColor, 1);
                e.Graphics.DrawRectangle(pen,
                    ClientRectangle.Left, ClientRectangle.Top,
                    ClientRectangle.Width - 1, ClientRectangle.Height - 1);
            }
        }

        // Stolen from https://github.com/r-aghaei/FlatNumericUpDownExample/tree/master/FlatNumericUpDownExample
        private class UpDownButtonRenderer : NativeWindow {
            [DllImport("user32.dll", ExactSpelling = true, EntryPoint = "BeginPaint", CharSet = CharSet.Auto)]
            private static extern IntPtr IntBeginPaint(IntPtr hWnd, [In, Out] ref Paintstruct lpPaint);

            [StructLayout(LayoutKind.Sequential)]
            private readonly struct Paintstruct {
                public readonly IntPtr hdc;
                private readonly bool fErase;
                private readonly int rcPaint_left;
                private readonly int rcPaint_top;
                private readonly int rcPaint_right;
                private readonly int rcPaint_bottom;
                private readonly bool fRestore;
                private readonly bool fIncUpdate;
                private readonly int reserved1;
                private readonly int reserved2;
                private readonly int reserved3;
                private readonly int reserved4;
                private readonly int reserved5;
                private readonly int reserved6;
                private readonly int reserved7;
                private readonly int reserved8;
            }

            [DllImport("user32.dll", ExactSpelling = true, EntryPoint = "EndPaint", CharSet = CharSet.Auto)]
            private static extern bool IntEndPaint(IntPtr hWnd, ref Paintstruct lpPaint);

            readonly Control _updown;

            public UpDownButtonRenderer(Control c) {
                _updown = c;
                if (_updown.IsHandleCreated) {
                    AssignHandle(_updown.Handle);
                } else {
                    _updown.HandleCreated += (_, _) => AssignHandle(_updown.Handle);
                }
            }

            private static Point[] GetDownArrow(Rectangle r) {
                var middle = new Point(r.Left + r.Width / 2, r.Top + r.Height / 2);
                return new[] {
                    new(middle.X - 3, middle.Y - 2),
                    new(middle.X + 4, middle.Y - 2),
                    middle with { Y = middle.Y + 2 }
                };
            }

            private static Point[] GetUpArrow(Rectangle r) {
                var middle = new Point(r.Left + r.Width / 2, r.Top + r.Height / 2);
                return new[] {
                    new(middle.X - 4, middle.Y + 2),
                    new(middle.X + 4, middle.Y + 2),
                    middle with { Y = middle.Y - 3 }
                };
            }

            protected override void WndProc(ref Message m) {
                var iField = (IntegerField)_updown.Parent;
                if (m.Msg == 0xF /*WM_PAINT*/ &&
                    iField.FlatStyle == FlatStyle.Flat) {
                    var s = new Paintstruct();
                    IntBeginPaint(_updown.Handle, ref s);
                    using (var g = Graphics.FromHdc(s.hdc)) {
                        var enabled = _updown.Enabled;
                        using (var backBrush = new SolidBrush(enabled
                                   ? iField.BackColor
                                   : SystemColors.Control)) {
                            g.FillRectangle(backBrush, _updown.ClientRectangle);
                        }

                        var r1 = new Rectangle(0, 0, _updown.Width, _updown.Height / 2);
                        var r2 = new Rectangle(0, _updown.Height / 2, _updown.Width, _updown.Height / 2 + 1);
                        var p = _updown.PointToClient(MousePosition);
                        // Highlight when mouse on up or down button
                        if (enabled && _updown.ClientRectangle.Contains(p)) {
                            // Draw Background
                            using (var b = new SolidBrush(iField.ButtonHighlightColor)) {
                                g.FillRectangle(b, r1.Contains(p) ? r1 : r2);
                            }

                            // Draw Border
                            if (iField.BorderStyle == BorderStyle.FixedSingle) {
                                using var pen = new Pen(iField.BorderColor);
                                g.DrawLines(pen,
                                    new[] {
                                        new Point(0, 0), new Point(0, _updown.Height),
                                        new Point(0, _updown.Height / 2), new Point(_updown.Width, _updown.Height / 2)
                                    });
                            }
                        }

                        // Draw Arrows
                        using var brush = new SolidBrush(iField.ForeColor);
                        g.FillPolygon(brush, GetUpArrow(r1));
                        g.FillPolygon(brush, GetDownArrow(r2));
                    }

                    m.Result = (IntPtr)1;
                    base.WndProc(ref m);
                    IntEndPaint(_updown.Handle, ref s);
                } else if (m.Msg == 0x0014 /*WM_ERASEBKGND*/) {
                    using (var g = Graphics.FromHdcInternal(m.WParam)) {
                        g.FillRectangle(Brushes.White, _updown.ClientRectangle);
                    }
                    m.Result = (IntPtr)1;
                } else {
                    base.WndProc(ref m);
                }
            }
        }
    }
}