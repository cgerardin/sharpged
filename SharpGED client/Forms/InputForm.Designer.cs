namespace SharpGED_client.Forms
{
    partial class InputForm
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
            this.LabelTitle = new System.Windows.Forms.Label();
            this.TextBoxInput = new System.Windows.Forms.TextBox();
            this.ButtonValidate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LabelTitle
            // 
            this.LabelTitle.AutoSize = true;
            this.LabelTitle.Location = new System.Drawing.Point(14, 13);
            this.LabelTitle.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.LabelTitle.Name = "LabelTitle";
            this.LabelTitle.Size = new System.Drawing.Size(28, 13);
            this.LabelTitle.TabIndex = 8;
            this.LabelTitle.Text = "Titre";
            // 
            // TextBoxInput
            // 
            this.TextBoxInput.Location = new System.Drawing.Point(56, 10);
            this.TextBoxInput.Margin = new System.Windows.Forms.Padding(6, 10, 6, 10);
            this.TextBoxInput.Name = "TextBoxInput";
            this.TextBoxInput.Size = new System.Drawing.Size(269, 20);
            this.TextBoxInput.TabIndex = 7;
            // 
            // ButtonValidate
            // 
            this.ButtonValidate.Location = new System.Drawing.Point(333, 5);
            this.ButtonValidate.Name = "ButtonValidate";
            this.ButtonValidate.Size = new System.Drawing.Size(85, 28);
            this.ButtonValidate.TabIndex = 9;
            this.ButtonValidate.Text = "Valider";
            this.ButtonValidate.UseVisualStyleBackColor = true;
            this.ButtonValidate.Click += new System.EventHandler(this.ButtonValidate_Click);
            // 
            // InputForm
            // 
            this.AcceptButton = this.ButtonValidate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 41);
            this.ControlBox = false;
            this.Controls.Add(this.ButtonValidate);
            this.Controls.Add(this.LabelTitle);
            this.Controls.Add(this.TextBoxInput);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "InputForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Titre";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.InputForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.InputForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LabelTitle;
        private System.Windows.Forms.TextBox TextBoxInput;
        private System.Windows.Forms.Button ButtonValidate;
    }
}