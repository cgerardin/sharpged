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
            this.ListBoxPages = new System.Windows.Forms.ListBox();
            this.LabelNbPages = new System.Windows.Forms.Label();
            this.ButtonEclaterPdf = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ListBoxPages
            // 
            this.ListBoxPages.FormattingEnabled = true;
            this.ListBoxPages.Location = new System.Drawing.Point(26, 29);
            this.ListBoxPages.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.ListBoxPages.Name = "ListBoxPages";
            this.ListBoxPages.Size = new System.Drawing.Size(479, 342);
            this.ListBoxPages.TabIndex = 9;
            this.ListBoxPages.SelectedIndexChanged += new System.EventHandler(this.ListBoxPages_SelectedIndexChanged);
            // 
            // LabelNbPages
            // 
            this.LabelNbPages.AutoSize = true;
            this.LabelNbPages.Location = new System.Drawing.Point(23, 393);
            this.LabelNbPages.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.LabelNbPages.Name = "LabelNbPages";
            this.LabelNbPages.Size = new System.Drawing.Size(51, 13);
            this.LabelNbPages.TabIndex = 8;
            this.LabelNbPages.Text = "(0 pages)";
            // 
            // ButtonEclaterPdf
            // 
            this.ButtonEclaterPdf.Location = new System.Drawing.Point(345, 393);
            this.ButtonEclaterPdf.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.ButtonEclaterPdf.Name = "ButtonEclaterPdf";
            this.ButtonEclaterPdf.Size = new System.Drawing.Size(160, 56);
            this.ButtonEclaterPdf.TabIndex = 7;
            this.ButtonEclaterPdf.Text = "Eclater";
            this.ButtonEclaterPdf.UseVisualStyleBackColor = true;
            this.ButtonEclaterPdf.Click += new System.EventHandler(this.ButtonEclaterPdf_Click);
            // 
            // EditPdfForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 474);
            this.Controls.Add(this.ListBoxPages);
            this.Controls.Add(this.LabelNbPages);
            this.Controls.Add(this.ButtonEclaterPdf);
            this.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.Name = "EditPdfForm";
            this.Text = "Editeur de PDF";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox ListBoxPages;
        private System.Windows.Forms.Label LabelNbPages;
        private System.Windows.Forms.Button ButtonEclaterPdf;
    }
}