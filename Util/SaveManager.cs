using System.Windows.Forms;

namespace DOS2Randomizer.Util {
    /// <summary>
    /// Manages a default save path or can query the user for a new save path
    /// </summary>
    internal class SaveManager {
        private string? _path;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="path">default path</param>
        public SaveManager(string? path = null) {
            _path = path;
        }

        /// <summary>
        /// Query the user for a new destination path and set it as default path
        /// </summary>
        /// <returns>path specified by the user or null if aborted</returns>
        public string? GetNewPath() {
            using var fileChooser = new SaveFileDialog {AddExtension = true, DefaultExt = Resources.Misc.JsonExtension};
            if (fileChooser.ShowDialog() == DialogResult.OK) {
                _path = fileChooser.FileName;
                return fileChooser.FileName;
            }

            return null;
        }

        /// <summary>
        /// Gets or sets the default save path. If default path is not, queries user for new path
        /// </summary>
        /// <see cref="GetNewPath"/>
        public string? Path {
            get {
                if (_path is not null) {
                    return _path;
                }

                return GetNewPath();
            }
            set => _path = value;
        }
    }
}
