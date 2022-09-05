
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
            this.possibleSkillTypes = new DOS2Randomizer.UI.LabeledSkillTypeSelection();
            this.remove = new System.Windows.Forms.Button();
            this.configureSpells = new System.Windows.Forms.Button();
            this.drawSpells = new System.Windows.Forms.Button();
            this.equippedSpellList = new DOS2Randomizer.UI.CSearchableSpellList();
            this.knownSpellList = new DOS2Randomizer.UI.CSearchableSpellList();
            this.shuffle = new System.Windows.Forms.Button();
            this.dmgType = new DOS2Randomizer.UI.LabeledDmgType();
            this.SuspendLayout();
            // 
            // playerName
            // 
            this.playerName.Label = "Player Name";
            this.playerName.Location = new System.Drawing.Point(3, 4);
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
            this.playerLevel.Min = 1;
            this.playerLevel.Name = "playerLevel";
            this.playerLevel.Size = new System.Drawing.Size(156, 23);
            this.playerLevel.SplitPercentage = 70;
            this.playerLevel.TabIndex = 1;
            this.playerLevel.Value = 1;
            // 
            // skillPointsPanel1
            // 
            this.skillPointsPanel1.Location = new System.Drawing.Point(3, 102);
            this.skillPointsPanel1.Name = "skillPointsPanel1";
            this.skillPointsPanel1.Size = new System.Drawing.Size(150, 330);
            this.skillPointsPanel1.TabIndex = 2;
            // 
            // attributePointsPanel1
            // 
            this.attributePointsPanel1.Location = new System.Drawing.Point(243, 171);
            this.attributePointsPanel1.Name = "attributePointsPanel1";
            this.attributePointsPanel1.Size = new System.Drawing.Size(150, 261);
            this.attributePointsPanel1.TabIndex = 4;
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
            this.remove.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.remove.FlatAppearance.BorderSize = 0;
            this.remove.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.remove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.remove.Location = new System.Drawing.Point(514, 4);
            this.remove.Name = "remove";
            this.remove.Size = new System.Drawing.Size(105, 23);
            this.remove.TabIndex = 8;
            this.remove.Text = "Remove";
            this.remove.UseVisualStyleBackColor = false;
            this.remove.Click += new System.EventHandler(this.remove_Click);
            // 
            // configureSpells
            // 
            this.configureSpells.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.configureSpells.FlatAppearance.BorderSize = 0;
            this.configureSpells.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.configureSpells.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.configureSpells.Location = new System.Drawing.Point(514, 350);
            this.configureSpells.Name = "configureSpells";
            this.configureSpells.Size = new System.Drawing.Size(105, 23);
            this.configureSpells.TabIndex = 9;
            this.configureSpells.Text = "Configure Spells";
            this.configureSpells.UseVisualStyleBackColor = false;
            this.configureSpells.Click += new System.EventHandler(this.configureSpells_Click);
            // 
            // drawSpells
            // 
            this.drawSpells.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.drawSpells.FlatAppearance.BorderSize = 0;
            this.drawSpells.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.drawSpells.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.drawSpells.Location = new System.Drawing.Point(514, 379);
            this.drawSpells.Name = "drawSpells";
            this.drawSpells.Size = new System.Drawing.Size(105, 23);
            this.drawSpells.TabIndex = 10;
            this.drawSpells.Text = "Draw new Spells";
            this.drawSpells.UseVisualStyleBackColor = false;
            this.drawSpells.Click += new System.EventHandler(this.drawSpells_Click);
            // 
            // equippedSpellList
            // 
            this.equippedSpellList.Label = "Equipped Spells";
            this.equippedSpellList.Location = new System.Drawing.Point(3, 567);
            this.equippedSpellList.Name = "equippedSpellList";
            this.equippedSpellList.Size = new System.Drawing.Size(616, 123);
            this.equippedSpellList.Spells = new DOS2Randomizer.DataStructures.IConstSpell[0];
            this.equippedSpellList.SplitPercentage = 29;
            this.equippedSpellList.TabIndex = 11;
            // 
            // knownSpellList
            // 
            this.knownSpellList.Label = "Known Spells";
            this.knownSpellList.Location = new System.Drawing.Point(3, 438);
            this.knownSpellList.Name = "knownSpellList";
            this.knownSpellList.Size = new System.Drawing.Size(616, 123);
            this.knownSpellList.Spells = new DOS2Randomizer.DataStructures.IConstSpell[0];
            this.knownSpellList.SplitPercentage = 29;
            this.knownSpellList.TabIndex = 12;
            // 
            // shuffle
            // 
            this.shuffle.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.shuffle.FlatAppearance.BorderSize = 0;
            this.shuffle.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.shuffle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.shuffle.Location = new System.Drawing.Point(514, 409);
            this.shuffle.Name = "shuffle";
            this.shuffle.Size = new System.Drawing.Size(105, 23);
            this.shuffle.TabIndex = 13;
            this.shuffle.Text = "Shuffle equipped Spells";
            this.shuffle.UseVisualStyleBackColor = false;
            this.shuffle.Click += new System.EventHandler(this.shuffle_Click);
            // 
            // dmgType
            // 
            this.dmgType.Label = "Dmg Type";
            this.dmgType.Location = new System.Drawing.Point(243, 109);
            this.dmgType.Name = "dmgType";
            this.dmgType.Size = new System.Drawing.Size(150, 40);
            this.dmgType.SplitPercentage = 40;
            this.dmgType.TabIndex = 14;
            this.dmgType.Value = DOS2Randomizer.DataStructures.Player.WeaponDmgType.Physical;
            // 
            // PlayerPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dmgType);
            this.Controls.Add(this.shuffle);
            this.Controls.Add(this.knownSpellList);
            this.Controls.Add(this.equippedSpellList);
            this.Controls.Add(this.drawSpells);
            this.Controls.Add(this.configureSpells);
            this.Controls.Add(this.remove);
            this.Controls.Add(this.possibleSkillTypes);
            this.Controls.Add(this.attributePointsPanel1);
            this.Controls.Add(this.skillPointsPanel1);
            this.Controls.Add(this.playerLevel);
            this.Controls.Add(this.playerName);
            this.Name = "PlayerPanel";
            this.Size = new System.Drawing.Size(630, 696);
            this.ResumeLayout(false);

        }

        #endregion

        private UI.LabeledString playerName;
        private UI.LabeledValue playerLevel;
        private UI.SkillPointsPanel skillPointsPanel1;
        private UI.AttributePointsPanel attributePointsPanel1;
        private LabeledSkillTypeSelection possibleSkillTypes;
        private System.Windows.Forms.Button remove;
        private System.Windows.Forms.Button configureSpells;
        private System.Windows.Forms.Button drawSpells;
        private CSearchableSpellList equippedSpellList;
        private CSearchableSpellList knownSpellList;
        private System.Windows.Forms.Button shuffle;
        private LabeledDmgType dmgType;
    }
}
