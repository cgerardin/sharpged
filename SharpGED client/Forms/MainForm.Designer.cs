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
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Nœud1");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("Nœud2");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("Nœud3");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("Nœud0", new System.Windows.Forms.TreeNode[] {
            treeNode15,
            treeNode16,
            treeNode17});
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("Nœud5");
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("Nœud6");
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("Nœud4", new System.Windows.Forms.TreeNode[] {
            treeNode19,
            treeNode20});
            this.addPdfDialog = new System.Windows.Forms.OpenFileDialog();
            this.LabelPdfName = new System.Windows.Forms.Label();
            this.LabelNbPages = new System.Windows.Forms.Label();
            this.MainToolbar = new System.Windows.Forms.ToolStrip();
            this.ToolButtonNewFile = new System.Windows.Forms.ToolStripButton();
            this.ToolButtonDeleteFile = new System.Windows.Forms.ToolStripButton();
            this.ToolButtonEditFile = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolButtonStopServer = new System.Windows.Forms.ToolStripButton();
            this.ToolButtonInitDatabase = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolButtonDisconnect = new System.Windows.Forms.ToolStripButton();
            this.MainSplitContainer = new System.Windows.Forms.SplitContainer();
            this.ChildSplitContainer = new System.Windows.Forms.SplitContainer();
            this.TreeViewCategories = new System.Windows.Forms.TreeView();
            this.label2 = new System.Windows.Forms.Label();
            this.PropertiesGroupBox = new System.Windows.Forms.GroupBox();
            this.OriginalNameLabel = new System.Windows.Forms.Label();
            this.ListBoxFiles = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PdfViewer = new System.Windows.Forms.WebBrowser();
            this.ToolButtonPrint = new System.Windows.Forms.ToolStripButton();
            this.ToolButtonScan = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.AdobeReader = new AxAcroPDFLib.AxAcroPDF();
            this.MainToolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitContainer)).BeginInit();
            this.MainSplitContainer.Panel1.SuspendLayout();
            this.MainSplitContainer.Panel2.SuspendLayout();
            this.MainSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChildSplitContainer)).BeginInit();
            this.ChildSplitContainer.Panel1.SuspendLayout();
            this.ChildSplitContainer.Panel2.SuspendLayout();
            this.ChildSplitContainer.SuspendLayout();
            this.PropertiesGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AdobeReader)).BeginInit();
            this.SuspendLayout();
            // 
            // addPdfDialog
            // 
            this.addPdfDialog.Filter = "Documents PDF|*.pdf";
            // 
            // LabelPdfName
            // 
            this.LabelPdfName.AutoSize = true;
            this.LabelPdfName.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelPdfName.Location = new System.Drawing.Point(-7, 15);
            this.LabelPdfName.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.LabelPdfName.Name = "LabelPdfName";
            this.LabelPdfName.Size = new System.Drawing.Size(26, 37);
            this.LabelPdfName.TabIndex = 18;
            this.LabelPdfName.Text = "-";
            // 
            // LabelNbPages
            // 
            this.LabelNbPages.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelNbPages.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelNbPages.Location = new System.Drawing.Point(1647, 15);
            this.LabelNbPages.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.LabelNbPages.Name = "LabelNbPages";
            this.LabelNbPages.Size = new System.Drawing.Size(190, 46);
            this.LabelNbPages.TabIndex = 17;
            this.LabelNbPages.Text = "(0 pages)";
            this.LabelNbPages.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // MainToolbar
            // 
            this.MainToolbar.Dock = System.Windows.Forms.DockStyle.Left;
            this.MainToolbar.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainToolbar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.MainToolbar.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.MainToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolButtonNewFile,
            this.ToolButtonDeleteFile,
            this.ToolButtonEditFile,
            this.toolStripSeparator1,
            this.ToolButtonPrint,
            this.ToolButtonScan,
            this.toolStripSeparator2,
            this.ToolButtonStopServer,
            this.ToolButtonInitDatabase,
            this.toolStripSeparator3,
            this.ToolButtonDisconnect});
            this.MainToolbar.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.MainToolbar.Location = new System.Drawing.Point(0, 0);
            this.MainToolbar.Name = "MainToolbar";
            this.MainToolbar.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.MainToolbar.Size = new System.Drawing.Size(38, 2095);
            this.MainToolbar.TabIndex = 20;
            this.MainToolbar.Text = "toolStrip1";
            // 
            // ToolButtonNewFile
            // 
            this.ToolButtonNewFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolButtonNewFile.Image = ((System.Drawing.Image)(resources.GetObject("ToolButtonNewFile.Image")));
            this.ToolButtonNewFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolButtonNewFile.Name = "ToolButtonNewFile";
            this.ToolButtonNewFile.Size = new System.Drawing.Size(33, 36);
            this.ToolButtonNewFile.Text = "Ajouter un document";
            this.ToolButtonNewFile.Click += new System.EventHandler(this.ToolButtonNewFile_Click);
            // 
            // ToolButtonDeleteFile
            // 
            this.ToolButtonDeleteFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolButtonDeleteFile.Image = ((System.Drawing.Image)(resources.GetObject("ToolButtonDeleteFile.Image")));
            this.ToolButtonDeleteFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolButtonDeleteFile.Name = "ToolButtonDeleteFile";
            this.ToolButtonDeleteFile.Size = new System.Drawing.Size(33, 36);
            this.ToolButtonDeleteFile.Text = "Supprimer le document sélectionné";
            this.ToolButtonDeleteFile.ToolTipText = "Supprimer le fichier sélectionné";
            this.ToolButtonDeleteFile.Click += new System.EventHandler(this.ToolButtonDeleteFile_Click);
            // 
            // ToolButtonEditFile
            // 
            this.ToolButtonEditFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolButtonEditFile.Image = ((System.Drawing.Image)(resources.GetObject("ToolButtonEditFile.Image")));
            this.ToolButtonEditFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolButtonEditFile.Name = "ToolButtonEditFile";
            this.ToolButtonEditFile.Size = new System.Drawing.Size(33, 36);
            this.ToolButtonEditFile.Text = "Editer le document sélectionné";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(33, 6);
            // 
            // ToolButtonStopServer
            // 
            this.ToolButtonStopServer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolButtonStopServer.Image = ((System.Drawing.Image)(resources.GetObject("ToolButtonStopServer.Image")));
            this.ToolButtonStopServer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolButtonStopServer.Name = "ToolButtonStopServer";
            this.ToolButtonStopServer.Size = new System.Drawing.Size(33, 36);
            this.ToolButtonStopServer.Text = "Arrêter le serveur";
            this.ToolButtonStopServer.Click += new System.EventHandler(this.ToolButtonStopServer_Click);
            // 
            // ToolButtonInitDatabase
            // 
            this.ToolButtonInitDatabase.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolButtonInitDatabase.Image = ((System.Drawing.Image)(resources.GetObject("ToolButtonInitDatabase.Image")));
            this.ToolButtonInitDatabase.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolButtonInitDatabase.Name = "ToolButtonInitDatabase";
            this.ToolButtonInitDatabase.Size = new System.Drawing.Size(33, 36);
            this.ToolButtonInitDatabase.Text = "Initialiser la base de données";
            this.ToolButtonInitDatabase.ToolTipText = "Initialiser la base de données";
            this.ToolButtonInitDatabase.Click += new System.EventHandler(this.ToolButtonInitDatabase_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(33, 6);
            // 
            // ToolButtonDisconnect
            // 
            this.ToolButtonDisconnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolButtonDisconnect.Image = ((System.Drawing.Image)(resources.GetObject("ToolButtonDisconnect.Image")));
            this.ToolButtonDisconnect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolButtonDisconnect.Name = "ToolButtonDisconnect";
            this.ToolButtonDisconnect.Size = new System.Drawing.Size(33, 36);
            this.ToolButtonDisconnect.Text = "Se déconnecter du serveur";
            this.ToolButtonDisconnect.Click += new System.EventHandler(this.ToolButtonDisconnect_Click);
            // 
            // MainSplitContainer
            // 
            this.MainSplitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainSplitContainer.Location = new System.Drawing.Point(81, 5);
            this.MainSplitContainer.Margin = new System.Windows.Forms.Padding(7, 9, 7, 9);
            this.MainSplitContainer.Name = "MainSplitContainer";
            // 
            // MainSplitContainer.Panel1
            // 
            this.MainSplitContainer.Panel1.Controls.Add(this.ChildSplitContainer);
            // 
            // MainSplitContainer.Panel2
            // 
            this.MainSplitContainer.Panel2.Controls.Add(this.AdobeReader);
            this.MainSplitContainer.Panel2.Controls.Add(this.PdfViewer);
            this.MainSplitContainer.Panel2.Controls.Add(this.LabelNbPages);
            this.MainSplitContainer.Panel2.Controls.Add(this.LabelPdfName);
            this.MainSplitContainer.Size = new System.Drawing.Size(2799, 2090);
            this.MainSplitContainer.SplitterDistance = 933;
            this.MainSplitContainer.SplitterWidth = 10;
            this.MainSplitContainer.TabIndex = 21;
            // 
            // ChildSplitContainer
            // 
            this.ChildSplitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ChildSplitContainer.Location = new System.Drawing.Point(0, -5);
            this.ChildSplitContainer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ChildSplitContainer.Name = "ChildSplitContainer";
            // 
            // ChildSplitContainer.Panel1
            // 
            this.ChildSplitContainer.Panel1.Controls.Add(this.TreeViewCategories);
            this.ChildSplitContainer.Panel1.Controls.Add(this.label2);
            // 
            // ChildSplitContainer.Panel2
            // 
            this.ChildSplitContainer.Panel2.Controls.Add(this.PropertiesGroupBox);
            this.ChildSplitContainer.Panel2.Controls.Add(this.ListBoxFiles);
            this.ChildSplitContainer.Panel2.Controls.Add(this.label1);
            this.ChildSplitContainer.Size = new System.Drawing.Size(940, 2095);
            this.ChildSplitContainer.SplitterDistance = 313;
            this.ChildSplitContainer.TabIndex = 20;
            this.ChildSplitContainer.Resize += new System.EventHandler(this.ChildSplitContainer_Resize);
            // 
            // TreeViewCategories
            // 
            this.TreeViewCategories.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TreeViewCategories.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TreeViewCategories.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TreeViewCategories.Location = new System.Drawing.Point(0, 74);
            this.TreeViewCategories.Margin = new System.Windows.Forms.Padding(0);
            this.TreeViewCategories.Name = "TreeViewCategories";
            treeNode15.Name = "Nœud1";
            treeNode15.Text = "Nœud1";
            treeNode16.Name = "Nœud2";
            treeNode16.Text = "Nœud2";
            treeNode17.Name = "Nœud3";
            treeNode17.Text = "Nœud3";
            treeNode18.Name = "Nœud0";
            treeNode18.Text = "Nœud0";
            treeNode19.Name = "Nœud5";
            treeNode19.Text = "Nœud5";
            treeNode20.Name = "Nœud6";
            treeNode20.Text = "Nœud6";
            treeNode21.Name = "Nœud4";
            treeNode21.Text = "Nœud4";
            this.TreeViewCategories.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode18,
            treeNode21});
            this.TreeViewCategories.Size = new System.Drawing.Size(317, 2021);
            this.TreeViewCategories.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(-5, 20);
            this.label2.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 37);
            this.label2.TabIndex = 20;
            this.label2.Text = "Catégories";
            // 
            // PropertiesGroupBox
            // 
            this.PropertiesGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PropertiesGroupBox.Controls.Add(this.OriginalNameLabel);
            this.PropertiesGroupBox.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PropertiesGroupBox.Location = new System.Drawing.Point(13, 1860);
            this.PropertiesGroupBox.Name = "PropertiesGroupBox";
            this.PropertiesGroupBox.Size = new System.Drawing.Size(600, 223);
            this.PropertiesGroupBox.TabIndex = 21;
            this.PropertiesGroupBox.TabStop = false;
            this.PropertiesGroupBox.Text = "Propriétés du document";
            // 
            // OriginalNameLabel
            // 
            this.OriginalNameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OriginalNameLabel.AutoSize = true;
            this.OriginalNameLabel.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OriginalNameLabel.Location = new System.Drawing.Point(10, 40);
            this.OriginalNameLabel.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.OriginalNameLabel.Name = "OriginalNameLabel";
            this.OriginalNameLabel.Size = new System.Drawing.Size(26, 37);
            this.OriginalNameLabel.TabIndex = 19;
            this.OriginalNameLabel.Text = "-";
            // 
            // ListBoxFiles
            // 
            this.ListBoxFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListBoxFiles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ListBoxFiles.DisplayMember = "title";
            this.ListBoxFiles.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListBoxFiles.FormattingEnabled = true;
            this.ListBoxFiles.ItemHeight = 37;
            this.ListBoxFiles.Location = new System.Drawing.Point(0, 74);
            this.ListBoxFiles.Margin = new System.Windows.Forms.Padding(0);
            this.ListBoxFiles.Name = "ListBoxFiles";
            this.ListBoxFiles.ScrollAlwaysVisible = true;
            this.ListBoxFiles.Size = new System.Drawing.Size(623, 1776);
            this.ListBoxFiles.TabIndex = 16;
            this.ListBoxFiles.ValueMember = "hash";
            this.ListBoxFiles.SelectedIndexChanged += new System.EventHandler(this.ListBoxFiles_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(-5, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 37);
            this.label1.TabIndex = 19;
            this.label1.Text = "Documents";
            // 
            // PdfViewer
            // 
            this.PdfViewer.AllowWebBrowserDrop = false;
            this.PdfViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PdfViewer.IsWebBrowserContextMenuEnabled = false;
            this.PdfViewer.Location = new System.Drawing.Point(0, 69);
            this.PdfViewer.Margin = new System.Windows.Forms.Padding(0);
            this.PdfViewer.MinimumSize = new System.Drawing.Size(50, 57);
            this.PdfViewer.Name = "PdfViewer";
            this.PdfViewer.Size = new System.Drawing.Size(1844, 2021);
            this.PdfViewer.TabIndex = 6;
            this.PdfViewer.WebBrowserShortcutsEnabled = false;
            // 
            // ToolButtonPrint
            // 
            this.ToolButtonPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolButtonPrint.Image = ((System.Drawing.Image)(resources.GetObject("ToolButtonPrint.Image")));
            this.ToolButtonPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolButtonPrint.Name = "ToolButtonPrint";
            this.ToolButtonPrint.Size = new System.Drawing.Size(33, 36);
            this.ToolButtonPrint.Text = "Imprimer le document";
            this.ToolButtonPrint.Click += new System.EventHandler(this.ToolButtonPrint_Click);
            // 
            // ToolButtonScan
            // 
            this.ToolButtonScan.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolButtonScan.Image = ((System.Drawing.Image)(resources.GetObject("ToolButtonScan.Image")));
            this.ToolButtonScan.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolButtonScan.Name = "ToolButtonScan";
            this.ToolButtonScan.Size = new System.Drawing.Size(33, 36);
            this.ToolButtonScan.Text = "Numériser un document";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(33, 6);
            // 
            // AdobeReader
            // 
            this.AdobeReader.Enabled = true;
            this.AdobeReader.Location = new System.Drawing.Point(342, 28);
            this.AdobeReader.Name = "AdobeReader";
            this.AdobeReader.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("AdobeReader.OcxState")));
            this.AdobeReader.Size = new System.Drawing.Size(90, 89);
            this.AdobeReader.TabIndex = 19;
            this.AdobeReader.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2878, 2095);
            this.Controls.Add(this.MainSplitContainer);
            this.Controls.Add(this.MainToolbar);
            this.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(7, 9, 7, 9);
            this.Name = "MainForm";
            this.Text = "SharpGED";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MainToolbar.ResumeLayout(false);
            this.MainToolbar.PerformLayout();
            this.MainSplitContainer.Panel1.ResumeLayout(false);
            this.MainSplitContainer.Panel2.ResumeLayout(false);
            this.MainSplitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitContainer)).EndInit();
            this.MainSplitContainer.ResumeLayout(false);
            this.ChildSplitContainer.Panel1.ResumeLayout(false);
            this.ChildSplitContainer.Panel1.PerformLayout();
            this.ChildSplitContainer.Panel2.ResumeLayout(false);
            this.ChildSplitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChildSplitContainer)).EndInit();
            this.ChildSplitContainer.ResumeLayout(false);
            this.PropertiesGroupBox.ResumeLayout(false);
            this.PropertiesGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AdobeReader)).EndInit();
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer ChildSplitContainer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TreeView TreeViewCategories;
        private System.Windows.Forms.GroupBox PropertiesGroupBox;
        private System.Windows.Forms.Label OriginalNameLabel;
        private System.Windows.Forms.ToolStripButton ToolButtonPrint;
        private System.Windows.Forms.ToolStripButton ToolButtonScan;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private AxAcroPDFLib.AxAcroPDF AdobeReader;
    }
}

