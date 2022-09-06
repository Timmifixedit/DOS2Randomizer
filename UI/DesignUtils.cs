using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DOS2Randomizer.UI {
    /// <summary>
    /// Scary stackoverflow hack to enable dark mode title bar because apparently things are supposed to be complicated
    /// </summary>
    internal static class DarkModeHax {
        // stolen from https://stackoverflow.com/questions/57124243/winforms-dark-title-bar-on-windows-10

        [DllImport("dwmapi.dll")]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

        private const int DWMWA_USE_IMMERSIVE_DARK_MODE_BEFORE_20H1 = 19;
        private const int DWMWA_USE_IMMERSIVE_DARK_MODE = 20;

        public static bool UseImmersiveDarkMode(IntPtr handle, bool enabled) {
            if (IsWindows10OrGreater(17763)) {
                var attribute = DWMWA_USE_IMMERSIVE_DARK_MODE_BEFORE_20H1;
                if (IsWindows10OrGreater(18985)) {
                    attribute = DWMWA_USE_IMMERSIVE_DARK_MODE;
                }

                int useImmersiveDarkMode = enabled ? 1 : 0;
                return DwmSetWindowAttribute(handle, (int)attribute, ref useImmersiveDarkMode, sizeof(int)) == 0;
            }

            return false;
        }

        private static bool IsWindows10OrGreater(int build = -1) {
            return Environment.OSVersion.Version.Major >= 10 && Environment.OSVersion.Version.Build >= build;
        }
    }

    public class Design {
        private static Design? _dark;
        private static Design? _light;

        private Design(DesignType type) {
            switch (type) {
                case DesignType.Dark:
                    BackColor = Color.FromArgb(32, 32, 32);
                    ControlColor = SystemColors.ControlDarkDark;
                    FlatButtonAppearance = new Button().FlatAppearance;
                    FlatButtonAppearance.BorderSize = 0;
                    FlatButtonAppearance.MouseOverBackColor = Color.FromArgb(255, 128, 0);
                    FlatStyle = FlatStyle.Flat;
                    BorderStyle = BorderStyle.None;
                    TextColor = Color.White;
                    EditBackColor = ControlColor;
                    break;
                case DesignType.Light:
                    BackColor = SystemColors.Control;
                    ControlColor = SystemColors.ControlLight;
                    FlatButtonAppearance = new Button{UseVisualStyleBackColor = true}.FlatAppearance;
                    FlatStyle = FlatStyle.Standard;
                    BorderStyle = BorderStyle.Fixed3D;
                    TextColor = Color.Black;
                    EditBackColor = Color.White;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        public static Design Get(DesignType type) {
            switch (type) {
                case DesignType.Dark:
                    _dark ??= new Design(DesignType.Dark);
                    return _dark;
                case DesignType.Light:
                    _light ??= new Design(DesignType.Light);
                    return _light;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        public Color BackColor { get; }
        public Color ControlColor { get; }
        public Color TextColor { get; }
        public Color EditBackColor { get; }
        public BorderStyle BorderStyle { get; }
        public FlatStyle FlatStyle { get; }
        public FlatButtonAppearance FlatButtonAppearance { get; }
    }

    public enum DesignType {
        Dark,
        Light
    }

    public interface IChoosableDesign {
        public DesignType Design { get; set; }
    }
}