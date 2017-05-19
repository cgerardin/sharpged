namespace SharpGED_client.Forms
{
    partial class formEditPdf
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formEditPdf));
            this.listBoxPages = new System.Windows.Forms.ListBox();
            this.MainToolbar = new System.Windows.Forms.ToolStrip();
            this.toolButtonUp = new System.Windows.Forms.ToolStripButton();
            this.toolButtonDown = new System.Windows.Forms.ToolStripButton();
            this.toolButtonCut = new System.Windows.Forms.ToolStripButton();
            this.pdfViewer = new PdfiumViewer.PdfRenderer();
            this.buttonSave = new System.Windows.Forms.Button();
            this.MainToolbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxPages
            // 
            this.listBoxPages.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBoxPages.FormattingEnabled = true;
            this.listBoxPages.Location = new System.Drawing.Point(48, 7);
            this.listBoxPages.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.listBoxPages.Name = "listBoxPages";
            this.listBoxPages.Size = new System.Drawing.Size(144, 667);
            this.listBoxPages.TabIndex = 1;
            this.listBoxPages.SelectedIndexChanged += new System.EventHandler(this.listBoxPages_SelectedIndexChanged);
            // 
            // MainToolbar
            // 
            this.MainToolbar.AutoSize = false;
            this.MainToolbar.Dock = System.Windows.Forms.DockStyle.Left;
            this.MainToolbar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.MainToolbar.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.MainToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolButtonUp,
            this.toolButtonDown,
            this.toolButtonCut});
            this.MainToolbar.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.MainToolbar.Location = new System.Drawing.Point(0, 0);
            this.MainToolbar.Name = "MainToolbar";
            this.MainToolbar.Size = new System.Drawing.Size(42, 680);
            this.MainToolbar.TabIndex = 21;
            this.MainToolbar.Text = "toolStrip1";
            // 
            // toolButtonUp
            // 
            this.toolButtonUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolButtonUp.Image = ((System.Drawing.Image)(resources.GetObject("toolButtonUp.Image")));
            this.toolButtonUp.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolButtonUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolButtonUp.Name = "toolButtonUp";
            this.toolButtonUp.Size = new System.Drawing.Size(40, 36);
            this.toolButtonUp.Text = "Au dessus";
            this.toolButtonUp.Click += new System.EventHandler(this.toolButtonUp_Click);
            // 
            // toolButtonDown
            // 
            this.toolButtonDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolButtonDown.Image = ((System.Drawing.Image)(resources.GetObject("toolButtonDown.Image")));
            this.toolButtonDown.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolButtonDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolButtonDown.Name = "toolButtonDown";
            this.toolButtonDown.Size = new System.Drawing.Size(40, 36);
            this.toolButtonDown.Text = "En dessous";
            this.toolButtonDown.Click += new System.EventHandler(this.toolButtonDown_Click);
            // 
            // toolButtonCut
            // 
            this.toolButtonCut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolButtonCut.Image = ((System.Drawing.Image)(resources.GetObject("toolButtonCut.Image")));
            this.toolButtonCut.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolButtonCut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolButtonCut.Name = "toolButtonCut";
            this.toolButtonCut.Size = new System.Drawing.Size(40, 36);
            this.toolButtonCut.Text = "Supprimer la page";
            this.toolButtonCut.Click += new System.EventHandler(this.toolButtonCut_Click);
            // 
            // pdfViewer
            // 
            this.pdfViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pdfViewer.Location = new System.Drawing.Point(198, 9);
            this.pdfViewer.Margin = new System.Windows.Forms.Padding(0);
            this.pdfViewer.Name = "pdfViewer";
            this.pdfViewer.Page = 0;
            this.pdfViewer.Rotation = PdfiumViewer.PdfRotation.Rotate0;
            this.pdfViewer.Size = new System.Drawing.Size(553, 618);
            this.pdfViewer.TabIndex = 2;
            this.pdfViewer.ZoomMode = PdfiumViewer.PdfViewerZoomMode.FitWidth;
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSave.Location = new System.Drawing.Point(617, 640);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(123, 28);
            this.buttonSave.TabIndex = 22;
            this.buttonSave.Text = "Enregistrer et fermer";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // formEditPdf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 680);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.pdfViewer);
            this.Controls.Add(this.MainToolbar);
            this.Controls.Add(this.listBoxPages);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.Name = "formEditPdf";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Editeur de PDF";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.formEditPdf_FormClosed);
            this.Load += new System.EventHandler(this.formEditPdf_Load);
            this.MainToolbar.ResumeLayout(false);
            this.MainToolbar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxPages;
        private System.Windows.Forms.ToolStrip MainToolbar;
        private System.Windows.Forms.ToolStripButton toolButtonUp;
        private System.Windows.Forms.ToolStripButton toolButtonDown;
        private System.Windows.Forms.ToolStripButton toolButtonCut;
        private PdfiumViewer.PdfRenderer pdfViewer;
        private System.Windows.Forms.Button buttonSave;
    }
}