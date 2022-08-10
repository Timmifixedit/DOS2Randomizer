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
            this.confirm = new System.Windows.Forms.Button();
            this.source = new DOS2Randomizer.UI.SpellList();
            this.selection = new DOS2Randomizer.UI.SpellList();
            this.description = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // confirm
            // 
            this.confirm.Location = new System.Drawing.Point(12, 12);
            this.confirm.Name = "confirm";
            this.confirm.Size = new System.Drawing.Size(75, 23);
            this.confirm.TabIndex = 0;
            this.confirm.Text = "Confirm";
            this.confirm.UseVisualStyleBackColor = true;
            this.confirm.Click += new System.EventHandler(this.confirm_Click);
            // 
            // source
            // 
            this.source.Location = new System.Drawing.Point(180, 12);
            this.source.Name = "source";
            this.source.Size = new System.Drawing.Size(538, 116);
            this.source.Spells = null;
            this.source.TabIndex = 1;
            // 
            // selection
            // 
            this.selection.Location = new System.Drawing.Point(180, 134);
            this.selection.Name = "selection";
            this.selection.Size = new System.Drawing.Size(538, 116);
            this.selection.Spells = null;
            this.selection.TabIndex = 2;
            // 
            // description
            // 
            this.description.AutoSize = true;
            this.description.Location = new System.Drawing.Point(12, 58);
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(38, 15);
            this.description.TabIndex = 3;
            this.description.Text = "label1";
            // 
            // ChooseKDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 259);
            this.Controls.Add(this.description);
            this.Controls.Add(this.selection);
            this.Controls.Add(this.source);
            this.Controls.Add(this.confirm);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChooseKDialog";
            this.Text = "ChooseKDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button confirm;
        private SpellList source;
        private SpellList selection;
        private System.Windows.Forms.Label description;
    }
}