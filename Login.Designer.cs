
namespace InventariztionTelecom
{
    partial class Login
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
            this.loginBtn = new System.Windows.Forms.PictureBox();
            this.headTile = new System.Windows.Forms.PictureBox();
            this.titleLabel = new System.Windows.Forms.Label();
            this.regBtn = new System.Windows.Forms.PictureBox();
            this.loginField = new System.Windows.Forms.TextBox();
            this.passField = new System.Windows.Forms.TextBox();
            this.loginLabel = new System.Windows.Forms.Label();
            this.passLabel = new System.Windows.Forms.Label();
            this.exitButton = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.loginBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headTile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.regBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exitButton)).BeginInit();
            this.SuspendLayout();
            // 
            // loginBtn
            // 
            this.loginBtn.Image = global::InventariztionTelecom.Properties.Resources.login_button2;
            this.loginBtn.Location = new System.Drawing.Point(95, 356);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(166, 63);
            this.loginBtn.TabIndex = 0;
            this.loginBtn.TabStop = false;
            this.loginBtn.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // headTile
            // 
            this.headTile.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.headTile.Location = new System.Drawing.Point(-2, -3);
            this.headTile.Name = "headTile";
            this.headTile.Size = new System.Drawing.Size(417, 50);
            this.headTile.TabIndex = 1;
            this.headTile.TabStop = false;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.titleLabel.ForeColor = System.Drawing.Color.White;
            this.titleLabel.Location = new System.Drawing.Point(95, -3);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(194, 37);
            this.titleLabel.TabIndex = 2;
            this.titleLabel.Text = "Авторизация";
            // 
            // regBtn
            // 
            this.regBtn.Image = global::InventariztionTelecom.Properties.Resources.Create_account;
            this.regBtn.Location = new System.Drawing.Point(95, 435);
            this.regBtn.Name = "regBtn";
            this.regBtn.Size = new System.Drawing.Size(166, 63);
            this.regBtn.TabIndex = 3;
            this.regBtn.TabStop = false;
            this.regBtn.Click += new System.EventHandler(this.regBtn_Click);
            // 
            // loginField
            // 
            this.loginField.Location = new System.Drawing.Point(115, 92);
            this.loginField.Multiline = true;
            this.loginField.Name = "loginField";
            this.loginField.Size = new System.Drawing.Size(100, 23);
            this.loginField.TabIndex = 4;
            // 
            // passField
            // 
            this.passField.Location = new System.Drawing.Point(115, 224);
            this.passField.Multiline = true;
            this.passField.Name = "passField";
            this.passField.PasswordChar = '*';
            this.passField.Size = new System.Drawing.Size(100, 23);
            this.passField.TabIndex = 5;
            // 
            // loginLabel
            // 
            this.loginLabel.AutoSize = true;
            this.loginLabel.BackColor = System.Drawing.Color.Transparent;
            this.loginLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.loginLabel.ForeColor = System.Drawing.Color.White;
            this.loginLabel.Location = new System.Drawing.Point(115, 50);
            this.loginLabel.Name = "loginLabel";
            this.loginLabel.Size = new System.Drawing.Size(95, 37);
            this.loginLabel.TabIndex = 6;
            this.loginLabel.Text = "Логин";
            // 
            // passLabel
            // 
            this.passLabel.AutoSize = true;
            this.passLabel.BackColor = System.Drawing.Color.Transparent;
            this.passLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.passLabel.ForeColor = System.Drawing.Color.White;
            this.passLabel.Location = new System.Drawing.Point(115, 174);
            this.passLabel.Name = "passLabel";
            this.passLabel.Size = new System.Drawing.Size(111, 37);
            this.passLabel.TabIndex = 7;
            this.passLabel.Text = "Пароль";
            // 
            // exitButton
            // 
            this.exitButton.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.exitButton.Image = global::InventariztionTelecom.Properties.Resources.poweroff;
            this.exitButton.Location = new System.Drawing.Point(365, -3);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(50, 50);
            this.exitButton.TabIndex = 8;
            this.exitButton.TabStop = false;
            this.exitButton.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGreen;
            this.ClientSize = new System.Drawing.Size(415, 500);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.passLabel);
            this.Controls.Add(this.loginLabel);
            this.Controls.Add(this.passField);
            this.Controls.Add(this.loginField);
            this.Controls.Add(this.regBtn);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.headTile);
            this.Controls.Add(this.loginBtn);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Login";
            this.Text = "Login";
            ((System.ComponentModel.ISupportInitialize)(this.loginBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.headTile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.regBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exitButton)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox loginBtn;
        private System.Windows.Forms.PictureBox headTile;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.PictureBox regBtn;
        private System.Windows.Forms.TextBox loginField;
        private System.Windows.Forms.TextBox passField;
        private System.Windows.Forms.Label loginLabel;
        private System.Windows.Forms.Label passLabel;
        private System.Windows.Forms.PictureBox exitButton;
    }
}