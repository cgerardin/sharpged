﻿namespace SharpGED_client.Forms
{
    partial class RenameForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.TextBoxPdfName = new System.Windows.Forms.TextBox();
            this.ButtonRename = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 13);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Titre";
            // 
            // TextBoxPdfName
            // 
            this.TextBoxPdfName.Location = new System.Drawing.Point(56, 10);
            this.TextBoxPdfName.Margin = new System.Windows.Forms.Padding(6, 10, 6, 10);
            this.TextBoxPdfName.Name = "TextBoxPdfName";
            this.TextBoxPdfName.Size = new System.Drawing.Size(269, 20);
            this.TextBoxPdfName.TabIndex = 7;
            // 
            // ButtonRename
            // 
            this.ButtonRename.Location = new System.Drawing.Point(333, 5);
            this.ButtonRename.Name = "ButtonRename";
            this.ButtonRename.Size = new System.Drawing.Size(85, 28);
            this.ButtonRename.TabIndex = 9;
            this.ButtonRename.Text = "Renommer";
            this.ButtonRename.UseVisualStyleBackColor = true;
            this.ButtonRename.Click += new System.EventHandler(this.ButtonRename_Click);
            // 
            // RenameForm
            // 
            this.AcceptButton = this.ButtonRename;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 41);
            this.ControlBox = false;
            this.Controls.Add(this.ButtonRename);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TextBoxPdfName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "RenameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Renommer le document";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.RenameForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RenameForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TextBoxPdfName;
        private System.Windows.Forms.Button ButtonRename;
    }
}