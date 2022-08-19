namespace DOS2Randomizer.UI {
    partial class PdfVisualizer {
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.plotCanvas = new ScottPlot.FormsPlot();
            this.importanceBar = new System.Windows.Forms.TrackBar();
            this.layout = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.importanceBar)).BeginInit();
            this.layout.SuspendLayout();
            this.SuspendLayout();
            // 
            // plotCanvas
            // 
            this.plotCanvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plotCanvas.Location = new System.Drawing.Point(4, 3);
            this.plotCanvas.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.plotCanvas.Name = "plotCanvas";
            this.plotCanvas.Size = new System.Drawing.Size(284, 171);
            this.plotCanvas.TabIndex = 0;
            // 
            // importanceBar
            // 
            this.importanceBar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.importanceBar.Location = new System.Drawing.Point(25, 180);
            this.importanceBar.Maximum = 1000;
            this.importanceBar.Name = "importanceBar";
            this.importanceBar.Size = new System.Drawing.Size(241, 39);
            this.importanceBar.TabIndex = 1;
            // 
            // layout
            // 
            this.layout.ColumnCount = 1;
            this.layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layout.Controls.Add(this.plotCanvas, 0, 0);
            this.layout.Controls.Add(this.importanceBar, 0, 1);
            this.layout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layout.Location = new System.Drawing.Point(0, 0);
            this.layout.Name = "layout";
            this.layout.RowCount = 2;
            this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.layout.Size = new System.Drawing.Size(292, 222);
            this.layout.TabIndex = 2;
            // 
            // PdfVisualizer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layout);
            this.Name = "PdfVisualizer";
            this.Size = new System.Drawing.Size(292, 222);
            ((System.ComponentModel.ISupportInitialize)(this.importanceBar)).EndInit();
            this.layout.ResumeLayout(false);
            this.layout.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ScottPlot.FormsPlot plotCanvas;
        private System.Windows.Forms.TrackBar importanceBar;
        private System.Windows.Forms.TableLayoutPanel layout;
    }
}
