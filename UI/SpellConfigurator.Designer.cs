
namespace DOS2Randomizer.UI {
    partial class SpellConfigurator {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SpellConfigurator));
            this.import = new System.Windows.Forms.Button();
            this.save = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.create = new System.Windows.Forms.Button();
            this.searchLayout = new System.Windows.Forms.TableLayoutPanel();
            this.searchDeleteLayout = new System.Windows.Forms.TableLayoutPanel();
            this.remove = new System.Windows.Forms.Button();
            this.search = new DOS2Randomizer.UI.SpellSearch();
            this.spellList = new DOS2Randomizer.UI.SpellList();
            this.add = new System.Windows.Forms.Button();
            this.mainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.spellDesignPanel = new DOS2Randomizer.UI.SpellDesignPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.searchLayout.SuspendLayout();
            this.searchDeleteLayout.SuspendLayout();
            this.mainLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // import
            // 
            this.import.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.import.Location = new System.Drawing.Point(77, 50);
            this.import.Name = "import";
            this.import.Size = new System.Drawing.Size(75, 23);
            this.import.TabIndex = 0;
            this.import.Text = "Import";
            this.import.UseVisualStyleBackColor = true;
            this.import.Click += new System.EventHandler(this.import_Click);
            // 
            // save
            // 
            this.save.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.save.Location = new System.Drawing.Point(77, 91);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(75, 23);
            this.save.TabIndex = 3;
            this.save.Text = "Save";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.40302F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 79.59698F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.searchLayout, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(794, 139);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.import, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.save, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.create, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 8);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(155, 123);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // create
            // 
            this.create.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.create.Location = new System.Drawing.Point(77, 9);
            this.create.Name = "create";
            this.create.Size = new System.Drawing.Size(75, 23);
            this.create.TabIndex = 4;
            this.create.Text = "Create";
            this.create.UseVisualStyleBackColor = true;
            this.create.Click += new System.EventHandler(this.create_Click);
            // 
            // searchLayout
            // 
            this.searchLayout.ColumnCount = 2;
            this.searchLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.43222F));
            this.searchLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 72.56778F));
            this.searchLayout.Controls.Add(this.searchDeleteLayout, 0, 0);
            this.searchLayout.Controls.Add(this.spellList, 1, 0);
            this.searchLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchLayout.Location = new System.Drawing.Point(164, 3);
            this.searchLayout.Name = "searchLayout";
            this.searchLayout.RowCount = 1;
            this.searchLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.searchLayout.Size = new System.Drawing.Size(627, 133);
            this.searchLayout.TabIndex = 6;
            // 
            // searchDeleteLayout
            // 
            this.searchDeleteLayout.ColumnCount = 1;
            this.searchDeleteLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.searchDeleteLayout.Controls.Add(this.remove, 0, 0);
            this.searchDeleteLayout.Controls.Add(this.search, 0, 2);
            this.searchDeleteLayout.Controls.Add(this.add, 0, 1);
            this.searchDeleteLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchDeleteLayout.Location = new System.Drawing.Point(3, 3);
            this.searchDeleteLayout.Name = "searchDeleteLayout";
            this.searchDeleteLayout.RowCount = 3;
            this.searchDeleteLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.searchDeleteLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.searchDeleteLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.searchDeleteLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.searchDeleteLayout.Size = new System.Drawing.Size(166, 127);
            this.searchDeleteLayout.TabIndex = 0;
            // 
            // remove
            // 
            this.remove.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.remove.Location = new System.Drawing.Point(55, 9);
            this.remove.Name = "remove";
            this.remove.Size = new System.Drawing.Size(108, 23);
            this.remove.TabIndex = 0;
            this.remove.Text = "Remove Spell";
            this.remove.UseVisualStyleBackColor = true;
            this.remove.Click += new System.EventHandler(this.remove_Click);
            // 
            // search
            // 
            this.search.AllSpells = null;
            this.search.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.search.CaseSensitive = false;
            this.search.Label = "Search";
            this.search.Location = new System.Drawing.Point(3, 90);
            this.search.ManagedCollection = this.spellList;
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(160, 30);
            this.search.SplitPercentage = 30;
            this.search.TabIndex = 7;
            this.search.Value = "";
            // 
            // spellList
            // 
            this.spellList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.spellList.Location = new System.Drawing.Point(175, 3);
            this.spellList.Name = "spellList";
            this.spellList.Size = new System.Drawing.Size(449, 127);
            this.spellList.Spells = null;
            this.spellList.TabIndex = 1;
            // 
            // add
            // 
            this.add.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.add.Location = new System.Drawing.Point(55, 51);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(108, 23);
            this.add.TabIndex = 8;
            this.add.Text = "Add Spell";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // mainLayout
            // 
            this.mainLayout.ColumnCount = 1;
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayout.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.mainLayout.Controls.Add(this.spellDesignPanel, 0, 1);
            this.mainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLayout.Location = new System.Drawing.Point(0, 0);
            this.mainLayout.Name = "mainLayout";
            this.mainLayout.RowCount = 2;
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 32.22222F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 67.77778F));
            this.mainLayout.Size = new System.Drawing.Size(800, 450);
            this.mainLayout.TabIndex = 6;
            // 
            // spellDesignPanel
            // 
            this.spellDesignPanel.AllSpells = null;
            this.spellDesignPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spellDesignPanel.Location = new System.Drawing.Point(3, 148);
            this.spellDesignPanel.Name = "spellDesignPanel";
            this.spellDesignPanel.Size = new System.Drawing.Size(794, 299);
            this.spellDesignPanel.Spell = null;
            this.spellDesignPanel.TabIndex = 6;
            // 
            // SpellConfigurator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mainLayout);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SpellConfigurator";
            this.Text = "Spell Configurator";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.searchLayout.ResumeLayout(false);
            this.searchDeleteLayout.ResumeLayout(false);
            this.mainLayout.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button import;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel mainLayout;
        private SpellDesignPanel spellDesignPanel;
        private System.Windows.Forms.Button create;
        private System.Windows.Forms.TableLayoutPanel searchLayout;
        private System.Windows.Forms.TableLayoutPanel searchDeleteLayout;
        private SpellList spellList;
        private System.Windows.Forms.Button remove;
        private SpellSearch search;
        private System.Windows.Forms.Button add;
    }
}