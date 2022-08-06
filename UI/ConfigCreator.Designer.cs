﻿
namespace DOS2Randomizer.UI {
    partial class ConfigCreator {
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.general = new System.Windows.Forms.TabPage();
            this.generalLayout = new System.Windows.Forms.TableLayoutPanel();
            this.generalSplitLayout = new System.Windows.Forms.TableLayoutPanel();
            this.SaveButton = new System.Windows.Forms.Button();
            this.configName = new DOS2Randomizer.UI.LabeledString();
            this.nChooseKLayout = new System.Windows.Forms.TableLayoutPanel();
            this.n = new DOS2Randomizer.UI.LabeledValue();
            this.k = new DOS2Randomizer.UI.LabeledValue();
            this.memSlots = new DOS2Randomizer.UI.LabeledValue();
            this.levelSpecific = new System.Windows.Forms.TabPage();
            this.levelSpecificTable = new DOS2Randomizer.UI.LevelSpecificTable();
            this.spells = new System.Windows.Forms.TabPage();
            this.spellMainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.spellListLayout = new System.Windows.Forms.TableLayoutPanel();
            this.spellList = new DOS2Randomizer.UI.SpellList();
            this.spellSearchLayout = new System.Windows.Forms.TableLayoutPanel();
            this.import = new System.Windows.Forms.Button();
            this.spellSearch = new DOS2Randomizer.UI.SpellSearch();
            this.spellDesignPanel1 = new DOS2Randomizer.UI.SpellDesignPanel();
            this.tabControl.SuspendLayout();
            this.general.SuspendLayout();
            this.generalLayout.SuspendLayout();
            this.generalSplitLayout.SuspendLayout();
            this.nChooseKLayout.SuspendLayout();
            this.levelSpecific.SuspendLayout();
            this.spells.SuspendLayout();
            this.spellMainLayout.SuspendLayout();
            this.spellListLayout.SuspendLayout();
            this.spellSearchLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.general);
            this.tabControl.Controls.Add(this.levelSpecific);
            this.tabControl.Controls.Add(this.spells);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(800, 450);
            this.tabControl.TabIndex = 0;
            // 
            // general
            // 
            this.general.Controls.Add(this.generalLayout);
            this.general.Location = new System.Drawing.Point(4, 24);
            this.general.Name = "general";
            this.general.Padding = new System.Windows.Forms.Padding(3);
            this.general.Size = new System.Drawing.Size(792, 422);
            this.general.TabIndex = 0;
            this.general.Text = "General";
            this.general.UseVisualStyleBackColor = true;
            // 
            // generalLayout
            // 
            this.generalLayout.ColumnCount = 1;
            this.generalLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.generalLayout.Controls.Add(this.generalSplitLayout, 0, 0);
            this.generalLayout.Controls.Add(this.nChooseKLayout, 0, 2);
            this.generalLayout.Controls.Add(this.memSlots, 0, 1);
            this.generalLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.generalLayout.Location = new System.Drawing.Point(3, 3);
            this.generalLayout.Name = "generalLayout";
            this.generalLayout.RowCount = 3;
            this.generalLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.04348F));
            this.generalLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 43.47826F));
            this.generalLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 43.47826F));
            this.generalLayout.Size = new System.Drawing.Size(786, 416);
            this.generalLayout.TabIndex = 9;
            // 
            // generalSplitLayout
            // 
            this.generalSplitLayout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.generalSplitLayout.ColumnCount = 2;
            this.generalSplitLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 71.42857F));
            this.generalSplitLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.57143F));
            this.generalSplitLayout.Controls.Add(this.SaveButton, 1, 0);
            this.generalSplitLayout.Controls.Add(this.configName, 0, 0);
            this.generalSplitLayout.Location = new System.Drawing.Point(3, 3);
            this.generalSplitLayout.Name = "generalSplitLayout";
            this.generalSplitLayout.RowCount = 1;
            this.generalSplitLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.generalSplitLayout.Size = new System.Drawing.Size(780, 48);
            this.generalSplitLayout.TabIndex = 10;
            // 
            // SaveButton
            // 
            this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveButton.Location = new System.Drawing.Point(560, 12);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(217, 23);
            this.SaveButton.TabIndex = 3;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // configName
            // 
            this.configName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.configName.Label = "Configuration Name";
            this.configName.Location = new System.Drawing.Point(3, 3);
            this.configName.Name = "configName";
            this.configName.Size = new System.Drawing.Size(551, 42);
            this.configName.SplitPercentage = 40;
            this.configName.TabIndex = 4;
            this.configName.Value = "";
            // 
            // nChooseKLayout
            // 
            this.nChooseKLayout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.nChooseKLayout.ColumnCount = 2;
            this.nChooseKLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.nChooseKLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.nChooseKLayout.Controls.Add(this.n, 0, 0);
            this.nChooseKLayout.Controls.Add(this.k, 1, 0);
            this.nChooseKLayout.Location = new System.Drawing.Point(3, 308);
            this.nChooseKLayout.Name = "nChooseKLayout";
            this.nChooseKLayout.RowCount = 1;
            this.nChooseKLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.nChooseKLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.nChooseKLayout.Size = new System.Drawing.Size(780, 33);
            this.nChooseKLayout.TabIndex = 8;
            // 
            // n
            // 
            this.n.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.n.Label = "From";
            this.n.Location = new System.Drawing.Point(237, 3);
            this.n.Max = 100;
            this.n.Min = 0;
            this.n.Name = "n";
            this.n.Size = new System.Drawing.Size(150, 27);
            this.n.SplitPercentage = 71;
            this.n.TabIndex = 0;
            this.n.Value = 0;
            // 
            // k
            // 
            this.k.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.k.Label = "spells choose";
            this.k.Location = new System.Drawing.Point(393, 3);
            this.k.Max = 100;
            this.k.Min = 0;
            this.k.Name = "k";
            this.k.Size = new System.Drawing.Size(150, 27);
            this.k.SplitPercentage = 71;
            this.k.TabIndex = 1;
            this.k.Value = 0;
            // 
            // memSlots
            // 
            this.memSlots.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.memSlots.Label = "Maximum number of memory slots";
            this.memSlots.Location = new System.Drawing.Point(3, 69);
            this.memSlots.Max = 100;
            this.memSlots.Min = 0;
            this.memSlots.Name = "memSlots";
            this.memSlots.Size = new System.Drawing.Size(780, 150);
            this.memSlots.SplitPercentage = 50;
            this.memSlots.TabIndex = 11;
            this.memSlots.Value = 0;
            // 
            // levelSpecific
            // 
            this.levelSpecific.Controls.Add(this.levelSpecificTable);
            this.levelSpecific.Location = new System.Drawing.Point(4, 24);
            this.levelSpecific.Name = "levelSpecific";
            this.levelSpecific.Padding = new System.Windows.Forms.Padding(3);
            this.levelSpecific.Size = new System.Drawing.Size(792, 422);
            this.levelSpecific.TabIndex = 1;
            this.levelSpecific.Text = "Level Specific";
            this.levelSpecific.UseVisualStyleBackColor = true;
            // 
            // levelSpecificTable
            // 
            this.levelSpecificTable.Location = new System.Drawing.Point(3, 3);
            this.levelSpecificTable.Name = "levelSpecificTable";
            this.levelSpecificTable.Size = new System.Drawing.Size(460, 416);
            this.levelSpecificTable.TabIndex = 0;
            // 
            // spells
            // 
            this.spells.Controls.Add(this.spellMainLayout);
            this.spells.Location = new System.Drawing.Point(4, 24);
            this.spells.Name = "spells";
            this.spells.Size = new System.Drawing.Size(792, 422);
            this.spells.TabIndex = 2;
            this.spells.Text = "Spells";
            this.spells.UseVisualStyleBackColor = true;
            // 
            // spellMainLayout
            // 
            this.spellMainLayout.ColumnCount = 1;
            this.spellMainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.spellMainLayout.Controls.Add(this.spellListLayout, 0, 0);
            this.spellMainLayout.Controls.Add(this.spellDesignPanel1, 0, 1);
            this.spellMainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spellMainLayout.Location = new System.Drawing.Point(0, 0);
            this.spellMainLayout.Name = "spellMainLayout";
            this.spellMainLayout.RowCount = 2;
            this.spellMainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.09479F));
            this.spellMainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 69.90521F));
            this.spellMainLayout.Size = new System.Drawing.Size(792, 422);
            this.spellMainLayout.TabIndex = 2;
            // 
            // spellListLayout
            // 
            this.spellListLayout.ColumnCount = 2;
            this.spellListLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.80083F));
            this.spellListLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 72.19917F));
            this.spellListLayout.Controls.Add(this.spellList, 1, 0);
            this.spellListLayout.Controls.Add(this.spellSearchLayout, 0, 0);
            this.spellListLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spellListLayout.Location = new System.Drawing.Point(3, 3);
            this.spellListLayout.Name = "spellListLayout";
            this.spellListLayout.RowCount = 1;
            this.spellListLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.spellListLayout.Size = new System.Drawing.Size(786, 121);
            this.spellListLayout.TabIndex = 0;
            // 
            // spellList
            // 
            this.spellList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.spellList.Location = new System.Drawing.Point(221, 3);
            this.spellList.Name = "spellList";
            this.spellList.Size = new System.Drawing.Size(562, 115);
            this.spellList.SpellCollection = null;
            this.spellList.Spells = null;
            this.spellList.TabIndex = 0;
            // 
            // spellSearchLayout
            // 
            this.spellSearchLayout.ColumnCount = 1;
            this.spellSearchLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.spellSearchLayout.Controls.Add(this.import, 0, 0);
            this.spellSearchLayout.Controls.Add(this.spellSearch, 0, 1);
            this.spellSearchLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spellSearchLayout.Location = new System.Drawing.Point(3, 3);
            this.spellSearchLayout.Name = "spellSearchLayout";
            this.spellSearchLayout.RowCount = 2;
            this.spellSearchLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.spellSearchLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.spellSearchLayout.Size = new System.Drawing.Size(212, 115);
            this.spellSearchLayout.TabIndex = 1;
            // 
            // import
            // 
            this.import.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.import.Location = new System.Drawing.Point(134, 17);
            this.import.Name = "import";
            this.import.Size = new System.Drawing.Size(75, 23);
            this.import.TabIndex = 1;
            this.import.Text = "Import";
            this.import.UseVisualStyleBackColor = true;
            this.import.Click += new System.EventHandler(this.import_Click);
            // 
            // spellSearch
            // 
            this.spellSearch.AllSpells = null;
            this.spellSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.spellSearch.CaseSensitive = true;
            this.spellSearch.Label = "Search";
            this.spellSearch.Location = new System.Drawing.Point(3, 60);
            this.spellSearch.ManagedCollection = this.spellList;
            this.spellSearch.Name = "spellSearch";
            this.spellSearch.Size = new System.Drawing.Size(206, 52);
            this.spellSearch.SplitPercentage = 30;
            this.spellSearch.TabIndex = 2;
            this.spellSearch.Value = "";
            // 
            // spellDesignPanel1
            // 
            this.spellDesignPanel1.AllSpells = null;
            this.spellDesignPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spellDesignPanel1.Location = new System.Drawing.Point(3, 130);
            this.spellDesignPanel1.Name = "spellDesignPanel1";
            this.spellDesignPanel1.Size = new System.Drawing.Size(786, 289);
            this.spellDesignPanel1.Spell = null;
            this.spellDesignPanel1.TabIndex = 1;
            // 
            // ConfigCreator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl);
            this.Name = "ConfigCreator";
            this.Text = "Create Match Config";
            this.tabControl.ResumeLayout(false);
            this.general.ResumeLayout(false);
            this.generalLayout.ResumeLayout(false);
            this.generalSplitLayout.ResumeLayout(false);
            this.nChooseKLayout.ResumeLayout(false);
            this.levelSpecific.ResumeLayout(false);
            this.spells.ResumeLayout(false);
            this.spellMainLayout.ResumeLayout(false);
            this.spellListLayout.ResumeLayout(false);
            this.spellSearchLayout.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage general;
        private System.Windows.Forms.TabPage levelSpecific;
        private System.Windows.Forms.TabPage spells;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.TableLayoutPanel nChooseKLayout;
        private System.Windows.Forms.TableLayoutPanel generalLayout;
        private System.Windows.Forms.TableLayoutPanel generalSplitLayout;
        private LabeledValue memSlots;
        private LabeledValue n;
        private LabeledValue k;
        private LabeledString configName;
        private SpellList spellList;
        private System.Windows.Forms.Button import;
        private System.Windows.Forms.TableLayoutPanel spellMainLayout;
        private System.Windows.Forms.TableLayoutPanel spellListLayout;
        private SpellDesignPanel spellDesignPanel1;
        private System.Windows.Forms.TableLayoutPanel spellSearchLayout;
        private SpellSearch spellSearch;
        private LevelSpecificTable levelSpecificTable;
    }
}