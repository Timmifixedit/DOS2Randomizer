namespace DOS2Randomizer.UI.Components {
    partial class BaseWindow {
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
            this.designButton = new DOS2Randomizer.UI.Components.Button();
            this.SuspendLayout();
            // 
            // designButton
            // 
            this.designButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.designButton.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.designButton.Design = DOS2Randomizer.UI.DesignType.Dark;
            this.designButton.FlatAppearance.BorderSize = 0;
            this.designButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(98)))), ((int)(((byte)(0)))));
            this.designButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.designButton.ForeColor = System.Drawing.Color.White;
            this.designButton.Location = new System.Drawing.Point(713, 415);
            this.designButton.Name = "designButton";
            this.designButton.Size = new System.Drawing.Size(75, 23);
            this.designButton.TabIndex = 0;
            this.designButton.Text = "Light";
            this.designButton.UseVisualStyleBackColor = true;
            this.designButton.Click += new System.EventHandler(this.designButton_Click);
            // 
            // BaseWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.designButton);
            this.KeyPreview = true;
            this.Name = "BaseWindow";
            this.Text = "BaseWindow";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BaseWindow_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        protected Button designButton;
    }
}