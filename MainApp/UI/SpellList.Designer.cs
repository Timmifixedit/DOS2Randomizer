
namespace DOS2Randomizer.UI {
    partial class SpellListBase<T> {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent() {
            this.layout = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // layout
            // 
            this.layout.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.layout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layout.HideSelection = false;
            this.layout.Location = new System.Drawing.Point(0, 0);
            this.layout.MultiSelect = false;
            this.layout.Name = "layout";
            this.layout.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.layout.Size = new System.Drawing.Size(405, 208);
            this.layout.TabIndex = 0;
            this.layout.UseCompatibleStateImageBehavior = false;
            // 
            // SpellList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layout);
            this.Name = "SpellList";
            this.Size = new System.Drawing.Size(405, 208);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView layout;
    }
}
