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
            this.addPdfDialog = new System.Windows.Forms.OpenFileDialog();
            this.TextBoxPdfName = new System.Windows.Forms.TextBox();
            this.BrowseButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // addPdfDialog
            // 
            this.addPdfDialog.Filter = "Documents PDF|*.pdf";
            // 
            // TextBoxPdfName
            // 
            this.TextBoxPdfName.Location = new System.Drawing.Point(72, 147);
            this.TextBoxPdfName.Name = "TextBoxPdfName";
            this.TextBoxPdfName.Size = new System.Drawing.Size(296, 20);
            this.TextBoxPdfName.TabIndex = 3;
            // 
            // BrowseButton
            // 
            this.BrowseButton.Location = new System.Drawing.Point(12, 142);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(54, 28);
            this.BrowseButton.TabIndex = 2;
            this.BrowseButton.Text = "...";
            this.BrowseButton.UseVisualStyleBackColor = true;
            // 
            // AddFileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 312);
            this.Controls.Add(this.TextBoxPdfName);
            this.Controls.Add(this.BrowseButton);
            this.Name = "AddFileForm";
            this.Text = "AddFileForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog addPdfDialog;
        private System.Windows.Forms.TextBox TextBoxPdfName;
        private System.Windows.Forms.Button BrowseButton;
    }
}