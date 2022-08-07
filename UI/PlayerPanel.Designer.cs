
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
            this.possibleSkillTypes = new DOS2Randomizer.UI.LabeledSkillTypeSelection();
            this.attributePointsPanel1 = new DOS2Randomizer.UI.AttributePointsPanel();
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
            this.skillPointsPanel1.ExcludedValues = null;
            this.skillPointsPanel1.Location = new System.Drawing.Point(268, 47);
            this.skillPointsPanel1.Name = "skillPointsPanel1";
            this.skillPointsPanel1.Size = new System.Drawing.Size(150, 330);
            this.skillPointsPanel1.TabIndex = 2;
            // 
            // possibleSkillTypes
            // 
            this.possibleSkillTypes.Data = null;
            this.possibleSkillTypes.DisplayMember = null;
            this.possibleSkillTypes.Label = "Possible Skill Types";
            this.possibleSkillTypes.Location = new System.Drawing.Point(3, 61);
            this.possibleSkillTypes.Name = "possibleSkillTypes";
            this.possibleSkillTypes.Size = new System.Drawing.Size(234, 33);
            this.possibleSkillTypes.SplitPercentage = 50;
            this.possibleSkillTypes.TabIndex = 3;
            this.possibleSkillTypes.Value = new DOS2Randomizer.DataStructures.Player.SkillType[0];
            // 
            // attributePointsPanel1
            // 
            this.attributePointsPanel1.ExcludedValues = new DOS2Randomizer.DataStructures.Attribute[] {
        DOS2Randomizer.DataStructures.Attribute.None};
            this.attributePointsPanel1.Location = new System.Drawing.Point(3, 100);
            this.attributePointsPanel1.Name = "attributePointsPanel1";
            this.attributePointsPanel1.Size = new System.Drawing.Size(150, 261);
            this.attributePointsPanel1.TabIndex = 4;
            // 
            // PlayerPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.attributePointsPanel1);
            this.Controls.Add(this.possibleSkillTypes);
            this.Controls.Add(this.skillPointsPanel1);
            this.Controls.Add(this.playerLevel);
            this.Controls.Add(this.playerName);
            this.Name = "PlayerPanel";
            this.Size = new System.Drawing.Size(433, 388);
            this.ResumeLayout(false);

        }

        #endregion

        private UI.LabeledString playerName;
        private UI.LabeledValue playerLevel;
        private UI.SkillPointsPanel skillPointsPanel1;
        private UI.LabeledSkillTypeSelection possibleSkillTypes;
        private UI.AttributePointsPanel attributePointsPanel1;
    }
}
