
namespace DOS2Randomizer.UI {
    partial class SearchableSpellList {
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
            this.layout = new System.Windows.Forms.TableLayoutPanel();
            this.search = new DOS2Randomizer.UI.SpellSearch();
            this.spellList = new DOS2Randomizer.UI.SpellList();
            this.layout.SuspendLayout();
            this.SuspendLayout();
            // 
            // layout
            // 
            this.layout.ColumnCount = 2;
            this.layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.77698F));
            this.layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 71.22302F));
            this.layout.Controls.Add(this.search, 0, 0);
            this.layout.Controls.Add(this.spellList, 1, 0);
            this.layout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layout.Location = new System.Drawing.Point(0, 0);
            this.layout.Name = "layout";
            this.layout.RowCount = 1;
            this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layout.Size = new System.Drawing.Size(644, 154);
            this.layout.TabIndex = 0;
            // 
            // search
            // 
            this.search.AllSpells = null;
            this.search.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.search.CaseSensitive = false;
            this.search.Label = "Search";
            this.search.Location = new System.Drawing.Point(3, 45);
            this.search.ManagedCollection = this.spellList;
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(179, 64);
            this.search.SplitPercentage = 35;
            this.search.TabIndex = 0;
            this.search.Value = "";
            // 
            // spellList
            // 
            this.spellList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.spellList.Location = new System.Drawing.Point(188, 6);
            this.spellList.Name = "spellList";
            this.spellList.Size = new System.Drawing.Size(453, 141);
            this.spellList.SpellCollection = null;
            this.spellList.Spells = null;
            this.spellList.TabIndex = 1;
            // 
            // SearchableSpellList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layout);
            this.Name = "SearchableSpellList";
            this.Size = new System.Drawing.Size(644, 154);
            this.layout.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel layout;
        private SpellSearch search;
        private SpellList spellList;
    }
}
