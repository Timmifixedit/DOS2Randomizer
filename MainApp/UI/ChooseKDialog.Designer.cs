using DOS2Randomizer.UI.Components;

namespace DOS2Randomizer.UI {
    partial class ChooseKDialog {
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
            this.confirm = new DOS2Randomizer.UI.Components.Button();
            this.source = new DOS2Randomizer.UI.CSpellList();
            this.selection = new DOS2Randomizer.UI.CSpellList();
            this.description = new DOS2Randomizer.UI.Components.Label();
            this.reroll = new DOS2Randomizer.UI.Components.Button();
            this.SuspendLayout();
            // 
            // confirm
            // 
            this.confirm.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.confirm.Design = DOS2Randomizer.UI.DesignType.Dark;
            this.confirm.FlatAppearance.BorderSize = 0;
            this.confirm.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.confirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.confirm.ForeColor = System.Drawing.Color.White;
            this.confirm.Location = new System.Drawing.Point(12, 224);
            this.confirm.Name = "confirm";
            this.confirm.Size = new System.Drawing.Size(99, 23);
            this.confirm.TabIndex = 0;
            this.confirm.Text = "Confirm";
            this.confirm.UseVisualStyleBackColor = false;
            this.confirm.Click += new System.EventHandler(this.confirm_Click);
            // 
            // source
            // 
            this.source.Design = DOS2Randomizer.UI.DesignType.Dark;
            this.source.Location = new System.Drawing.Point(180, 12);
            this.source.Name = "source";
            this.source.Size = new System.Drawing.Size(538, 116);
            this.source.Spells = null;
            this.source.TabIndex = 1;
            // 
            // selection
            // 
            this.selection.Design = DOS2Randomizer.UI.DesignType.Dark;
            this.selection.Location = new System.Drawing.Point(180, 134);
            this.selection.Name = "selection";
            this.selection.Size = new System.Drawing.Size(538, 116);
            this.selection.Spells = null;
            this.selection.TabIndex = 2;
            // 
            // description
            // 
            this.description.AutoSize = true;
            this.description.Design = DOS2Randomizer.UI.DesignType.Dark;
            this.description.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.description.ForeColor = System.Drawing.Color.White;
            this.description.Location = new System.Drawing.Point(12, 9);
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(38, 15);
            this.description.TabIndex = 3;
            this.description.Text = "label1";
            // 
            // reroll
            // 
            this.reroll.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.reroll.Design = DOS2Randomizer.UI.DesignType.Dark;
            this.reroll.FlatAppearance.BorderSize = 0;
            this.reroll.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.reroll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.reroll.ForeColor = System.Drawing.Color.White;
            this.reroll.Location = new System.Drawing.Point(12, 27);
            this.reroll.Name = "reroll";
            this.reroll.Size = new System.Drawing.Size(99, 23);
            this.reroll.TabIndex = 4;
            this.reroll.Text = "Reroll";
            this.reroll.UseVisualStyleBackColor = false;
            this.reroll.Click += new System.EventHandler(this.reroll_Click);
            // 
            // ChooseKDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 259);
            this.Controls.Add(this.reroll);
            this.Controls.Add(this.description);
            this.Controls.Add(this.selection);
            this.Controls.Add(this.source);
            this.Controls.Add(this.confirm);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChooseKDialog";
            this.ShowInTaskbar = false;
            this.Text = "Choose from randomly selected Spells";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DOS2Randomizer.UI.Components.Button confirm;
        private CSpellList source;
        private CSpellList selection;
        private DOS2Randomizer.UI.Components.Label description;
        private DOS2Randomizer.UI.Components.Button reroll;
    }
}