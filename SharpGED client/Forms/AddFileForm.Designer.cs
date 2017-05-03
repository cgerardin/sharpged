namespace SharpGED_client
{
    partial class AddFileForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddFileForm));
            this.addPdfDialog = new System.Windows.Forms.OpenFileDialog();
            this.TextBoxPdfName = new System.Windows.Forms.TextBox();
            this.ButtonAddPdf = new System.Windows.Forms.Button();
            this.LabelNbPages = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // addPdfDialog
            // 
            this.addPdfDialog.Filter = "Documents PDF|*.pdf";
            // 
            // TextBoxPdfName
            // 
            this.TextBoxPdfName.Location = new System.Drawing.Point(118, 26);
            this.TextBoxPdfName.Margin = new System.Windows.Forms.Padding(7, 9, 7, 9);
            this.TextBoxPdfName.Name = "TextBoxPdfName";
            this.TextBoxPdfName.Size = new System.Drawing.Size(734, 44);
            this.TextBoxPdfName.TabIndex = 3;
            // 
            // ButtonAddPdf
            // 
            this.ButtonAddPdf.Location = new System.Drawing.Point(667, 256);
            this.ButtonAddPdf.Margin = new System.Windows.Forms.Padding(7, 9, 7, 9);
            this.ButtonAddPdf.Name = "ButtonAddPdf";
            this.ButtonAddPdf.Size = new System.Drawing.Size(187, 65);
            this.ButtonAddPdf.TabIndex = 4;
            this.ButtonAddPdf.Text = "Insérer";
            this.ButtonAddPdf.UseVisualStyleBackColor = true;
            this.ButtonAddPdf.Click += new System.EventHandler(this.ButtonAddPdf_Click);
            // 
            // LabelNbPages
            // 
            this.LabelNbPages.AutoSize = true;
            this.LabelNbPages.Location = new System.Drawing.Point(30, 270);
            this.LabelNbPages.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.LabelNbPages.Name = "LabelNbPages";
            this.LabelNbPages.Size = new System.Drawing.Size(128, 37);
            this.LabelNbPages.TabIndex = 5;
            this.LabelNbPages.Text = "(0 pages)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 37);
            this.label1.TabIndex = 6;
            this.label1.Text = "Titre";
            // 
            // AddFileForm
            // 
            this.AcceptButton = this.ButtonAddPdf;
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 342);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LabelNbPages);
            this.Controls.Add(this.ButtonAddPdf);
            this.Controls.Add(this.TextBoxPdfName);
            this.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(7, 9, 7, 9);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddFileForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Insérer un fichier";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.AddFileForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog addPdfDialog;
        private System.Windows.Forms.TextBox TextBoxPdfName;
        private System.Windows.Forms.Button ButtonAddPdf;
        private System.Windows.Forms.Label LabelNbPages;
        private System.Windows.Forms.Label label1;
    }
}