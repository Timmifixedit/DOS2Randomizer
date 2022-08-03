
namespace DOS2Randomizer.UI {
    partial class SpellDesignPanel {
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
            this.level = new DOS2Randomizer.UI.LabeledValue();
            this.SuspendLayout();
            // 
            // level
            // 
            this.level.Label = "Level";
            this.level.Location = new System.Drawing.Point(92, 42);
            this.level.Name = "level";
            this.level.Size = new System.Drawing.Size(150, 150);
            this.level.SplitPercentage = 50;
            this.level.TabIndex = 0;
            // 
            // SpellDesignPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.level);
            this.Name = "SpellDesignPanel";
            this.Size = new System.Drawing.Size(505, 243);
            this.ResumeLayout(false);

        }

        #endregion

        private LabeledValue level;
    }
}
