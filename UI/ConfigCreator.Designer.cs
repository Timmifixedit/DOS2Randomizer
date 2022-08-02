
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
            this.levelSpecific = new System.Windows.Forms.TabPage();
            this.spells = new System.Windows.Forms.TabPage();
            this.tabControl.SuspendLayout();
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
            this.general.Location = new System.Drawing.Point(4, 24);
            this.general.Name = "general";
            this.general.Padding = new System.Windows.Forms.Padding(3);
            this.general.Size = new System.Drawing.Size(792, 422);
            this.general.TabIndex = 0;
            this.general.Text = "General";
            this.general.UseVisualStyleBackColor = true;
            // 
            // levelSpecific
            // 
            this.levelSpecific.Location = new System.Drawing.Point(4, 24);
            this.levelSpecific.Name = "levelSpecific";
            this.levelSpecific.Padding = new System.Windows.Forms.Padding(3);
            this.levelSpecific.Size = new System.Drawing.Size(792, 422);
            this.levelSpecific.TabIndex = 1;
            this.levelSpecific.Text = "Level Specific";
            this.levelSpecific.UseVisualStyleBackColor = true;
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
            // ConfigCreator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl);
            this.Name = "ConfigCreator";
            this.Text = "ConfigCreator";
            this.tabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage general;
        private System.Windows.Forms.TabPage levelSpecific;
        private System.Windows.Forms.TabPage spells;
    }
}