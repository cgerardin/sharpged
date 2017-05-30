namespace SharpGED_client
{
    partial class formMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formMain));
            this.LabelPdfName = new System.Windows.Forms.Label();
            this.LabelNbPages = new System.Windows.Forms.Label();
            this.mainToolbar = new System.Windows.Forms.ToolStrip();
            this.toolButtonFilter = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolButtonFileAdd = new System.Windows.Forms.ToolStripButton();
            this.toolButtonFileRename = new System.Windows.Forms.ToolStripButton();
            this.toolButtonFileEdit = new System.Windows.Forms.ToolStripButton();
            this.toolButtonFileDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolButtonFolderAdd = new System.Windows.Forms.ToolStripButton();
            this.toolButtonFolderRename = new System.Windows.Forms.ToolStripButton();
            this.toolButtonFolderDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolButtonScan = new System.Windows.Forms.ToolStripButton();
            this.toolButtonPrint = new System.Windows.Forms.ToolStripButton();
            this.toolButtonFileExtract = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolButtonRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolButtonStopServer = new System.Windows.Forms.ToolStripButton();
            this.toolButtonInitDatabase = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolButtonDisconnect = new System.Windows.Forms.ToolStripButton();
            this.MainSplitContainer = new System.Windows.Forms.SplitContainer();
            this.ChildSplitContainer = new System.Windows.Forms.SplitContainer();
            this.treeViewCategories = new System.Windows.Forms.TreeView();
            this.imageListTreeView = new System.Windows.Forms.ImageList(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.groupBoxProperties = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelFileType = new System.Windows.Forms.Label();
            this.labelOriginalName = new System.Windows.Forms.Label();
            this.listBoxFiles = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.officeViewer = new SharpGED_controls.OfficeViewer();
            this.imageViewer = new System.Windows.Forms.PictureBox();
            this.pdfViewer = new PdfiumViewer.PdfRenderer();
            this.printPdf = new System.Drawing.Printing.PrintDocument();
            this.printDialog = new System.Windows.Forms.PrintDialog();
            this.imageListToolbar = new System.Windows.Forms.ImageList(this.components);
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.mainToolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitContainer)).BeginInit();
            this.MainSplitContainer.Panel1.SuspendLayout();
            this.MainSplitContainer.Panel2.SuspendLayout();
            this.MainSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChildSplitContainer)).BeginInit();
            this.ChildSplitContainer.Panel1.SuspendLayout();
            this.ChildSplitContainer.Panel2.SuspendLayout();
            this.ChildSplitContainer.SuspendLayout();
            this.groupBoxProperties.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageViewer)).BeginInit();
            this.SuspendLayout();
            // 
            // LabelPdfName
            // 
            this.LabelPdfName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelPdfName.AutoSize = true;
            this.LabelPdfName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelPdfName.Location = new System.Drawing.Point(6, 26);
            this.LabelPdfName.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.LabelPdfName.Name = "LabelPdfName";
            this.LabelPdfName.Size = new System.Drawing.Size(110, 13);
            this.LabelPdfName.TabIndex = 18;
            this.LabelPdfName.Text = "Titre du document";
            // 
            // LabelNbPages
            // 
            this.LabelNbPages.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelNbPages.AutoSize = true;
            this.LabelNbPages.Location = new System.Drawing.Point(54, 66);
            this.LabelNbPages.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.LabelNbPages.Name = "LabelNbPages";
            this.LabelNbPages.Size = new System.Drawing.Size(13, 13);
            this.LabelNbPages.TabIndex = 17;
            this.LabelNbPages.Text = "0";
            // 
            // mainToolbar
            // 
            this.mainToolbar.AutoSize = false;
            this.mainToolbar.Dock = System.Windows.Forms.DockStyle.Left;
            this.mainToolbar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.mainToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolButtonFilter,
            this.toolStripSeparator5,
            this.toolButtonFileAdd,
            this.toolButtonFileRename,
            this.toolButtonFileEdit,
            this.toolButtonFileDelete,
            this.toolStripSeparator1,
            this.toolButtonFolderAdd,
            this.toolButtonFolderRename,
            this.toolButtonFolderDelete,
            this.toolStripSeparator4,
            this.toolButtonScan,
            this.toolButtonPrint,
            this.toolButtonFileExtract,
            this.toolStripSeparator3,
            this.toolButtonRefresh,
            this.toolButtonStopServer,
            this.toolButtonInitDatabase,
            this.toolStripSeparator2,
            this.toolButtonDisconnect});
            this.mainToolbar.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.mainToolbar.Location = new System.Drawing.Point(0, 0);
            this.mainToolbar.Name = "mainToolbar";
            this.mainToolbar.Size = new System.Drawing.Size(42, 889);
            this.mainToolbar.TabIndex = 20;
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
            // toolButtonFileAdd
            // 
            this.toolButtonFileAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolButtonFileAdd.Image = ((System.Drawing.Image)(resources.GetObject("toolButtonFileAdd.Image")));
            this.toolButtonFileAdd.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolButtonFileAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolButtonFileAdd.Name = "toolButtonFileAdd";
            this.toolButtonFileAdd.Size = new System.Drawing.Size(40, 36);
            this.toolButtonFileAdd.Text = "Ajouter un document";
            this.toolButtonFileAdd.Click += new System.EventHandler(this.toolButtonFileNew_Click);
            // 
            // toolButtonFileRename
            // 
            this.toolButtonFileRename.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolButtonFileRename.Image = ((System.Drawing.Image)(resources.GetObject("toolButtonFileRename.Image")));
            this.toolButtonFileRename.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolButtonFileRename.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolButtonFileRename.Name = "toolButtonFileRename";
            this.toolButtonFileRename.Size = new System.Drawing.Size(40, 36);
            this.toolButtonFileRename.Text = "Renommer le document sélectionné";
            this.toolButtonFileRename.Click += new System.EventHandler(this.toolButtonFileRename_Click);
            // 
            // toolButtonFileEdit
            // 
            this.toolButtonFileEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolButtonFileEdit.Image = ((System.Drawing.Image)(resources.GetObject("toolButtonFileEdit.Image")));
            this.toolButtonFileEdit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolButtonFileEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolButtonFileEdit.Name = "toolButtonFileEdit";
            this.toolButtonFileEdit.Size = new System.Drawing.Size(40, 36);
            this.toolButtonFileEdit.Text = "Editer le document sélectionné";
            this.toolButtonFileEdit.Click += new System.EventHandler(this.toolButtonFileEdit_Click);
            // 
            // toolButtonFileDelete
            // 
            this.toolButtonFileDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolButtonFileDelete.Image = ((System.Drawing.Image)(resources.GetObject("toolButtonFileDelete.Image")));
            this.toolButtonFileDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolButtonFileDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolButtonFileDelete.Name = "toolButtonFileDelete";
            this.toolButtonFileDelete.Size = new System.Drawing.Size(40, 36);
            this.toolButtonFileDelete.Text = "Supprimer le document sélectionné";
            this.toolButtonFileDelete.ToolTipText = "Supprimer le fichier sélectionné";
            this.toolButtonFileDelete.Click += new System.EventHandler(this.toolButtonFileDelete_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(40, 6);
            // 
            // toolButtonFolderAdd
            // 
            this.toolButtonFolderAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolButtonFolderAdd.Image = ((System.Drawing.Image)(resources.GetObject("toolButtonFolderAdd.Image")));
            this.toolButtonFolderAdd.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolButtonFolderAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolButtonFolderAdd.Name = "toolButtonFolderAdd";
            this.toolButtonFolderAdd.Size = new System.Drawing.Size(40, 36);
            this.toolButtonFolderAdd.Text = "Créer un dossier";
            this.toolButtonFolderAdd.Click += new System.EventHandler(this.toolButtonFolderAdd_Click);
            // 
            // toolButtonFolderRename
            // 
            this.toolButtonFolderRename.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolButtonFolderRename.Image = ((System.Drawing.Image)(resources.GetObject("toolButtonFolderRename.Image")));
            this.toolButtonFolderRename.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolButtonFolderRename.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolButtonFolderRename.Name = "toolButtonFolderRename";
            this.toolButtonFolderRename.Size = new System.Drawing.Size(40, 36);
            this.toolButtonFolderRename.Text = "Renommer le dossier sélectionné";
            this.toolButtonFolderRename.Click += new System.EventHandler(this.toolButtonFolderRename_Click);
            // 
            // toolButtonFolderDelete
            // 
            this.toolButtonFolderDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolButtonFolderDelete.Image = ((System.Drawing.Image)(resources.GetObject("toolButtonFolderDelete.Image")));
            this.toolButtonFolderDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolButtonFolderDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolButtonFolderDelete.Name = "toolButtonFolderDelete";
            this.toolButtonFolderDelete.Size = new System.Drawing.Size(40, 36);
            this.toolButtonFolderDelete.Text = "Supprimer le dossier sélectionné";
            this.toolButtonFolderDelete.Click += new System.EventHandler(this.toolButtonFolderDelete_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(40, 6);
            // 
            // toolButtonScan
            // 
            this.toolButtonScan.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolButtonScan.Image = ((System.Drawing.Image)(resources.GetObject("toolButtonScan.Image")));
            this.toolButtonScan.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolButtonScan.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolButtonScan.Name = "toolButtonScan";
            this.toolButtonScan.Size = new System.Drawing.Size(40, 36);
            this.toolButtonScan.Text = "Numériser un document";
            // 
            // toolButtonPrint
            // 
            this.toolButtonPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolButtonPrint.Image = ((System.Drawing.Image)(resources.GetObject("toolButtonPrint.Image")));
            this.toolButtonPrint.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolButtonPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolButtonPrint.Name = "toolButtonPrint";
            this.toolButtonPrint.Size = new System.Drawing.Size(40, 36);
            this.toolButtonPrint.Text = "Imprimer le document";
            this.toolButtonPrint.Click += new System.EventHandler(this.toolButtonPrint_Click);
            // 
            // toolButtonFileExtract
            // 
            this.toolButtonFileExtract.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolButtonFileExtract.Image = ((System.Drawing.Image)(resources.GetObject("toolButtonFileExtract.Image")));
            this.toolButtonFileExtract.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolButtonFileExtract.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolButtonFileExtract.Name = "toolButtonFileExtract";
            this.toolButtonFileExtract.Size = new System.Drawing.Size(40, 36);
            this.toolButtonFileExtract.Text = "Extraire le document sélectionné";
            this.toolButtonFileExtract.Click += new System.EventHandler(this.toolButtonFileExtract_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(40, 6);
            // 
            // toolButtonRefresh
            // 
            this.toolButtonRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolButtonRefresh.Image = ((System.Drawing.Image)(resources.GetObject("toolButtonRefresh.Image")));
            this.toolButtonRefresh.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolButtonRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolButtonRefresh.Name = "toolButtonRefresh";
            this.toolButtonRefresh.Size = new System.Drawing.Size(40, 36);
            this.toolButtonRefresh.Text = "Rafraîchir l\'affichage";
            this.toolButtonRefresh.Click += new System.EventHandler(this.toolButtonRefresh_Click);
            // 
            // toolButtonStopServer
            // 
            this.toolButtonStopServer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolButtonStopServer.Image = ((System.Drawing.Image)(resources.GetObject("toolButtonStopServer.Image")));
            this.toolButtonStopServer.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolButtonStopServer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolButtonStopServer.Name = "toolButtonStopServer";
            this.toolButtonStopServer.Size = new System.Drawing.Size(40, 36);
            this.toolButtonStopServer.Text = "Arrêter le serveur";
            this.toolButtonStopServer.Click += new System.EventHandler(this.toolButtonStopServer_Click);
            // 
            // toolButtonInitDatabase
            // 
            this.toolButtonInitDatabase.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolButtonInitDatabase.Image = ((System.Drawing.Image)(resources.GetObject("toolButtonInitDatabase.Image")));
            this.toolButtonInitDatabase.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolButtonInitDatabase.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolButtonInitDatabase.Name = "toolButtonInitDatabase";
            this.toolButtonInitDatabase.Size = new System.Drawing.Size(40, 36);
            this.toolButtonInitDatabase.Text = "Initialiser la base de données";
            this.toolButtonInitDatabase.ToolTipText = "Initialiser la base de données";
            this.toolButtonInitDatabase.Click += new System.EventHandler(this.toolButtonInitDatabase_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(40, 6);
            // 
            // toolButtonDisconnect
            // 
            this.toolButtonDisconnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolButtonDisconnect.Image = ((System.Drawing.Image)(resources.GetObject("toolButtonDisconnect.Image")));
            this.toolButtonDisconnect.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolButtonDisconnect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolButtonDisconnect.Name = "toolButtonDisconnect";
            this.toolButtonDisconnect.Size = new System.Drawing.Size(40, 36);
            this.toolButtonDisconnect.Text = "Se déconnecter du serveur";
            this.toolButtonDisconnect.Click += new System.EventHandler(this.toolButtonDisconnect_Click);
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
            this.MainSplitContainer.Panel2.Controls.Add(this.officeViewer);
            this.MainSplitContainer.Panel2.Controls.Add(this.imageViewer);
            this.MainSplitContainer.Panel2.Controls.Add(this.pdfViewer);
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
            this.ChildSplitContainer.Panel1.Controls.Add(this.treeViewCategories);
            this.ChildSplitContainer.Panel1.Controls.Add(this.label2);
            // 
            // ChildSplitContainer.Panel2
            // 
            this.ChildSplitContainer.Panel2.Controls.Add(this.groupBoxProperties);
            this.ChildSplitContainer.Panel2.Controls.Add(this.listBoxFiles);
            this.ChildSplitContainer.Panel2.Controls.Add(this.label1);
            this.ChildSplitContainer.Size = new System.Drawing.Size(662, 886);
            this.ChildSplitContainer.SplitterDistance = 283;
            this.ChildSplitContainer.SplitterWidth = 3;
            this.ChildSplitContainer.TabIndex = 20;
            this.ChildSplitContainer.TabStop = false;
            // 
            // treeViewCategories
            // 
            this.treeViewCategories.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeViewCategories.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeViewCategories.FullRowSelect = true;
            this.treeViewCategories.HideSelection = false;
            this.treeViewCategories.ImageIndex = 1;
            this.treeViewCategories.ImageList = this.imageListTreeView;
            this.treeViewCategories.Location = new System.Drawing.Point(0, 27);
            this.treeViewCategories.Margin = new System.Windows.Forms.Padding(0);
            this.treeViewCategories.Name = "treeViewCategories";
            this.treeViewCategories.SelectedImageIndex = 0;
            this.treeViewCategories.ShowLines = false;
            this.treeViewCategories.ShowRootLines = false;
            this.treeViewCategories.Size = new System.Drawing.Size(286, 853);
            this.treeViewCategories.TabIndex = 1;
            this.treeViewCategories.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewCategories_AfterSelect);
            this.treeViewCategories.Click += new System.EventHandler(this.treeViewCategories_Click);
            this.treeViewCategories.KeyDown += new System.Windows.Forms.KeyEventHandler(this.treeViewCategories_KeyDown);
            // 
            // imageListTreeView
            // 
            this.imageListTreeView.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListTreeView.ImageStream")));
            this.imageListTreeView.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListTreeView.Images.SetKeyName(0, "Database_Small.png");
            this.imageListTreeView.Images.SetKeyName(1, "Folder_Small.png");
            this.imageListTreeView.Images.SetKeyName(2, "Folder_Empty_Small.png");
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
            // groupBoxProperties
            // 
            this.groupBoxProperties.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxProperties.Controls.Add(this.label5);
            this.groupBoxProperties.Controls.Add(this.label4);
            this.groupBoxProperties.Controls.Add(this.label3);
            this.groupBoxProperties.Controls.Add(this.labelFileType);
            this.groupBoxProperties.Controls.Add(this.LabelPdfName);
            this.groupBoxProperties.Controls.Add(this.LabelNbPages);
            this.groupBoxProperties.Controls.Add(this.labelOriginalName);
            this.groupBoxProperties.Location = new System.Drawing.Point(0, 732);
            this.groupBoxProperties.Name = "groupBoxProperties";
            this.groupBoxProperties.Size = new System.Drawing.Size(363, 150);
            this.groupBoxProperties.TabIndex = 21;
            this.groupBoxProperties.TabStop = false;
            this.groupBoxProperties.Text = "Propriétés du document";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 66);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "Pages :";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 92);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(149, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Nom du fichier d\'origine :";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 49);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Type :";
            // 
            // labelFileType
            // 
            this.labelFileType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelFileType.AutoSize = true;
            this.labelFileType.Location = new System.Drawing.Point(46, 49);
            this.labelFileType.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelFileType.Name = "labelFileType";
            this.labelFileType.Size = new System.Drawing.Size(31, 13);
            this.labelFileType.TabIndex = 20;
            this.labelFileType.Text = "Type";
            // 
            // labelOriginalName
            // 
            this.labelOriginalName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelOriginalName.AutoSize = true;
            this.labelOriginalName.Location = new System.Drawing.Point(8, 108);
            this.labelOriginalName.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelOriginalName.Name = "labelOriginalName";
            this.labelOriginalName.Size = new System.Drawing.Size(52, 13);
            this.labelOriginalName.TabIndex = 19;
            this.labelOriginalName.Text = "fichier.ext";
            // 
            // listBoxFiles
            // 
            this.listBoxFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxFiles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBoxFiles.DisplayMember = "title";
            this.listBoxFiles.FormattingEnabled = true;
            this.listBoxFiles.Location = new System.Drawing.Point(0, 27);
            this.listBoxFiles.Margin = new System.Windows.Forms.Padding(0);
            this.listBoxFiles.Name = "listBoxFiles";
            this.listBoxFiles.ScrollAlwaysVisible = true;
            this.listBoxFiles.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxFiles.Size = new System.Drawing.Size(366, 702);
            this.listBoxFiles.TabIndex = 2;
            this.listBoxFiles.ValueMember = "hash";
            this.listBoxFiles.SelectedIndexChanged += new System.EventHandler(this.listBoxFiles_SelectedIndexChanged);
            this.listBoxFiles.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBoxFiles_KeyDown);
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
            // officeViewer
            // 
            this.officeViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.officeViewer.AutoSize = true;
            this.officeViewer.Location = new System.Drawing.Point(0, 27);
            this.officeViewer.Name = "officeViewer";
            this.officeViewer.Size = new System.Drawing.Size(399, 445);
            this.officeViewer.TabIndex = 20;
            this.officeViewer.URI = null;
            // 
            // imageViewer
            // 
            this.imageViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imageViewer.Location = new System.Drawing.Point(0, 27);
            this.imageViewer.Margin = new System.Windows.Forms.Padding(0);
            this.imageViewer.Name = "imageViewer";
            this.imageViewer.Size = new System.Drawing.Size(887, 855);
            this.imageViewer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.imageViewer.TabIndex = 19;
            this.imageViewer.TabStop = false;
            // 
            // pdfViewer
            // 
            this.pdfViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pdfViewer.Location = new System.Drawing.Point(0, 27);
            this.pdfViewer.Margin = new System.Windows.Forms.Padding(0);
            this.pdfViewer.Name = "pdfViewer";
            this.pdfViewer.Page = 0;
            this.pdfViewer.Rotation = PdfiumViewer.PdfRotation.Rotate0;
            this.pdfViewer.Size = new System.Drawing.Size(887, 855);
            this.pdfViewer.TabIndex = 3;
            this.pdfViewer.Visible = false;
            this.pdfViewer.ZoomMode = PdfiumViewer.PdfViewerZoomMode.FitWidth;
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
            // formMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1599, 889);
            this.Controls.Add(this.MainSplitContainer);
            this.Controls.Add(this.mainToolbar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.Name = "formMain";
            this.Text = "SharpGED";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.mainToolbar.ResumeLayout(false);
            this.mainToolbar.PerformLayout();
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
            this.groupBoxProperties.ResumeLayout(false);
            this.groupBoxProperties.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageViewer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label LabelPdfName;
        private System.Windows.Forms.Label LabelNbPages;
        private System.Windows.Forms.ToolStrip mainToolbar;
        private System.Windows.Forms.ToolStripButton toolButtonFileAdd;
        private System.Windows.Forms.ToolStripButton toolButtonFileDelete;
        private System.Windows.Forms.ToolStripButton toolButtonFileEdit;
        private System.Windows.Forms.ToolStripButton toolButtonDisconnect;
        private System.Windows.Forms.ToolStripButton toolButtonStopServer;
        private System.Windows.Forms.ToolStripButton toolButtonInitDatabase;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.SplitContainer MainSplitContainer;
        private System.Windows.Forms.ListBox listBoxFiles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer ChildSplitContainer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TreeView treeViewCategories;
        private System.Windows.Forms.GroupBox groupBoxProperties;
        private System.Windows.Forms.Label labelOriginalName;
        private System.Windows.Forms.ToolStripButton toolButtonPrint;
        private System.Windows.Forms.ToolStripButton toolButtonScan;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private PdfiumViewer.PdfRenderer pdfViewer;
        private System.Windows.Forms.ToolStripButton toolButtonFolderAdd;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ImageList imageListTreeView;
        private System.Windows.Forms.ToolStripButton toolButtonFileRename;
        private System.Windows.Forms.ToolStripButton toolButtonFolderRename;
        private System.Windows.Forms.ToolStripButton toolButtonFolderDelete;
        private System.Windows.Forms.ToolStripButton toolButtonRefresh;
        private System.Windows.Forms.ToolStripButton toolButtonFilter;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Drawing.Printing.PrintDocument printPdf;
        private System.Windows.Forms.PrintDialog printDialog;
        private System.Windows.Forms.ImageList imageListToolbar;
        private System.Windows.Forms.Label labelFileType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox imageViewer;
        private SharpGED_controls.OfficeViewer officeViewer;
        private System.Windows.Forms.ToolStripButton toolButtonFileExtract;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Label label5;
    }
}

