using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DOS2Randomizer.UI.Components {
    public static class DrawUtils {
        public const int WM_PAINT = 0xF;
        public const int WM_ERASEBKGND = 0x0014;

        [DllImport("user32.dll", ExactSpelling = true, EntryPoint = "BeginPaint", CharSet = CharSet.Auto)]
        public static extern IntPtr IntBeginPaint(IntPtr hWnd, [In, Out] ref Paintstruct lpPaint);

        [DllImport("user32.dll", ExactSpelling = true, EntryPoint = "EndPaint", CharSet = CharSet.Auto)]
        public static extern bool IntEndPaint(IntPtr hWnd, ref Paintstruct lpPaint);

        [DllImport("gdi32.dll")]
        public static extern int SelectClipRgn(IntPtr hDC, IntPtr hRgn);

        [DllImport("gdi32.dll")]
        internal static extern bool DeleteObject(IntPtr hObject);

        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateRectRgn(int x1, int y1, int x2, int y2);

        [StructLayout(LayoutKind.Sequential)]
        public readonly struct Paintstruct {
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

        public static Point[] GetDownArrow(Rectangle r) {
            var middle = new Point(r.Left + r.Width / 2, r.Top + r.Height / 2);
            return new[] {
                new(middle.X - 3, middle.Y - 2),
                new(middle.X + 4, middle.Y - 2),
                middle with { Y = middle.Y + 2 }
            };
        }

        public static Point[] GetUpArrow(Rectangle r) {
            var middle = new Point(r.Left + r.Width / 2, r.Top + r.Height / 2);
            return new[] {
                new(middle.X - 4, middle.Y + 2),
                new(middle.X + 4, middle.Y + 2),
                middle with { Y = middle.Y - 3 }
            };
        }
    }
}