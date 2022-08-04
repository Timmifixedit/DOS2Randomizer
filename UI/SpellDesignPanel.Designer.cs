﻿
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
            this.name = new DOS2Randomizer.UI.LabeledString();
            this.schoolBox = new DOS2Randomizer.UI.LabeledSchoolType();
            this.attributeBox = new DOS2Randomizer.UI.LabeledAttribute();
            this.typeSelection = new DOS2Randomizer.UI.LabeledSpellTypeSelection();
            this.dependencies = new DOS2Randomizer.UI.LabeledSpellSelection();
            this.mainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.memSlots = new DOS2Randomizer.UI.LabeledValue();
            this.flowLayoutSelections = new System.Windows.Forms.FlowLayoutPanel();
            this.mainLayout.SuspendLayout();
            this.flowLayout.SuspendLayout();
            this.flowLayoutSelections.SuspendLayout();
            this.SuspendLayout();
            // 
            // level
            // 
            this.level.Label = "Level";
            this.level.Location = new System.Drawing.Point(3, 39);
            this.level.Max = 20;
            this.level.Min = 1;
            this.level.Name = "level";
            this.level.Size = new System.Drawing.Size(191, 30);
            this.level.SplitPercentage = 50;
            this.level.TabIndex = 0;
            this.level.Value = 1;
            // 
            // name
            // 
            this.name.Label = "Spell name";
            this.name.Location = new System.Drawing.Point(3, 3);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(191, 30);
            this.name.SplitPercentage = 40;
            this.name.TabIndex = 1;
            this.name.Value = "";
            // 
            // schoolBox
            // 
            this.schoolBox.Label = "School";
            this.schoolBox.Location = new System.Drawing.Point(3, 75);
            this.schoolBox.Name = "schoolBox";
            this.schoolBox.Size = new System.Drawing.Size(191, 30);
            this.schoolBox.SplitPercentage = 50;
            this.schoolBox.TabIndex = 2;
            this.schoolBox.Value = DOS2Randomizer.DataStructures.Spell.School.Aero;
            // 
            // attributeBox
            // 
            this.attributeBox.Label = "Scales with";
            this.attributeBox.Location = new System.Drawing.Point(3, 111);
            this.attributeBox.Name = "attributeBox";
            this.attributeBox.Size = new System.Drawing.Size(191, 30);
            this.attributeBox.SplitPercentage = 50;
            this.attributeBox.TabIndex = 3;
            this.attributeBox.Value = DOS2Randomizer.DataStructures.Attribute.Strength;
            // 
            // typeSelection
            // 
            this.typeSelection.Data = null;
            this.typeSelection.DisplayMember = null;
            this.typeSelection.Label = "Type(s)";
            this.typeSelection.Location = new System.Drawing.Point(3, 3);
            this.typeSelection.Name = "typeSelection";
            this.typeSelection.Size = new System.Drawing.Size(158, 150);
            this.typeSelection.SplitPercentage = 35;
            this.typeSelection.TabIndex = 4;
            this.typeSelection.Value = new DOS2Randomizer.DataStructures.Spell.Type[0];
            // 
            // dependencies
            // 
            this.dependencies.Data = null;
            this.dependencies.DisplayMember = "Name";
            this.dependencies.Label = "Dependencies";
            this.dependencies.Location = new System.Drawing.Point(167, 3);
            this.dependencies.Name = "dependencies";
            this.dependencies.Size = new System.Drawing.Size(224, 150);
            this.dependencies.SplitPercentage = 40;
            this.dependencies.TabIndex = 5;
            this.dependencies.Value = new DOS2Randomizer.DataStructures.Spell[0];
            // 
            // mainLayout
            // 
            this.mainLayout.ColumnCount = 2;
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.66667F));
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58.33333F));
            this.mainLayout.Controls.Add(this.flowLayout, 0, 0);
            this.mainLayout.Controls.Add(this.flowLayoutSelections, 1, 0);
            this.mainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLayout.Location = new System.Drawing.Point(0, 0);
            this.mainLayout.Name = "mainLayout";
            this.mainLayout.RowCount = 1;
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayout.Size = new System.Drawing.Size(699, 218);
            this.mainLayout.TabIndex = 6;
            // 
            // flowLayout
            // 
            this.flowLayout.Controls.Add(this.name);
            this.flowLayout.Controls.Add(this.level);
            this.flowLayout.Controls.Add(this.schoolBox);
            this.flowLayout.Controls.Add(this.attributeBox);
            this.flowLayout.Controls.Add(this.memSlots);
            this.flowLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayout.Location = new System.Drawing.Point(3, 3);
            this.flowLayout.Name = "flowLayout";
            this.flowLayout.Size = new System.Drawing.Size(285, 212);
            this.flowLayout.TabIndex = 0;
            // 
            // memSlots
            // 
            this.memSlots.Label = "Memory Slots";
            this.memSlots.Location = new System.Drawing.Point(3, 147);
            this.memSlots.Max = 3;
            this.memSlots.Min = 1;
            this.memSlots.Name = "memSlots";
            this.memSlots.Size = new System.Drawing.Size(191, 30);
            this.memSlots.SplitPercentage = 50;
            this.memSlots.TabIndex = 4;
            this.memSlots.Value = 1;
            // 
            // flowLayoutSelections
            // 
            this.flowLayoutSelections.Controls.Add(this.typeSelection);
            this.flowLayoutSelections.Controls.Add(this.dependencies);
            this.flowLayoutSelections.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutSelections.Location = new System.Drawing.Point(294, 3);
            this.flowLayoutSelections.Name = "flowLayoutSelections";
            this.flowLayoutSelections.Size = new System.Drawing.Size(402, 212);
            this.flowLayoutSelections.TabIndex = 1;
            // 
            // SpellDesignPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainLayout);
            this.Name = "SpellDesignPanel";
            this.Size = new System.Drawing.Size(699, 218);
            this.mainLayout.ResumeLayout(false);
            this.flowLayout.ResumeLayout(false);
            this.flowLayoutSelections.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private LabeledValue level;
        private LabeledString name;
        private LabeledSchoolType schoolBox;
        private LabeledAttribute attributeBox;
        private LabeledSpellTypeSelection typeSelection;
        private LabeledSpellSelection dependencies;
        private System.Windows.Forms.TableLayoutPanel mainLayout;
        private System.Windows.Forms.FlowLayoutPanel flowLayout;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutSelections;
        private LabeledValue memSlots;
    }
}