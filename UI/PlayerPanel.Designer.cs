
namespace DOS2Randomizer.UI {
    partial class PlayerPanel {
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
            this.playerName = new DOS2Randomizer.UI.LabeledString();
            this.playerLevel = new DOS2Randomizer.UI.LabeledValue();
            this.skillPointsPanel1 = new DOS2Randomizer.UI.SkillPointsPanel();
            this.attributePointsPanel1 = new DOS2Randomizer.UI.AttributePointsPanel();
            this.knownSpellList = new DOS2Randomizer.UI.SearchableSpellList();
            this.equippedSpellList = new DOS2Randomizer.UI.SearchableSpellList();
            this.possibleSkillTypes = new DOS2Randomizer.UI.LabeledSkillTypeSelection();
            this.remove = new System.Windows.Forms.Button();
            this.addSpells = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // playerName
            // 
            this.playerName.Label = "Player Name";
            this.playerName.Location = new System.Drawing.Point(3, 3);
            this.playerName.Name = "playerName";
            this.playerName.Size = new System.Drawing.Size(234, 23);
            this.playerName.SplitPercentage = 40;
            this.playerName.TabIndex = 0;
            this.playerName.Value = "";
            // 
            // playerLevel
            // 
            this.playerLevel.Label = "Player Level";
            this.playerLevel.Location = new System.Drawing.Point(3, 32);
            this.playerLevel.Max = 100;
            this.playerLevel.Min = 0;
            this.playerLevel.Name = "playerLevel";
            this.playerLevel.Size = new System.Drawing.Size(234, 23);
            this.playerLevel.SplitPercentage = 80;
            this.playerLevel.TabIndex = 1;
            this.playerLevel.Value = 0;
            // 
            // skillPointsPanel1
            // 
            this.skillPointsPanel1.Location = new System.Drawing.Point(3, 61);
            this.skillPointsPanel1.Name = "skillPointsPanel1";
            this.skillPointsPanel1.Size = new System.Drawing.Size(150, 330);
            this.skillPointsPanel1.TabIndex = 2;
            // 
            // attributePointsPanel1
            // 
            this.attributePointsPanel1.Location = new System.Drawing.Point(243, 130);
            this.attributePointsPanel1.Name = "attributePointsPanel1";
            this.attributePointsPanel1.Size = new System.Drawing.Size(150, 261);
            this.attributePointsPanel1.TabIndex = 4;
            // 
            // knownSpellList
            // 
            this.knownSpellList.Label = "Known Spells";
            this.knownSpellList.Location = new System.Drawing.Point(0, 397);
            this.knownSpellList.Name = "knownSpellList";
            this.knownSpellList.Size = new System.Drawing.Size(620, 123);
            this.knownSpellList.SpellCollection = null;
            this.knownSpellList.Spells = null;
            this.knownSpellList.SplitPercentage = 29;
            this.knownSpellList.TabIndex = 5;
            // 
            // equippedSpellList
            // 
            this.equippedSpellList.Label = "Equipped Spells";
            this.equippedSpellList.Location = new System.Drawing.Point(0, 526);
            this.equippedSpellList.Name = "equippedSpellList";
            this.equippedSpellList.Size = new System.Drawing.Size(620, 123);
            this.equippedSpellList.SpellCollection = null;
            this.equippedSpellList.Spells = null;
            this.equippedSpellList.SplitPercentage = 29;
            this.equippedSpellList.TabIndex = 6;
            // 
            // possibleSkillTypes
            // 
            this.possibleSkillTypes.Data = new DOS2Randomizer.DataStructures.Player.SkillType[] {
        DOS2Randomizer.DataStructures.Player.SkillType.Melee,
        DOS2Randomizer.DataStructures.Player.SkillType.Archer,
        DOS2Randomizer.DataStructures.Player.SkillType.Shield,
        DOS2Randomizer.DataStructures.Player.SkillType.Dagger,
        DOS2Randomizer.DataStructures.Player.SkillType.None};
            this.possibleSkillTypes.DisplayMember = null;
            this.possibleSkillTypes.Label = "Loadout";
            this.possibleSkillTypes.Location = new System.Drawing.Point(243, 3);
            this.possibleSkillTypes.Name = "possibleSkillTypes";
            this.possibleSkillTypes.Size = new System.Drawing.Size(150, 111);
            this.possibleSkillTypes.SplitPercentage = 40;
            this.possibleSkillTypes.TabIndex = 7;
            this.possibleSkillTypes.Value = new DOS2Randomizer.DataStructures.Player.SkillType[0];
            // 
            // remove
            // 
            this.remove.Location = new System.Drawing.Point(544, 4);
            this.remove.Name = "remove";
            this.remove.Size = new System.Drawing.Size(75, 23);
            this.remove.TabIndex = 8;
            this.remove.Text = "Remove";
            this.remove.UseVisualStyleBackColor = true;
            this.remove.Click += new System.EventHandler(this.remove_Click);
            // 
            // addSpells
            // 
            this.addSpells.Location = new System.Drawing.Point(544, 32);
            this.addSpells.Name = "addSpells";
            this.addSpells.Size = new System.Drawing.Size(75, 23);
            this.addSpells.TabIndex = 9;
            this.addSpells.Text = "Add Spells";
            this.addSpells.UseVisualStyleBackColor = true;
            this.addSpells.Click += new System.EventHandler(this.addSpells_Click);
            // 
            // PlayerPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.addSpells);
            this.Controls.Add(this.remove);
            this.Controls.Add(this.possibleSkillTypes);
            this.Controls.Add(this.equippedSpellList);
            this.Controls.Add(this.knownSpellList);
            this.Controls.Add(this.attributePointsPanel1);
            this.Controls.Add(this.skillPointsPanel1);
            this.Controls.Add(this.playerLevel);
            this.Controls.Add(this.playerName);
            this.Name = "PlayerPanel";
            this.Size = new System.Drawing.Size(626, 656);
            this.ResumeLayout(false);

        }

        #endregion

        private UI.LabeledString playerName;
        private UI.LabeledValue playerLevel;
        private UI.SkillPointsPanel skillPointsPanel1;
        private UI.AttributePointsPanel attributePointsPanel1;
        private SearchableSpellList knownSpellList;
        private SearchableSpellList equippedSpellList;
        private LabeledSkillTypeSelection possibleSkillTypes;
        private System.Windows.Forms.Button remove;
        private System.Windows.Forms.Button addSpells;
    }
}
