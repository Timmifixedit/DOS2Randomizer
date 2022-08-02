
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
            this.SaveButton = new System.Windows.Forms.Button();
            this.ConfigNameLayout = new System.Windows.Forms.TableLayoutPanel();
            this.ConfigNameLabel = new System.Windows.Forms.Label();
            this.ConfigNameText = new System.Windows.Forms.TextBox();
            this.levelSpecific = new System.Windows.Forms.TabPage();
            this.spells = new System.Windows.Forms.TabPage();
            this.tabControl.SuspendLayout();
            this.general.SuspendLayout();
            this.ConfigNameLayout.SuspendLayout();
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
            this.general.Controls.Add(this.SaveButton);
            this.general.Controls.Add(this.ConfigNameLayout);
            this.general.Location = new System.Drawing.Point(4, 24);
            this.general.Name = "general";
            this.general.Padding = new System.Windows.Forms.Padding(3);
            this.general.Size = new System.Drawing.Size(792, 422);
            this.general.TabIndex = 0;
            this.general.Text = "General";
            this.general.UseVisualStyleBackColor = true;
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(506, 162);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 3;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // ConfigNameLayout
            // 
            this.ConfigNameLayout.ColumnCount = 2;
            this.ConfigNameLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.66667F));
            this.ConfigNameLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58.33333F));
            this.ConfigNameLayout.Controls.Add(this.ConfigNameLabel, 0, 0);
            this.ConfigNameLayout.Controls.Add(this.ConfigNameText, 1, 0);
            this.ConfigNameLayout.Location = new System.Drawing.Point(163, 20);
            this.ConfigNameLayout.Name = "ConfigNameLayout";
            this.ConfigNameLayout.RowCount = 1;
            this.ConfigNameLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ConfigNameLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.ConfigNameLayout.Size = new System.Drawing.Size(468, 25);
            this.ConfigNameLayout.TabIndex = 2;
            // 
            // ConfigNameLabel
            // 
            this.ConfigNameLabel.AutoSize = true;
            this.ConfigNameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConfigNameLabel.Location = new System.Drawing.Point(3, 0);
            this.ConfigNameLabel.Name = "ConfigNameLabel";
            this.ConfigNameLabel.Size = new System.Drawing.Size(189, 25);
            this.ConfigNameLabel.TabIndex = 1;
            this.ConfigNameLabel.Text = "Configuration Name";
            this.ConfigNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ConfigNameText
            // 
            this.ConfigNameText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConfigNameText.Location = new System.Drawing.Point(198, 3);
            this.ConfigNameText.Name = "ConfigNameText";
            this.ConfigNameText.Size = new System.Drawing.Size(267, 23);
            this.ConfigNameText.TabIndex = 0;
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
            this.Text = "Create Match Config";
            this.tabControl.ResumeLayout(false);
            this.general.ResumeLayout(false);
            this.ConfigNameLayout.ResumeLayout(false);
            this.ConfigNameLayout.PerformLayout();
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
    }
}