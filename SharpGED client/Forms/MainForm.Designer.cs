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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.addPdfDialog = new System.Windows.Forms.OpenFileDialog();
            this.LabelPdfName = new System.Windows.Forms.Label();
            this.LabelNbPages = new System.Windows.Forms.Label();
            this.MainToolbar = new System.Windows.Forms.ToolStrip();
            this.toolButtonFilter = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolButtonNewFile = new System.Windows.Forms.ToolStripButton();
            this.ToolButtonRenameFile = new System.Windows.Forms.ToolStripButton();
            this.ToolButtonEditFile = new System.Windows.Forms.ToolStripButton();
            this.ToolButtonDeleteFile = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolButtonFolderAdd = new System.Windows.Forms.ToolStripButton();
            this.ToolButtonFolderRename = new System.Windows.Forms.ToolStripButton();
            this.ToolButtonFolderDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolButtonScan = new System.Windows.Forms.ToolStripButton();
            this.ToolButtonPrint = new System.Windows.Forms.ToolStripButton();
            this.ToolButtonRefresh = new System.Windows.Forms.ToolStripButton();
            this.ToolButtonStopServer = new System.Windows.Forms.ToolStripButton();
            this.ToolButtonInitDatabase = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolButtonDisconnect = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.MainSplitContainer = new System.Windows.Forms.SplitContainer();
            this.ChildSplitContainer = new System.Windows.Forms.SplitContainer();
            this.TreeViewCategories = new System.Windows.Forms.TreeView();
            this.TreeViewImageList = new System.Windows.Forms.ImageList(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.PropertiesGroupBox = new System.Windows.Forms.GroupBox();
            this.OriginalNameLabel = new System.Windows.Forms.Label();
            this.ListBoxFiles = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PdfViewer = new PdfiumViewer.PdfRenderer();
            this.printPdf = new System.Drawing.Printing.PrintDocument();
            this.printDialog = new System.Windows.Forms.PrintDialog();
            this.imageListToolbar = new System.Windows.Forms.ImageList(this.components);
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
            this.LabelPdfName.Location = new System.Drawing.Point(-3, 12);
            this.LabelPdfName.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.LabelPdfName.Name = "LabelPdfName";
            this.LabelPdfName.Size = new System.Drawing.Size(12, 17);
            this.LabelPdfName.TabIndex = 18;
            this.LabelPdfName.Text = "-";
            // 
            // LabelNbPages
            // 
            this.LabelNbPages.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelNbPages.AutoSize = true;
            this.LabelNbPages.Location = new System.Drawing.Point(775, 13);
            this.LabelNbPages.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.LabelNbPages.Name = "LabelNbPages";
            this.LabelNbPages.Size = new System.Drawing.Size(51, 13);
            this.LabelNbPages.TabIndex = 17;
            this.LabelNbPages.Text = "(0 pages)";
            this.LabelNbPages.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // MainToolbar
            // 
            this.MainToolbar.AutoSize = false;
            this.MainToolbar.Dock = System.Windows.Forms.DockStyle.Left;
            this.MainToolbar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.MainToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolButtonFilter,
            this.toolStripSeparator5,
            this.ToolButtonNewFile,
            this.ToolButtonRenameFile,
            this.ToolButtonEditFile,
            this.ToolButtonDeleteFile,
            this.toolStripSeparator1,
            this.ToolButtonFolderAdd,
            this.ToolButtonFolderRename,
            this.ToolButtonFolderDelete,
            this.toolStripSeparator4,
            this.ToolButtonScan,
            this.ToolButtonPrint,
            this.ToolButtonRefresh,
            this.ToolButtonStopServer,
            this.ToolButtonInitDatabase,
            this.toolStripSeparator2,
            this.ToolButtonDisconnect,
            this.toolStripSeparator3});
            this.MainToolbar.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.MainToolbar.Location = new System.Drawing.Point(0, 0);
            this.MainToolbar.Name = "MainToolbar";
            this.MainToolbar.Size = new System.Drawing.Size(42, 889);
            this.MainToolbar.TabIndex = 20;
            // 
            // toolButtonFilter
            // 
            this.toolButtonFilter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.toolButtonFilter.CheckOnClick = true;
            this.toolButtonFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolButtonFilter.Image = ((System.Drawing.Image)(resources.GetObject("toolButtonFilter.Image")));
            this.toolButtonFilter.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolButtonFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolButtonFilter.Name = "toolButtonFilter";
            this.toolButtonFilter.Size = new System.Drawing.Size(40, 36);
            this.toolButtonFilter.Text = "Recherche";
            this.toolButtonFilter.Click += new System.EventHandler(this.toolButtonFilter_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(40, 6);
            // 
            // ToolButtonNewFile
            // 
            this.ToolButtonNewFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolButtonNewFile.Image = ((System.Drawing.Image)(resources.GetObject("ToolButtonNewFile.Image")));
            this.ToolButtonNewFile.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ToolButtonNewFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolButtonNewFile.Name = "ToolButtonNewFile";
            this.ToolButtonNewFile.Size = new System.Drawing.Size(40, 36);
            this.ToolButtonNewFile.Text = "Ajouter un document";
            this.ToolButtonNewFile.Click += new System.EventHandler(this.ToolButtonNewFile_Click);
            // 
            // ToolButtonRenameFile
            // 
            this.ToolButtonRenameFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolButtonRenameFile.Image = ((System.Drawing.Image)(resources.GetObject("ToolButtonRenameFile.Image")));
            this.ToolButtonRenameFile.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ToolButtonRenameFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolButtonRenameFile.Name = "ToolButtonRenameFile";
            this.ToolButtonRenameFile.Size = new System.Drawing.Size(40, 36);
            this.ToolButtonRenameFile.Text = "Renommer le document sélectionné";
            this.ToolButtonRenameFile.Click += new System.EventHandler(this.ToolButtonRenameFile_Click);
            // 
            // ToolButtonEditFile
            // 
            this.ToolButtonEditFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolButtonEditFile.Image = ((System.Drawing.Image)(resources.GetObject("ToolButtonEditFile.Image")));
            this.ToolButtonEditFile.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ToolButtonEditFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolButtonEditFile.Name = "ToolButtonEditFile";
            this.ToolButtonEditFile.Size = new System.Drawing.Size(40, 36);
            this.ToolButtonEditFile.Text = "Editer le document sélectionné";
            this.ToolButtonEditFile.Click += new System.EventHandler(this.ToolButtonEditFile_Click);
            // 
            // ToolButtonDeleteFile
            // 
            this.ToolButtonDeleteFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolButtonDeleteFile.Image = ((System.Drawing.Image)(resources.GetObject("ToolButtonDeleteFile.Image")));
            this.ToolButtonDeleteFile.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ToolButtonDeleteFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolButtonDeleteFile.Name = "ToolButtonDeleteFile";
            this.ToolButtonDeleteFile.Size = new System.Drawing.Size(40, 36);
            this.ToolButtonDeleteFile.Text = "Supprimer le document sélectionné";
            this.ToolButtonDeleteFile.ToolTipText = "Supprimer le fichier sélectionné";
            this.ToolButtonDeleteFile.Click += new System.EventHandler(this.ToolButtonDeleteFile_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(40, 6);
            // 
            // ToolButtonFolderAdd
            // 
            this.ToolButtonFolderAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolButtonFolderAdd.Image = ((System.Drawing.Image)(resources.GetObject("ToolButtonFolderAdd.Image")));
            this.ToolButtonFolderAdd.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ToolButtonFolderAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolButtonFolderAdd.Name = "ToolButtonFolderAdd";
            this.ToolButtonFolderAdd.Size = new System.Drawing.Size(40, 36);
            this.ToolButtonFolderAdd.Text = "Créer un dossier";
            this.ToolButtonFolderAdd.Click += new System.EventHandler(this.ToolButtonFolderAdd_Click);
            // 
            // ToolButtonFolderRename
            // 
            this.ToolButtonFolderRename.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolButtonFolderRename.Image = ((System.Drawing.Image)(resources.GetObject("ToolButtonFolderRename.Image")));
            this.ToolButtonFolderRename.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ToolButtonFolderRename.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolButtonFolderRename.Name = "ToolButtonFolderRename";
            this.ToolButtonFolderRename.Size = new System.Drawing.Size(40, 36);
            this.ToolButtonFolderRename.Text = "Renommer le dossier sélectionné";
            this.ToolButtonFolderRename.Click += new System.EventHandler(this.ToolButtonFolderRename_Click);
            // 
            // ToolButtonFolderDelete
            // 
            this.ToolButtonFolderDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolButtonFolderDelete.Image = ((System.Drawing.Image)(resources.GetObject("ToolButtonFolderDelete.Image")));
            this.ToolButtonFolderDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ToolButtonFolderDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolButtonFolderDelete.Name = "ToolButtonFolderDelete";
            this.ToolButtonFolderDelete.Size = new System.Drawing.Size(40, 36);
            this.ToolButtonFolderDelete.Text = "Supprimer le dossier sélectionné";
            this.ToolButtonFolderDelete.Click += new System.EventHandler(this.ToolButtonFolderDelete_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(40, 6);
            // 
            // ToolButtonScan
            // 
            this.ToolButtonScan.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolButtonScan.Image = ((System.Drawing.Image)(resources.GetObject("ToolButtonScan.Image")));
            this.ToolButtonScan.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ToolButtonScan.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolButtonScan.Name = "ToolButtonScan";
            this.ToolButtonScan.Size = new System.Drawing.Size(40, 36);
            this.ToolButtonScan.Text = "Numériser un document";
            // 
            // ToolButtonPrint
            // 
            this.ToolButtonPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolButtonPrint.Image = ((System.Drawing.Image)(resources.GetObject("ToolButtonPrint.Image")));
            this.ToolButtonPrint.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ToolButtonPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolButtonPrint.Name = "ToolButtonPrint";
            this.ToolButtonPrint.Size = new System.Drawing.Size(40, 36);
            this.ToolButtonPrint.Text = "Imprimer le document";
            this.ToolButtonPrint.Click += new System.EventHandler(this.ToolButtonPrint_Click);
            // 
            // ToolButtonRefresh
            // 
            this.ToolButtonRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolButtonRefresh.Image = ((System.Drawing.Image)(resources.GetObject("ToolButtonRefresh.Image")));
            this.ToolButtonRefresh.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ToolButtonRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolButtonRefresh.Name = "ToolButtonRefresh";
            this.ToolButtonRefresh.Size = new System.Drawing.Size(40, 36);
            this.ToolButtonRefresh.Text = "Rafraîchir l\'affichage";
            this.ToolButtonRefresh.Click += new System.EventHandler(this.ToolButtonRefresh_Click);
            // 
            // ToolButtonStopServer
            // 
            this.ToolButtonStopServer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolButtonStopServer.Image = ((System.Drawing.Image)(resources.GetObject("ToolButtonStopServer.Image")));
            this.ToolButtonStopServer.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ToolButtonStopServer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolButtonStopServer.Name = "ToolButtonStopServer";
            this.ToolButtonStopServer.Size = new System.Drawing.Size(40, 36);
            this.ToolButtonStopServer.Text = "Arrêter le serveur";
            this.ToolButtonStopServer.Click += new System.EventHandler(this.ToolButtonStopServer_Click);
            // 
            // ToolButtonInitDatabase
            // 
            this.ToolButtonInitDatabase.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolButtonInitDatabase.Image = ((System.Drawing.Image)(resources.GetObject("ToolButtonInitDatabase.Image")));
            this.ToolButtonInitDatabase.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ToolButtonInitDatabase.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolButtonInitDatabase.Name = "ToolButtonInitDatabase";
            this.ToolButtonInitDatabase.Size = new System.Drawing.Size(40, 36);
            this.ToolButtonInitDatabase.Text = "Initialiser la base de données";
            this.ToolButtonInitDatabase.ToolTipText = "Initialiser la base de données";
            this.ToolButtonInitDatabase.Click += new System.EventHandler(this.ToolButtonInitDatabase_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(40, 6);
            // 
            // ToolButtonDisconnect
            // 
            this.ToolButtonDisconnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolButtonDisconnect.Image = ((System.Drawing.Image)(resources.GetObject("ToolButtonDisconnect.Image")));
            this.ToolButtonDisconnect.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ToolButtonDisconnect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolButtonDisconnect.Name = "ToolButtonDisconnect";
            this.ToolButtonDisconnect.Size = new System.Drawing.Size(40, 36);
            this.ToolButtonDisconnect.Text = "Se déconnecter du serveur";
            this.ToolButtonDisconnect.Click += new System.EventHandler(this.ToolButtonDisconnect_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(40, 6);
            // 
            // MainSplitContainer
            // 
            this.MainSplitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainSplitContainer.Location = new System.Drawing.Point(48, 0);
            this.MainSplitContainer.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.MainSplitContainer.Name = "MainSplitContainer";
            // 
            // MainSplitContainer.Panel1
            // 
            this.MainSplitContainer.Panel1.Controls.Add(this.ChildSplitContainer);
            // 
            // MainSplitContainer.Panel2
            // 
            this.MainSplitContainer.Panel2.Controls.Add(this.PdfViewer);
            this.MainSplitContainer.Panel2.Controls.Add(this.LabelNbPages);
            this.MainSplitContainer.Panel2.Controls.Add(this.LabelPdfName);
            this.MainSplitContainer.Size = new System.Drawing.Size(1552, 886);
            this.MainSplitContainer.SplitterDistance = 651;
            this.MainSplitContainer.SplitterWidth = 9;
            this.MainSplitContainer.TabIndex = 21;
            this.MainSplitContainer.TabStop = false;
            // 
            // ChildSplitContainer
            // 
            this.ChildSplitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ChildSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.ChildSplitContainer.Name = "ChildSplitContainer";
            // 
            // ChildSplitContainer.Panel1
            // 
            this.ChildSplitContainer.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.ChildSplitContainer.Panel1.Controls.Add(this.TreeViewCategories);
            this.ChildSplitContainer.Panel1.Controls.Add(this.label2);
            // 
            // ChildSplitContainer.Panel2
            // 
            this.ChildSplitContainer.Panel2.Controls.Add(this.PropertiesGroupBox);
            this.ChildSplitContainer.Panel2.Controls.Add(this.ListBoxFiles);
            this.ChildSplitContainer.Panel2.Controls.Add(this.label1);
            this.ChildSplitContainer.Size = new System.Drawing.Size(657, 886);
            this.ChildSplitContainer.SplitterDistance = 279;
            this.ChildSplitContainer.SplitterWidth = 3;
            this.ChildSplitContainer.TabIndex = 20;
            this.ChildSplitContainer.TabStop = false;
            // 
            // TreeViewCategories
            // 
            this.TreeViewCategories.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TreeViewCategories.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TreeViewCategories.FullRowSelect = true;
            this.TreeViewCategories.HideSelection = false;
            this.TreeViewCategories.ImageIndex = 1;
            this.TreeViewCategories.ImageList = this.TreeViewImageList;
            this.TreeViewCategories.Location = new System.Drawing.Point(0, 27);
            this.TreeViewCategories.Margin = new System.Windows.Forms.Padding(0);
            this.TreeViewCategories.Name = "TreeViewCategories";
            this.TreeViewCategories.SelectedImageIndex = 0;
            this.TreeViewCategories.ShowLines = false;
            this.TreeViewCategories.ShowRootLines = false;
            this.TreeViewCategories.Size = new System.Drawing.Size(279, 853);
            this.TreeViewCategories.TabIndex = 1;
            this.TreeViewCategories.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeViewCategories_AfterSelect);
            this.TreeViewCategories.Click += new System.EventHandler(this.TreeViewCategories_Click);
            this.TreeViewCategories.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TreeViewCategories_KeyDown);
            // 
            // TreeViewImageList
            // 
            this.TreeViewImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("TreeViewImageList.ImageStream")));
            this.TreeViewImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.TreeViewImageList.Images.SetKeyName(0, "Database_Small.png");
            this.TreeViewImageList.Images.SetKeyName(1, "Folder_Small.png");
            this.TreeViewImageList.Images.SetKeyName(2, "Folder_Empty_Small.png");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(-3, 12);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Dossiers";
            // 
            // PropertiesGroupBox
            // 
            this.PropertiesGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PropertiesGroupBox.Controls.Add(this.OriginalNameLabel);
            this.PropertiesGroupBox.Location = new System.Drawing.Point(0, 732);
            this.PropertiesGroupBox.Name = "PropertiesGroupBox";
            this.PropertiesGroupBox.Size = new System.Drawing.Size(371, 150);
            this.PropertiesGroupBox.TabIndex = 21;
            this.PropertiesGroupBox.TabStop = false;
            this.PropertiesGroupBox.Text = "Propriétés du document";
            // 
            // OriginalNameLabel
            // 
            this.OriginalNameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OriginalNameLabel.AutoSize = true;
            this.OriginalNameLabel.Location = new System.Drawing.Point(9, 16);
            this.OriginalNameLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.OriginalNameLabel.Name = "OriginalNameLabel";
            this.OriginalNameLabel.Size = new System.Drawing.Size(10, 13);
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
            this.ListBoxFiles.FormattingEnabled = true;
            this.ListBoxFiles.Location = new System.Drawing.Point(0, 27);
            this.ListBoxFiles.Margin = new System.Windows.Forms.Padding(0);
            this.ListBoxFiles.Name = "ListBoxFiles";
            this.ListBoxFiles.ScrollAlwaysVisible = true;
            this.ListBoxFiles.Size = new System.Drawing.Size(371, 702);
            this.ListBoxFiles.TabIndex = 2;
            this.ListBoxFiles.ValueMember = "hash";
            this.ListBoxFiles.SelectedIndexChanged += new System.EventHandler(this.ListBoxFiles_SelectedIndexChanged);
            this.ListBoxFiles.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ListBoxFiles_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(-3, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Documents";
            // 
            // PdfViewer
            // 
            this.PdfViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PdfViewer.Location = new System.Drawing.Point(0, 27);
            this.PdfViewer.Margin = new System.Windows.Forms.Padding(0);
            this.PdfViewer.Name = "PdfViewer";
            this.PdfViewer.Page = 0;
            this.PdfViewer.Rotation = PdfiumViewer.PdfRotation.Rotate0;
            this.PdfViewer.Size = new System.Drawing.Size(870, 855);
            this.PdfViewer.TabIndex = 3;
            this.PdfViewer.Visible = false;
            this.PdfViewer.ZoomMode = PdfiumViewer.PdfViewerZoomMode.FitWidth;
            // 
            // printDialog
            // 
            this.printDialog.AllowSomePages = true;
            this.printDialog.UseEXDialog = true;
            // 
            // imageListToolbar
            // 
            this.imageListToolbar.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListToolbar.ImageStream")));
            this.imageListToolbar.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListToolbar.Images.SetKeyName(0, "Filter_Add.png");
            this.imageListToolbar.Images.SetKeyName(1, "Filter_Delete.png");
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1599, 889);
            this.Controls.Add(this.MainSplitContainer);
            this.Controls.Add(this.MainToolbar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
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
            this.ResumeLayout(false);

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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer ChildSplitContainer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TreeView TreeViewCategories;
        private System.Windows.Forms.GroupBox PropertiesGroupBox;
        private System.Windows.Forms.Label OriginalNameLabel;
        private System.Windows.Forms.ToolStripButton ToolButtonPrint;
        private System.Windows.Forms.ToolStripButton ToolButtonScan;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private PdfiumViewer.PdfRenderer PdfViewer;
        private System.Windows.Forms.ToolStripButton ToolButtonFolderAdd;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ImageList TreeViewImageList;
        private System.Windows.Forms.ToolStripButton ToolButtonRenameFile;
        private System.Windows.Forms.ToolStripButton ToolButtonFolderRename;
        private System.Windows.Forms.ToolStripButton ToolButtonFolderDelete;
        private System.Windows.Forms.ToolStripButton ToolButtonRefresh;
        private System.Windows.Forms.ToolStripButton toolButtonFilter;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Drawing.Printing.PrintDocument printPdf;
        private System.Windows.Forms.PrintDialog printDialog;
        private System.Windows.Forms.ImageList imageListToolbar;
    }
}

