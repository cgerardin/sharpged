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
            this.ListBoxPages.ItemHeight = 37;
            this.ListBoxPages.Location = new System.Drawing.Point(30, 34);
            this.ListBoxPages.Margin = new System.Windows.Forms.Padding(7, 9, 7, 9);
            this.ListBoxPages.Name = "ListBoxPages";
            this.ListBoxPages.Size = new System.Drawing.Size(1011, 781);
            this.ListBoxPages.TabIndex = 9;
            this.ListBoxPages.SelectedIndexChanged += new System.EventHandler(this.ListBoxPages_SelectedIndexChanged);
            // 
            // LabelNbPages
            // 
            this.LabelNbPages.AutoSize = true;
            this.LabelNbPages.Location = new System.Drawing.Point(22, 854);
            this.LabelNbPages.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.LabelNbPages.Name = "LabelNbPages";
            this.LabelNbPages.Size = new System.Drawing.Size(128, 37);
            this.LabelNbPages.TabIndex = 8;
            this.LabelNbPages.Text = "(0 pages)";
            // 
            // ButtonEclaterPdf
            // 
            this.ButtonEclaterPdf.Location = new System.Drawing.Point(855, 840);
            this.ButtonEclaterPdf.Margin = new System.Windows.Forms.Padding(7, 9, 7, 9);
            this.ButtonEclaterPdf.Name = "ButtonEclaterPdf";
            this.ButtonEclaterPdf.Size = new System.Drawing.Size(187, 65);
            this.ButtonEclaterPdf.TabIndex = 7;
            this.ButtonEclaterPdf.Text = "Eclater";
            this.ButtonEclaterPdf.UseVisualStyleBackColor = true;
            this.ButtonEclaterPdf.Click += new System.EventHandler(this.ButtonEclaterPdf_Click);
            // 
            // EditPdfForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2047, 971);
            this.Controls.Add(this.ListBoxPages);
            this.Controls.Add(this.LabelNbPages);
            this.Controls.Add(this.ButtonEclaterPdf);
            this.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(7, 9, 7, 9);
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