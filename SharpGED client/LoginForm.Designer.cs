namespace SharpGED_client
{
    partial class LoginForm
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
            this.ButtonConnect = new System.Windows.Forms.Button();
            this.TextBoxServer = new System.Windows.Forms.TextBox();
            this.TextBoxUser = new System.Windows.Forms.TextBox();
            this.TextBoxPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TextBoxPort = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ButtonConnect
            // 
            this.ButtonConnect.Location = new System.Drawing.Point(467, 445);
            this.ButtonConnect.Margin = new System.Windows.Forms.Padding(7);
            this.ButtonConnect.Name = "ButtonConnect";
            this.ButtonConnect.Size = new System.Drawing.Size(175, 51);
            this.ButtonConnect.TabIndex = 11;
            this.ButtonConnect.Text = "Connexion";
            this.ButtonConnect.UseVisualStyleBackColor = true;
            this.ButtonConnect.Click += new System.EventHandler(this.ButtonConnect_Click);
            // 
            // TextBoxServer
            // 
            this.TextBoxServer.Location = new System.Drawing.Point(193, 221);
            this.TextBoxServer.Name = "TextBoxServer";
            this.TextBoxServer.Size = new System.Drawing.Size(380, 35);
            this.TextBoxServer.TabIndex = 12;
            this.TextBoxServer.Text = "localhost";
            // 
            // TextBoxUser
            // 
            this.TextBoxUser.Location = new System.Drawing.Point(193, 309);
            this.TextBoxUser.Name = "TextBoxUser";
            this.TextBoxUser.Size = new System.Drawing.Size(449, 35);
            this.TextBoxUser.TabIndex = 13;
            this.TextBoxUser.Text = "root";
            // 
            // TextBoxPassword
            // 
            this.TextBoxPassword.Location = new System.Drawing.Point(193, 364);
            this.TextBoxPassword.Name = "TextBoxPassword";
            this.TextBoxPassword.PasswordChar = '●';
            this.TextBoxPassword.Size = new System.Drawing.Size(449, 35);
            this.TextBoxPassword.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(75, 224);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 29);
            this.label1.TabIndex = 16;
            this.label1.Text = "Serveur";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 315);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 29);
            this.label2.TabIndex = 17;
            this.label2.Text = "Utilisateur";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 367);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(158, 29);
            this.label3.TabIndex = 18;
            this.label3.Text = "Mot de passe";
            // 
            // TextBoxPort
            // 
            this.TextBoxPort.Location = new System.Drawing.Point(579, 221);
            this.TextBoxPort.Name = "TextBoxPort";
            this.TextBoxPort.Size = new System.Drawing.Size(63, 35);
            this.TextBoxPort.TabIndex = 19;
            this.TextBoxPort.Text = "9090";
            // 
            // LoginForm
            // 
            this.AcceptButton = this.ButtonConnect;
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 512);
            this.Controls.Add(this.TextBoxPort);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TextBoxPassword);
            this.Controls.Add(this.TextBoxUser);
            this.Controls.Add(this.TextBoxServer);
            this.Controls.Add(this.ButtonConnect);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SharpGED - Se connecter à un serveur";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonConnect;
        private System.Windows.Forms.TextBox TextBoxServer;
        private System.Windows.Forms.TextBox TextBoxUser;
        private System.Windows.Forms.TextBox TextBoxPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TextBoxPort;
    }
}