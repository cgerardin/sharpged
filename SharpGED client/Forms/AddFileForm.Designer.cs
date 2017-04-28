﻿namespace SharpGED_client
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
            this.TextBoxPdfName.Location = new System.Drawing.Point(47, 9);
            this.TextBoxPdfName.Name = "TextBoxPdfName";
            this.TextBoxPdfName.Size = new System.Drawing.Size(296, 20);
            this.TextBoxPdfName.TabIndex = 3;
            // 
            // ButtonAddPdf
            // 
            this.ButtonAddPdf.Location = new System.Drawing.Point(267, 90);
            this.ButtonAddPdf.Name = "ButtonAddPdf";
            this.ButtonAddPdf.Size = new System.Drawing.Size(75, 23);
            this.ButtonAddPdf.TabIndex = 4;
            this.ButtonAddPdf.Text = "Insérer";
            this.ButtonAddPdf.UseVisualStyleBackColor = true;
            this.ButtonAddPdf.Click += new System.EventHandler(this.ButtonAddPdf_Click);
            // 
            // LabelNbPages
            // 
            this.LabelNbPages.AutoSize = true;
            this.LabelNbPages.Location = new System.Drawing.Point(12, 95);
            this.LabelNbPages.Name = "LabelNbPages";
            this.LabelNbPages.Size = new System.Drawing.Size(51, 13);
            this.LabelNbPages.TabIndex = 5;
            this.LabelNbPages.Text = "(0 pages)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Titre";
            // 
            // AddFileForm
            // 
            this.AcceptButton = this.ButtonAddPdf;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 120);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LabelNbPages);
            this.Controls.Add(this.ButtonAddPdf);
            this.Controls.Add(this.TextBoxPdfName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddFileForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Insérer un fichier";
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