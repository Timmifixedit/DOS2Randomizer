
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
            this.ConfigNameLayout = new System.Windows.Forms.TableLayoutPanel();
            this.ConfigNameLabel = new System.Windows.Forms.Label();
            this.ConfigNameText = new System.Windows.Forms.TextBox();
            this.nChooseKLayout = new System.Windows.Forms.TableLayoutPanel();
            this.memSlots = new DOS2Randomizer.UI.LabeledValue();
            this.levelSpecific = new System.Windows.Forms.TabPage();
            this.levelSpecificPanel = new System.Windows.Forms.Panel();
            this.levelSpecificTable = new DOS2Randomizer.UI.LevelSpecificTable();
            this.spells = new System.Windows.Forms.TabPage();
            this.n = new DOS2Randomizer.UI.LabeledValue();
            this.k = new DOS2Randomizer.UI.LabeledValue();
            this.tabControl.SuspendLayout();
            this.general.SuspendLayout();
            this.generalLayout.SuspendLayout();
            this.generalSplitLayout.SuspendLayout();
            this.ConfigNameLayout.SuspendLayout();
            this.nChooseKLayout.SuspendLayout();
            this.levelSpecific.SuspendLayout();
            this.levelSpecificPanel.SuspendLayout();
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
            this.generalSplitLayout.Controls.Add(this.ConfigNameLayout, 0, 0);
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
            // ConfigNameLayout
            // 
            this.ConfigNameLayout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ConfigNameLayout.ColumnCount = 2;
            this.ConfigNameLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.66667F));
            this.ConfigNameLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58.33333F));
            this.ConfigNameLayout.Controls.Add(this.ConfigNameLabel, 0, 0);
            this.ConfigNameLayout.Controls.Add(this.ConfigNameText, 1, 0);
            this.ConfigNameLayout.Location = new System.Drawing.Point(3, 11);
            this.ConfigNameLayout.Name = "ConfigNameLayout";
            this.ConfigNameLayout.RowCount = 1;
            this.ConfigNameLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ConfigNameLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.ConfigNameLayout.Size = new System.Drawing.Size(551, 25);
            this.ConfigNameLayout.TabIndex = 2;
            // 
            // ConfigNameLabel
            // 
            this.ConfigNameLabel.AutoSize = true;
            this.ConfigNameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConfigNameLabel.Location = new System.Drawing.Point(3, 0);
            this.ConfigNameLabel.Name = "ConfigNameLabel";
            this.ConfigNameLabel.Size = new System.Drawing.Size(223, 25);
            this.ConfigNameLabel.TabIndex = 1;
            this.ConfigNameLabel.Text = "Configuration Name";
            this.ConfigNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ConfigNameText
            // 
            this.ConfigNameText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConfigNameText.Location = new System.Drawing.Point(232, 3);
            this.ConfigNameText.Name = "ConfigNameText";
            this.ConfigNameText.Size = new System.Drawing.Size(316, 23);
            this.ConfigNameText.TabIndex = 0;
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
            this.levelSpecific.Controls.Add(this.levelSpecificPanel);
            this.levelSpecific.Location = new System.Drawing.Point(4, 24);
            this.levelSpecific.Name = "levelSpecific";
            this.levelSpecific.Padding = new System.Windows.Forms.Padding(3);
            this.levelSpecific.Size = new System.Drawing.Size(792, 422);
            this.levelSpecific.TabIndex = 1;
            this.levelSpecific.Text = "Level Specific";
            this.levelSpecific.UseVisualStyleBackColor = true;
            // 
            // levelSpecificPanel
            // 
            this.levelSpecificPanel.Controls.Add(this.levelSpecificTable);
            this.levelSpecificPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.levelSpecificPanel.Location = new System.Drawing.Point(3, 3);
            this.levelSpecificPanel.Name = "levelSpecificPanel";
            this.levelSpecificPanel.Size = new System.Drawing.Size(460, 416);
            this.levelSpecificPanel.TabIndex = 1;
            // 
            // levelSpecificTable
            // 
            this.levelSpecificTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.levelSpecificTable.Location = new System.Drawing.Point(0, 0);
            this.levelSpecificTable.Name = "levelSpecificTable";
            this.levelSpecificTable.Size = new System.Drawing.Size(460, 416);
            this.levelSpecificTable.TabIndex = 0;
            // 
            // spells
            // 
            this.spells.Location = new System.Drawing.Point(4, 24);
            this.spells.Name = "spells";
            this.spells.Size = new System.Drawing.Size(792, 422);
            this.spells.TabIndex = 2;
            this.spells.Text = "Spells";
            this.spells.UseVisualStyleBackColor = true;
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
            this.ConfigNameLayout.ResumeLayout(false);
            this.ConfigNameLayout.PerformLayout();
            this.nChooseKLayout.ResumeLayout(false);
            this.levelSpecific.ResumeLayout(false);
            this.levelSpecificPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage general;
        private System.Windows.Forms.TabPage levelSpecific;
        private System.Windows.Forms.TabPage spells;
        private System.Windows.Forms.TextBox ConfigNameText;
        private System.Windows.Forms.TableLayoutPanel ConfigNameLayout;
        private System.Windows.Forms.Label ConfigNameLabel;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.TableLayoutPanel nChooseKLayout;
        private System.Windows.Forms.TableLayoutPanel generalLayout;
        private System.Windows.Forms.TableLayoutPanel generalSplitLayout;
        private LevelSpecificTable levelSpecificTable;
        private System.Windows.Forms.Panel levelSpecificPanel;
        private LabeledValue memSlots;
        private LabeledValue n;
        private LabeledValue k;
    }
}