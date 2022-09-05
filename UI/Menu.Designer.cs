namespace DOS2Randomizer.UI {
    partial class Menu {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.LoadConfig = new System.Windows.Forms.Button();
            this.layoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.CreateConfig = new System.Windows.Forms.Button();
            this.spellConfigurator = new System.Windows.Forms.Button();
            this.centerLayout = new System.Windows.Forms.TableLayoutPanel();
            this.layoutPanel.SuspendLayout();
            this.centerLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // LoadConfig
            // 
            this.LoadConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.LoadConfig.Location = new System.Drawing.Point(3, 11);
            this.LoadConfig.Name = "LoadConfig";
            this.LoadConfig.Size = new System.Drawing.Size(628, 40);
            this.LoadConfig.TabIndex = 0;
            this.LoadConfig.Text = "Load Config";
            this.LoadConfig.UseVisualStyleBackColor = true;
            this.LoadConfig.Click += new System.EventHandler(this.LoadConfig_Click);
            // 
            // layoutPanel
            // 
            this.layoutPanel.ColumnCount = 1;
            this.layoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutPanel.Controls.Add(this.CreateConfig, 0, 1);
            this.layoutPanel.Controls.Add(this.LoadConfig, 0, 0);
            this.layoutPanel.Controls.Add(this.spellConfigurator, 0, 2);
            this.layoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutPanel.Location = new System.Drawing.Point(83, 131);
            this.layoutPanel.Name = "layoutPanel";
            this.layoutPanel.RowCount = 3;
            this.layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.layoutPanel.Size = new System.Drawing.Size(634, 186);
            this.layoutPanel.TabIndex = 1;
            // 
            // CreateConfig
            // 
            this.CreateConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.CreateConfig.Location = new System.Drawing.Point(3, 73);
            this.CreateConfig.Name = "CreateConfig";
            this.CreateConfig.Size = new System.Drawing.Size(628, 40);
            this.CreateConfig.TabIndex = 1;
            this.CreateConfig.Text = "Create Config";
            this.CreateConfig.UseVisualStyleBackColor = true;
            this.CreateConfig.Click += new System.EventHandler(this.CreateConfig_Click);
            // 
            // spellConfigurator
            // 
            this.spellConfigurator.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.spellConfigurator.Location = new System.Drawing.Point(3, 135);
            this.spellConfigurator.Name = "spellConfigurator";
            this.spellConfigurator.Size = new System.Drawing.Size(628, 40);
            this.spellConfigurator.TabIndex = 2;
            this.spellConfigurator.Text = "Configure Spells";
            this.spellConfigurator.UseVisualStyleBackColor = true;
            this.spellConfigurator.Click += new System.EventHandler(this.spellConfigurator_Click);
            // 
            // centerLayout
            // 
            this.centerLayout.ColumnCount = 3;
            this.centerLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.centerLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.centerLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.centerLayout.Controls.Add(this.layoutPanel, 1, 1);
            this.centerLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.centerLayout.Location = new System.Drawing.Point(0, 0);
            this.centerLayout.Name = "centerLayout";
            this.centerLayout.RowCount = 3;
            this.centerLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 28.57143F));
            this.centerLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42.85715F));
            this.centerLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 28.57143F));
            this.centerLayout.Size = new System.Drawing.Size(800, 450);
            this.centerLayout.TabIndex = 2;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.centerLayout);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Menu";
            this.Text = "DOS2 Randomizer";
            this.layoutPanel.ResumeLayout(false);
            this.centerLayout.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button LoadConfig;
        private System.Windows.Forms.TableLayoutPanel layoutPanel;
        private System.Windows.Forms.Button CreateConfig;
        private System.Windows.Forms.TableLayoutPanel centerLayout;
        private System.Windows.Forms.Button spellConfigurator;
    }
}

