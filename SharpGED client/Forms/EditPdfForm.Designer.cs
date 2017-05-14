namespace SharpGED_client.Forms
{
    partial class EditPdfForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditPdfForm));
            this.ListBoxPages = new System.Windows.Forms.ListBox();
            this.MainToolbar = new System.Windows.Forms.ToolStrip();
            this.ToolButtonUp = new System.Windows.Forms.ToolStripButton();
            this.ToolButtonDown = new System.Windows.Forms.ToolStripButton();
            this.ToolButtonCut = new System.Windows.Forms.ToolStripButton();
            this.PdfViewer = new PdfiumViewer.PdfRenderer();
            this.ButtonSave = new System.Windows.Forms.Button();
            this.MainToolbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // ListBoxPages
            // 
            this.ListBoxPages.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ListBoxPages.FormattingEnabled = true;
            this.ListBoxPages.Location = new System.Drawing.Point(48, 7);
            this.ListBoxPages.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.ListBoxPages.Name = "ListBoxPages";
            this.ListBoxPages.Size = new System.Drawing.Size(144, 667);
            this.ListBoxPages.TabIndex = 1;
            this.ListBoxPages.SelectedIndexChanged += new System.EventHandler(this.ListBoxPages_SelectedIndexChanged);
            // 
            // MainToolbar
            // 
            this.MainToolbar.AutoSize = false;
            this.MainToolbar.Dock = System.Windows.Forms.DockStyle.Left;
            this.MainToolbar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.MainToolbar.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.MainToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolButtonUp,
            this.ToolButtonDown,
            this.ToolButtonCut});
            this.MainToolbar.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.MainToolbar.Location = new System.Drawing.Point(0, 0);
            this.MainToolbar.Name = "MainToolbar";
            this.MainToolbar.Size = new System.Drawing.Size(42, 680);
            this.MainToolbar.TabIndex = 21;
            this.MainToolbar.Text = "toolStrip1";
            // 
            // ToolButtonUp
            // 
            this.ToolButtonUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolButtonUp.Image = ((System.Drawing.Image)(resources.GetObject("ToolButtonUp.Image")));
            this.ToolButtonUp.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ToolButtonUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolButtonUp.Name = "ToolButtonUp";
            this.ToolButtonUp.Size = new System.Drawing.Size(40, 36);
            this.ToolButtonUp.Text = "Au dessus";
            this.ToolButtonUp.Click += new System.EventHandler(this.ToolButtonUp_Click);
            // 
            // ToolButtonDown
            // 
            this.ToolButtonDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolButtonDown.Image = ((System.Drawing.Image)(resources.GetObject("ToolButtonDown.Image")));
            this.ToolButtonDown.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ToolButtonDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolButtonDown.Name = "ToolButtonDown";
            this.ToolButtonDown.Size = new System.Drawing.Size(40, 36);
            this.ToolButtonDown.Text = "En dessous";
            this.ToolButtonDown.Click += new System.EventHandler(this.ToolButtonDown_Click);
            // 
            // ToolButtonCut
            // 
            this.ToolButtonCut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolButtonCut.Image = ((System.Drawing.Image)(resources.GetObject("ToolButtonCut.Image")));
            this.ToolButtonCut.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ToolButtonCut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolButtonCut.Name = "ToolButtonCut";
            this.ToolButtonCut.Size = new System.Drawing.Size(40, 36);
            this.ToolButtonCut.Text = "Supprimer la page";
            this.ToolButtonCut.Click += new System.EventHandler(this.ToolButtonCut_Click);
            // 
            // PdfViewer
            // 
            this.PdfViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PdfViewer.Location = new System.Drawing.Point(198, 9);
            this.PdfViewer.Margin = new System.Windows.Forms.Padding(0);
            this.PdfViewer.Name = "PdfViewer";
            this.PdfViewer.Page = 0;
            this.PdfViewer.Rotation = PdfiumViewer.PdfRotation.Rotate0;
            this.PdfViewer.Size = new System.Drawing.Size(553, 618);
            this.PdfViewer.TabIndex = 2;
            this.PdfViewer.ZoomMode = PdfiumViewer.PdfViewerZoomMode.FitWidth;
            // 
            // ButtonSave
            // 
            this.ButtonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonSave.Location = new System.Drawing.Point(617, 640);
            this.ButtonSave.Name = "ButtonSave";
            this.ButtonSave.Size = new System.Drawing.Size(123, 28);
            this.ButtonSave.TabIndex = 22;
            this.ButtonSave.Text = "Enregistrer et fermer";
            this.ButtonSave.UseVisualStyleBackColor = true;
            this.ButtonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // EditPdfForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 680);
            this.Controls.Add(this.ButtonSave);
            this.Controls.Add(this.PdfViewer);
            this.Controls.Add(this.MainToolbar);
            this.Controls.Add(this.ListBoxPages);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.Name = "EditPdfForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Editeur de PDF";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EditPdfForm_FormClosed);
            this.Load += new System.EventHandler(this.EditPdfForm_Load);
            this.MainToolbar.ResumeLayout(false);
            this.MainToolbar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox ListBoxPages;
        private System.Windows.Forms.ToolStrip MainToolbar;
        private System.Windows.Forms.ToolStripButton ToolButtonUp;
        private System.Windows.Forms.ToolStripButton ToolButtonDown;
        private System.Windows.Forms.ToolStripButton ToolButtonCut;
        private PdfiumViewer.PdfRenderer PdfViewer;
        private System.Windows.Forms.Button ButtonSave;
    }
}