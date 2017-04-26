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
            this.addPdfDialog = new System.Windows.Forms.OpenFileDialog();
            this.BrowseButton = new System.Windows.Forms.Button();
            this.TextBoxPdfName = new System.Windows.Forms.TextBox();
            this.ButtonEclaterPdf = new System.Windows.Forms.Button();
            this.LabelNbPages = new System.Windows.Forms.Label();
            this.PdfViewer = new System.Windows.Forms.WebBrowser();
            this.ListBoxPages = new System.Windows.Forms.ListBox();
            this.TextBoxRemoteCmd = new System.Windows.Forms.TextBox();
            this.ButtonDisconnect = new System.Windows.Forms.Button();
            this.ButtonSend = new System.Windows.Forms.Button();
            this.ButtonStopServer = new System.Windows.Forms.Button();
            this.ButtonGet = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // addPdfDialog
            // 
            this.addPdfDialog.Filter = "Documents PDF|*.pdf";
            // 
            // BrowseButton
            // 
            this.BrowseButton.Location = new System.Drawing.Point(29, 28);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(54, 28);
            this.BrowseButton.TabIndex = 0;
            this.BrowseButton.Text = "...";
            this.BrowseButton.UseVisualStyleBackColor = true;
            this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // TextBoxPdfName
            // 
            this.TextBoxPdfName.Location = new System.Drawing.Point(89, 33);
            this.TextBoxPdfName.Name = "TextBoxPdfName";
            this.TextBoxPdfName.Size = new System.Drawing.Size(296, 20);
            this.TextBoxPdfName.TabIndex = 1;
            // 
            // ButtonEclaterPdf
            // 
            this.ButtonEclaterPdf.Location = new System.Drawing.Point(310, 73);
            this.ButtonEclaterPdf.Name = "ButtonEclaterPdf";
            this.ButtonEclaterPdf.Size = new System.Drawing.Size(75, 23);
            this.ButtonEclaterPdf.TabIndex = 2;
            this.ButtonEclaterPdf.Text = "Eclater";
            this.ButtonEclaterPdf.UseVisualStyleBackColor = true;
            this.ButtonEclaterPdf.Click += new System.EventHandler(this.ButtonEclaterPdf_Click);
            // 
            // LabelNbPages
            // 
            this.LabelNbPages.AutoSize = true;
            this.LabelNbPages.Location = new System.Drawing.Point(391, 36);
            this.LabelNbPages.Name = "LabelNbPages";
            this.LabelNbPages.Size = new System.Drawing.Size(51, 13);
            this.LabelNbPages.TabIndex = 3;
            this.LabelNbPages.Text = "(0 pages)";
            // 
            // PdfViewer
            // 
            this.PdfViewer.AllowWebBrowserDrop = false;
            this.PdfViewer.IsWebBrowserContextMenuEnabled = false;
            this.PdfViewer.Location = new System.Drawing.Point(483, 28);
            this.PdfViewer.MinimumSize = new System.Drawing.Size(20, 20);
            this.PdfViewer.Name = "PdfViewer";
            this.PdfViewer.Size = new System.Drawing.Size(656, 904);
            this.PdfViewer.TabIndex = 5;
            this.PdfViewer.WebBrowserShortcutsEnabled = false;
            // 
            // ListBoxPages
            // 
            this.ListBoxPages.FormattingEnabled = true;
            this.ListBoxPages.Location = new System.Drawing.Point(29, 111);
            this.ListBoxPages.Name = "ListBoxPages";
            this.ListBoxPages.Size = new System.Drawing.Size(356, 368);
            this.ListBoxPages.TabIndex = 6;
            this.ListBoxPages.SelectedIndexChanged += new System.EventHandler(this.ListBoxPages_SelectedIndexChanged);
            // 
            // TextBoxRemoteCmd
            // 
            this.TextBoxRemoteCmd.Location = new System.Drawing.Point(7, 882);
            this.TextBoxRemoteCmd.Name = "TextBoxRemoteCmd";
            this.TextBoxRemoteCmd.Size = new System.Drawing.Size(155, 20);
            this.TextBoxRemoteCmd.TabIndex = 8;
            // 
            // ButtonDisconnect
            // 
            this.ButtonDisconnect.Location = new System.Drawing.Point(402, 880);
            this.ButtonDisconnect.Name = "ButtonDisconnect";
            this.ButtonDisconnect.Size = new System.Drawing.Size(75, 23);
            this.ButtonDisconnect.TabIndex = 10;
            this.ButtonDisconnect.Text = "Déconnecter";
            this.ButtonDisconnect.UseVisualStyleBackColor = true;
            this.ButtonDisconnect.Click += new System.EventHandler(this.ButtonDisconnect_Click);
            // 
            // ButtonSend
            // 
            this.ButtonSend.Location = new System.Drawing.Point(165, 880);
            this.ButtonSend.Name = "ButtonSend";
            this.ButtonSend.Size = new System.Drawing.Size(75, 23);
            this.ButtonSend.TabIndex = 11;
            this.ButtonSend.Text = "Envoyer";
            this.ButtonSend.UseVisualStyleBackColor = true;
            this.ButtonSend.Click += new System.EventHandler(this.ButtonSend_Click);
            // 
            // ButtonStopServer
            // 
            this.ButtonStopServer.Location = new System.Drawing.Point(260, 880);
            this.ButtonStopServer.Name = "ButtonStopServer";
            this.ButtonStopServer.Size = new System.Drawing.Size(136, 23);
            this.ButtonStopServer.TabIndex = 12;
            this.ButtonStopServer.Text = "Arrêter le serveur";
            this.ButtonStopServer.UseVisualStyleBackColor = true;
            this.ButtonStopServer.Click += new System.EventHandler(this.ButtonStopServer_Click);
            // 
            // ButtonGet
            // 
            this.ButtonGet.Location = new System.Drawing.Point(166, 853);
            this.ButtonGet.Margin = new System.Windows.Forms.Padding(1);
            this.ButtonGet.Name = "ButtonGet";
            this.ButtonGet.Size = new System.Drawing.Size(75, 23);
            this.ButtonGet.TabIndex = 13;
            this.ButtonGet.Text = "Recevoir";
            this.ButtonGet.UseVisualStyleBackColor = true;
            this.ButtonGet.Click += new System.EventHandler(this.ButtonGet_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1151, 943);
            this.Controls.Add(this.ButtonGet);
            this.Controls.Add(this.ButtonStopServer);
            this.Controls.Add(this.ButtonSend);
            this.Controls.Add(this.ButtonDisconnect);
            this.Controls.Add(this.TextBoxRemoteCmd);
            this.Controls.Add(this.ListBoxPages);
            this.Controls.Add(this.PdfViewer);
            this.Controls.Add(this.LabelNbPages);
            this.Controls.Add(this.ButtonEclaterPdf);
            this.Controls.Add(this.TextBoxPdfName);
            this.Controls.Add(this.BrowseButton);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog addPdfDialog;
        private System.Windows.Forms.Button BrowseButton;
        private System.Windows.Forms.TextBox TextBoxPdfName;
        private System.Windows.Forms.Button ButtonEclaterPdf;
        private System.Windows.Forms.Label LabelNbPages;
        private System.Windows.Forms.WebBrowser PdfViewer;
        private System.Windows.Forms.ListBox ListBoxPages;
        private System.Windows.Forms.TextBox TextBoxRemoteCmd;
        private System.Windows.Forms.Button ButtonDisconnect;
        private System.Windows.Forms.Button ButtonSend;
        private System.Windows.Forms.Button ButtonStopServer;
        private System.Windows.Forms.Button ButtonGet;
    }
}

