namespace SharpGED_client
{
    partial class formAddFile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formAddFile));
            this.addPdfDialog = new System.Windows.Forms.OpenFileDialog();
            this.ButtonAddPdf = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxPdfName = new System.Windows.Forms.TextBox();
            this.labelNbPages = new System.Windows.Forms.Label();
            this.listBoxFiles = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // addPdfDialog
            // 
            this.addPdfDialog.Filter = "Tous les documents supportés|*.pdf;*.jpeg;*.jpg;*.png|Documents PDF|*.pdf|Fichier" +
    "s image|*.jpeg;*.jpg;*.png";
            this.addPdfDialog.Multiselect = true;
            // 
            // ButtonAddPdf
            // 
            this.ButtonAddPdf.Location = new System.Drawing.Point(493, 287);
            this.ButtonAddPdf.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.ButtonAddPdf.Name = "ButtonAddPdf";
            this.ButtonAddPdf.Size = new System.Drawing.Size(85, 28);
            this.ButtonAddPdf.TabIndex = 4;
            this.ButtonAddPdf.Text = "Insérer";
            this.ButtonAddPdf.UseVisualStyleBackColor = true;
            this.ButtonAddPdf.Click += new System.EventHandler(this.ButtonAddPdf_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(267, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Titre";
            // 
            // textBoxPdfName
            // 
            this.textBoxPdfName.Location = new System.Drawing.Point(309, 12);
            this.textBoxPdfName.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.textBoxPdfName.Name = "textBoxPdfName";
            this.textBoxPdfName.Size = new System.Drawing.Size(269, 20);
            this.textBoxPdfName.TabIndex = 3;
            this.textBoxPdfName.TextChanged += new System.EventHandler(this.textBoxPdfName_TextChanged);
            // 
            // labelNbPages
            // 
            this.labelNbPages.AutoSize = true;
            this.labelNbPages.Location = new System.Drawing.Point(527, 40);
            this.labelNbPages.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelNbPages.Name = "labelNbPages";
            this.labelNbPages.Size = new System.Drawing.Size(51, 13);
            this.labelNbPages.TabIndex = 5;
            this.labelNbPages.Text = "(0 pages)";
            this.labelNbPages.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // listBoxFiles
            // 
            this.listBoxFiles.FormattingEnabled = true;
            this.listBoxFiles.Location = new System.Drawing.Point(12, 12);
            this.listBoxFiles.Name = "listBoxFiles";
            this.listBoxFiles.Size = new System.Drawing.Size(239, 303);
            this.listBoxFiles.TabIndex = 7;
            this.listBoxFiles.SelectedIndexChanged += new System.EventHandler(this.listBoxFiles_SelectedIndexChanged);
            // 
            // formAddFile
            // 
            this.AcceptButton = this.ButtonAddPdf;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 329);
            this.Controls.Add(this.listBoxFiles);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelNbPages);
            this.Controls.Add(this.ButtonAddPdf);
            this.Controls.Add(this.textBoxPdfName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "formAddFile";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ajouter des documents";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.AddFileForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog addPdfDialog;
        private System.Windows.Forms.Button ButtonAddPdf;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxPdfName;
        private System.Windows.Forms.Label labelNbPages;
        private System.Windows.Forms.ListBox listBoxFiles;
    }
}