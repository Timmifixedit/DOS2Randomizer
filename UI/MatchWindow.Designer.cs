
namespace DOS2Randomizer.UI {
    partial class MatchWindow {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MatchWindow));
            this.mainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.playersLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.topLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.save = new System.Windows.Forms.Button();
            this.addPlayer = new System.Windows.Forms.Button();
            this.mainLayout.SuspendLayout();
            this.topLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainLayout
            // 
            this.mainLayout.ColumnCount = 1;
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayout.Controls.Add(this.playersLayout, 0, 1);
            this.mainLayout.Controls.Add(this.topLayout, 0, 0);
            this.mainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLayout.Location = new System.Drawing.Point(0, 0);
            this.mainLayout.Name = "mainLayout";
            this.mainLayout.RowCount = 2;
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayout.Size = new System.Drawing.Size(800, 450);
            this.mainLayout.TabIndex = 0;
            // 
            // playersLayout
            // 
            this.playersLayout.AutoScroll = true;
            this.playersLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.playersLayout.Location = new System.Drawing.Point(3, 43);
            this.playersLayout.Name = "playersLayout";
            this.playersLayout.Size = new System.Drawing.Size(794, 404);
            this.playersLayout.TabIndex = 0;
            // 
            // topLayout
            // 
            this.topLayout.Controls.Add(this.save);
            this.topLayout.Controls.Add(this.addPlayer);
            this.topLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.topLayout.Location = new System.Drawing.Point(3, 3);
            this.topLayout.Name = "topLayout";
            this.topLayout.Size = new System.Drawing.Size(794, 34);
            this.topLayout.TabIndex = 1;
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(3, 3);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(75, 23);
            this.save.TabIndex = 0;
            this.save.Text = "Save";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // addPlayer
            // 
            this.addPlayer.Location = new System.Drawing.Point(84, 3);
            this.addPlayer.Name = "addPlayer";
            this.addPlayer.Size = new System.Drawing.Size(75, 23);
            this.addPlayer.TabIndex = 1;
            this.addPlayer.Text = "Add Player";
            this.addPlayer.UseVisualStyleBackColor = true;
            this.addPlayer.Click += new System.EventHandler(this.addPlayer_Click);
            // 
            // MatchWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mainLayout);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "MatchWindow";
            this.Text = "MatchWindow";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MatchWindow_KeyDown);
            this.mainLayout.ResumeLayout(false);
            this.topLayout.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mainLayout;
        private System.Windows.Forms.FlowLayoutPanel playersLayout;
        private System.Windows.Forms.FlowLayoutPanel topLayout;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Button addPlayer;
    }
}