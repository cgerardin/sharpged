namespace SharpGED_client
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
            this.BrowseButton = new System.Windows.Forms.Button();
            this.PdfViewer = new System.Windows.Forms.WebBrowser();
            this.ButtonDisconnect = new System.Windows.Forms.Button();
            this.ButtonStopServer = new System.Windows.Forms.Button();
            this.ButtonInitServer = new System.Windows.Forms.Button();
            this.ListBoxFiles = new System.Windows.Forms.ListBox();
            this.LabelNbPages = new System.Windows.Forms.Label();
            this.LabelPdfName = new System.Windows.Forms.Label();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // addPdfDialog
            // 
            this.addPdfDialog.Filter = "Documents PDF|*.pdf";
            // 
            // BrowseButton
            // 
            this.BrowseButton.Location = new System.Drawing.Point(12, 12);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(54, 23);
            this.BrowseButton.TabIndex = 0;
            this.BrowseButton.Text = "Ajouter";
            this.BrowseButton.UseVisualStyleBackColor = true;
            this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // PdfViewer
            // 
            this.PdfViewer.AllowWebBrowserDrop = false;
            this.PdfViewer.IsWebBrowserContextMenuEnabled = false;
            this.PdfViewer.Location = new System.Drawing.Point(483, 28);
            this.PdfViewer.MinimumSize = new System.Drawing.Size(20, 20);
            this.PdfViewer.Name = "PdfViewer";
            this.PdfViewer.Size = new System.Drawing.Size(656, 733);
            this.PdfViewer.TabIndex = 5;
            this.PdfViewer.WebBrowserShortcutsEnabled = false;
            // 
            // ButtonDisconnect
            // 
            this.ButtonDisconnect.Location = new System.Drawing.Point(72, 738);
            this.ButtonDisconnect.Name = "ButtonDisconnect";
            this.ButtonDisconnect.Size = new System.Drawing.Size(111, 23);
            this.ButtonDisconnect.TabIndex = 10;
            this.ButtonDisconnect.Text = "Déconnecter";
            this.ButtonDisconnect.UseVisualStyleBackColor = true;
            this.ButtonDisconnect.Click += new System.EventHandler(this.ButtonDisconnect_Click);
            // 
            // ButtonStopServer
            // 
            this.ButtonStopServer.Location = new System.Drawing.Point(249, 738);
            this.ButtonStopServer.Name = "ButtonStopServer";
            this.ButtonStopServer.Size = new System.Drawing.Size(111, 23);
            this.ButtonStopServer.TabIndex = 12;
            this.ButtonStopServer.Text = "Arrêter le serveur";
            this.ButtonStopServer.UseVisualStyleBackColor = true;
            this.ButtonStopServer.Click += new System.EventHandler(this.ButtonStopServer_Click);
            // 
            // ButtonInitServer
            // 
            this.ButtonInitServer.Location = new System.Drawing.Point(366, 738);
            this.ButtonInitServer.Name = "ButtonInitServer";
            this.ButtonInitServer.Size = new System.Drawing.Size(111, 23);
            this.ButtonInitServer.TabIndex = 14;
            this.ButtonInitServer.Text = "Initialiser le serveur";
            this.ButtonInitServer.UseVisualStyleBackColor = true;
            this.ButtonInitServer.Click += new System.EventHandler(this.ButtonInitServer_Click);
            // 
            // ListBoxFiles
            // 
            this.ListBoxFiles.DisplayMember = "title";
            this.ListBoxFiles.FormattingEnabled = true;
            this.ListBoxFiles.Location = new System.Drawing.Point(72, 12);
            this.ListBoxFiles.Name = "ListBoxFiles";
            this.ListBoxFiles.Size = new System.Drawing.Size(405, 719);
            this.ListBoxFiles.TabIndex = 15;
            this.ListBoxFiles.ValueMember = "hash";
            this.ListBoxFiles.SelectedIndexChanged += new System.EventHandler(this.ListBoxFiles_SelectedIndexChanged);
            // 
            // LabelNbPages
            // 
            this.LabelNbPages.Location = new System.Drawing.Point(1063, 9);
            this.LabelNbPages.Name = "LabelNbPages";
            this.LabelNbPages.Size = new System.Drawing.Size(76, 16);
            this.LabelNbPages.TabIndex = 17;
            this.LabelNbPages.Text = "(0 pages)";
            this.LabelNbPages.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // LabelPdfName
            // 
            this.LabelPdfName.AutoSize = true;
            this.LabelPdfName.Location = new System.Drawing.Point(483, 8);
            this.LabelPdfName.Name = "LabelPdfName";
            this.LabelPdfName.Size = new System.Drawing.Size(13, 13);
            this.LabelPdfName.TabIndex = 18;
            this.LabelPdfName.Text = "  ";
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(12, 41);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(54, 23);
            this.DeleteButton.TabIndex = 19;
            this.DeleteButton.Text = "Suppr.";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1151, 773);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.LabelPdfName);
            this.Controls.Add(this.LabelNbPages);
            this.Controls.Add(this.ListBoxFiles);
            this.Controls.Add(this.ButtonInitServer);
            this.Controls.Add(this.ButtonStopServer);
            this.Controls.Add(this.ButtonDisconnect);
            this.Controls.Add(this.PdfViewer);
            this.Controls.Add(this.BrowseButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "SharpGED";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog addPdfDialog;
        private System.Windows.Forms.Button BrowseButton;
        private System.Windows.Forms.WebBrowser PdfViewer;
        private System.Windows.Forms.Button ButtonDisconnect;
        private System.Windows.Forms.Button ButtonStopServer;
        private System.Windows.Forms.Button ButtonInitServer;
        private System.Windows.Forms.ListBox ListBoxFiles;
        private System.Windows.Forms.Label LabelNbPages;
        private System.Windows.Forms.Label LabelPdfName;
        private System.Windows.Forms.Button DeleteButton;
    }
}

