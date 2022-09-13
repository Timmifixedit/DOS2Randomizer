
using DOS2Randomizer.UI.Components;

namespace DOS2Randomizer.UI {
    partial class SpellChooseDialog {
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
            this.fromList = new DOS2Randomizer.UI.CSearchableSpellList();
            this.confirm = new DOS2Randomizer.UI.Components.Button();
            this.toList = new DOS2Randomizer.UI.CSearchableSpellList();
            this.SuspendLayout();
            // 
            // fromList
            // 
            this.fromList.Design = DOS2Randomizer.UI.DesignType.Dark;
            this.fromList.Label = "";
            this.fromList.Location = new System.Drawing.Point(16, 12);
            this.fromList.Name = "fromList";
            this.fromList.Size = new System.Drawing.Size(772, 130);
            this.fromList.Spells = new DOS2Randomizer.DataStructures.Spell[0];
            this.fromList.SplitPercentage = 29;
            this.fromList.TabIndex = 0;
            // 
            // confirm
            // 
            this.confirm.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.confirm.Design = DOS2Randomizer.UI.DesignType.Dark;
            this.confirm.FlatAppearance.BorderSize = 0;
            this.confirm.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.confirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.confirm.ForeColor = System.Drawing.Color.White;
            this.confirm.Location = new System.Drawing.Point(16, 12);
            this.confirm.Name = "confirm";
            this.confirm.Size = new System.Drawing.Size(75, 23);
            this.confirm.TabIndex = 2;
            this.confirm.Text = "Confirm";
            this.confirm.UseVisualStyleBackColor = false;
            this.confirm.Click += new System.EventHandler(this.confirm_Click);
            // 
            // toList
            // 
            this.toList.Design = DOS2Randomizer.UI.DesignType.Dark;
            this.toList.Label = "";
            this.toList.Location = new System.Drawing.Point(16, 141);
            this.toList.Name = "toList";
            this.toList.Size = new System.Drawing.Size(772, 130);
            this.toList.Spells = new DOS2Randomizer.DataStructures.Spell[0];
            this.toList.SplitPercentage = 29;
            this.toList.TabIndex = 3;
            // 
            // SpellChooseDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 297);
            this.Controls.Add(this.toList);
            this.Controls.Add(this.confirm);
            this.Controls.Add(this.fromList);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SpellChooseDialog";
            this.Text = "Configure Spells manually";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SpellChooseDialog_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private CSearchableSpellList fromList;
        private DOS2Randomizer.UI.Components.Button confirm;
        private CSearchableSpellList toList;
    }
}