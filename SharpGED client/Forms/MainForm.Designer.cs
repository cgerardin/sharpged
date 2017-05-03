﻿namespace SharpGED_client
{
    partial class MainForm
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.addPdfDialog = new System.Windows.Forms.OpenFileDialog();
            this.LabelPdfName = new System.Windows.Forms.Label();
            this.LabelNbPages = new System.Windows.Forms.Label();
            this.MainToolbar = new System.Windows.Forms.ToolStrip();
            this.ToolButtonNewFile = new System.Windows.Forms.ToolStripButton();
            this.ToolButtonDeleteFile = new System.Windows.Forms.ToolStripButton();
            this.ToolButtonEditFile = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolButtonDisconnect = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolButtonStopServer = new System.Windows.Forms.ToolStripButton();
            this.ToolButtonInitDatabase = new System.Windows.Forms.ToolStripButton();
            this.MainSplitContainer = new System.Windows.Forms.SplitContainer();
            this.ListBoxFiles = new System.Windows.Forms.ListBox();
            this.PdfViewer = new System.Windows.Forms.WebBrowser();
            this.MainToolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitContainer)).BeginInit();
            this.MainSplitContainer.Panel1.SuspendLayout();
            this.MainSplitContainer.Panel2.SuspendLayout();
            this.MainSplitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // addPdfDialog
            // 
            this.addPdfDialog.Filter = "Documents PDF|*.pdf";
            // 
            // LabelPdfName
            // 
            this.LabelPdfName.AutoSize = true;
            this.LabelPdfName.Location = new System.Drawing.Point(451, 746);
            this.LabelPdfName.Name = "LabelPdfName";
            this.LabelPdfName.Size = new System.Drawing.Size(13, 13);
            this.LabelPdfName.TabIndex = 18;
            this.LabelPdfName.Text = "  ";
            // 
            // LabelNbPages
            // 
            this.LabelNbPages.Location = new System.Drawing.Point(1074, 746);
            this.LabelNbPages.Name = "LabelNbPages";
            this.LabelNbPages.Size = new System.Drawing.Size(76, 16);
            this.LabelNbPages.TabIndex = 17;
            this.LabelNbPages.Text = "(0 pages)";
            this.LabelNbPages.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // MainToolbar
            // 
            this.MainToolbar.Dock = System.Windows.Forms.DockStyle.Left;
            this.MainToolbar.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.MainToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolButtonNewFile,
            this.ToolButtonDeleteFile,
            this.ToolButtonEditFile,
            this.toolStripSeparator1,
            this.ToolButtonStopServer,
            this.ToolButtonInitDatabase,
            this.toolStripSeparator2,
            this.ToolButtonDisconnect});
            this.MainToolbar.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.MainToolbar.Location = new System.Drawing.Point(0, 0);
            this.MainToolbar.Name = "MainToolbar";
            this.MainToolbar.Size = new System.Drawing.Size(37, 773);
            this.MainToolbar.TabIndex = 20;
            this.MainToolbar.Text = "toolStrip1";
            // 
            // ToolButtonNewFile
            // 
            this.ToolButtonNewFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolButtonNewFile.Image = ((System.Drawing.Image)(resources.GetObject("ToolButtonNewFile.Image")));
            this.ToolButtonNewFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolButtonNewFile.Name = "ToolButtonNewFile";
            this.ToolButtonNewFile.Size = new System.Drawing.Size(34, 36);
            this.ToolButtonNewFile.Text = "Ajouter un fichier";
            this.ToolButtonNewFile.Click += new System.EventHandler(this.ToolButtonNewFile_Click);
            // 
            // ToolButtonDeleteFile
            // 
            this.ToolButtonDeleteFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolButtonDeleteFile.Image = ((System.Drawing.Image)(resources.GetObject("ToolButtonDeleteFile.Image")));
            this.ToolButtonDeleteFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolButtonDeleteFile.Name = "ToolButtonDeleteFile";
            this.ToolButtonDeleteFile.Size = new System.Drawing.Size(34, 36);
            this.ToolButtonDeleteFile.Text = "Supprimer le fichier sélectionné";
            this.ToolButtonDeleteFile.ToolTipText = "Supprimer le fichier sélectionné";
            this.ToolButtonDeleteFile.Click += new System.EventHandler(this.ToolButtonDeleteFile_Click);
            // 
            // ToolButtonEditFile
            // 
            this.ToolButtonEditFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolButtonEditFile.Image = ((System.Drawing.Image)(resources.GetObject("ToolButtonEditFile.Image")));
            this.ToolButtonEditFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolButtonEditFile.Name = "ToolButtonEditFile";
            this.ToolButtonEditFile.Size = new System.Drawing.Size(34, 36);
            this.ToolButtonEditFile.Text = "Editer le fichier sélectionné";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(34, 6);
            // 
            // ToolButtonDisconnect
            // 
            this.ToolButtonDisconnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolButtonDisconnect.Image = ((System.Drawing.Image)(resources.GetObject("ToolButtonDisconnect.Image")));
            this.ToolButtonDisconnect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolButtonDisconnect.Name = "ToolButtonDisconnect";
            this.ToolButtonDisconnect.Size = new System.Drawing.Size(34, 36);
            this.ToolButtonDisconnect.Text = "Se déconnecter du serveur";
            this.ToolButtonDisconnect.Click += new System.EventHandler(this.ToolButtonDisconnect_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(34, 6);
            // 
            // ToolButtonStopServer
            // 
            this.ToolButtonStopServer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolButtonStopServer.Image = ((System.Drawing.Image)(resources.GetObject("ToolButtonStopServer.Image")));
            this.ToolButtonStopServer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolButtonStopServer.Name = "ToolButtonStopServer";
            this.ToolButtonStopServer.Size = new System.Drawing.Size(34, 36);
            this.ToolButtonStopServer.Text = "Arrêter le serveur";
            this.ToolButtonStopServer.Click += new System.EventHandler(this.ToolButtonStopServer_Click);
            // 
            // ToolButtonInitDatabase
            // 
            this.ToolButtonInitDatabase.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolButtonInitDatabase.Image = ((System.Drawing.Image)(resources.GetObject("ToolButtonInitDatabase.Image")));
            this.ToolButtonInitDatabase.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolButtonInitDatabase.Name = "ToolButtonInitDatabase";
            this.ToolButtonInitDatabase.Size = new System.Drawing.Size(34, 36);
            this.ToolButtonInitDatabase.Text = "Initialiser la base de données";
            this.ToolButtonInitDatabase.ToolTipText = "Initialiser la base de données";
            this.ToolButtonInitDatabase.Click += new System.EventHandler(this.ToolButtonInitDatabase_Click);
            // 
            // MainSplitContainer
            // 
            this.MainSplitContainer.Location = new System.Drawing.Point(37, 2);
            this.MainSplitContainer.Name = "MainSplitContainer";
            // 
            // MainSplitContainer.Panel1
            // 
            this.MainSplitContainer.Panel1.Controls.Add(this.ListBoxFiles);
            // 
            // MainSplitContainer.Panel2
            // 
            this.MainSplitContainer.Panel2.Controls.Add(this.PdfViewer);
            this.MainSplitContainer.Size = new System.Drawing.Size(1113, 741);
            this.MainSplitContainer.SplitterDistance = 371;
            this.MainSplitContainer.TabIndex = 21;
            this.MainSplitContainer.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.MainSplitContainer_SplitterMoved);
            // 
            // ListBoxFiles
            // 
            this.ListBoxFiles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ListBoxFiles.DisplayMember = "title";
            this.ListBoxFiles.FormattingEnabled = true;
            this.ListBoxFiles.Location = new System.Drawing.Point(0, 0);
            this.ListBoxFiles.Margin = new System.Windows.Forms.Padding(0);
            this.ListBoxFiles.Name = "ListBoxFiles";
            this.ListBoxFiles.Size = new System.Drawing.Size(365, 728);
            this.ListBoxFiles.TabIndex = 16;
            this.ListBoxFiles.ValueMember = "hash";
            this.ListBoxFiles.SelectedIndexChanged += new System.EventHandler(this.ListBoxFiles_SelectedIndexChanged);
            // 
            // PdfViewer
            // 
            this.PdfViewer.AllowWebBrowserDrop = false;
            this.PdfViewer.IsWebBrowserContextMenuEnabled = false;
            this.PdfViewer.Location = new System.Drawing.Point(0, 0);
            this.PdfViewer.Margin = new System.Windows.Forms.Padding(0);
            this.PdfViewer.MinimumSize = new System.Drawing.Size(20, 20);
            this.PdfViewer.Name = "PdfViewer";
            this.PdfViewer.Size = new System.Drawing.Size(736, 732);
            this.PdfViewer.TabIndex = 6;
            this.PdfViewer.WebBrowserShortcutsEnabled = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1151, 773);
            this.Controls.Add(this.MainSplitContainer);
            this.Controls.Add(this.MainToolbar);
            this.Controls.Add(this.LabelPdfName);
            this.Controls.Add(this.LabelNbPages);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "SharpGED";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MainToolbar.ResumeLayout(false);
            this.MainToolbar.PerformLayout();
            this.MainSplitContainer.Panel1.ResumeLayout(false);
            this.MainSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitContainer)).EndInit();
            this.MainSplitContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog addPdfDialog;
        private System.Windows.Forms.Label LabelPdfName;
        private System.Windows.Forms.Label LabelNbPages;
        private System.Windows.Forms.ToolStrip MainToolbar;
        private System.Windows.Forms.ToolStripButton ToolButtonNewFile;
        private System.Windows.Forms.ToolStripButton ToolButtonDeleteFile;
        private System.Windows.Forms.ToolStripButton ToolButtonEditFile;
        private System.Windows.Forms.ToolStripButton ToolButtonDisconnect;
        private System.Windows.Forms.ToolStripButton ToolButtonStopServer;
        private System.Windows.Forms.ToolStripButton ToolButtonInitDatabase;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.SplitContainer MainSplitContainer;
        private System.Windows.Forms.ListBox ListBoxFiles;
        private System.Windows.Forms.WebBrowser PdfViewer;
    }
}

