
namespace Diploma.Forms
{
    partial class Registration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Registration));
            this.pictureBoxLogin = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.PasswordField = new System.Windows.Forms.TextBox();
            this.LoginField = new System.Windows.Forms.TextBox();
            this.PasswordRepeatField = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonRegistration = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogin)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxLogin
            // 
            this.pictureBoxLogin.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxLogin.Image")));
            this.pictureBoxLogin.Location = new System.Drawing.Point(57, 64);
            this.pictureBoxLogin.Name = "pictureBoxLogin";
            this.pictureBoxLogin.Size = new System.Drawing.Size(48, 50);
            this.pictureBoxLogin.TabIndex = 11;
            this.pictureBoxLogin.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(107, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 24);
            this.label2.TabIndex = 10;
            this.label2.Text = "Пароль";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(107, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 24);
            this.label1.TabIndex = 9;
            this.label1.Text = "Логин";
            // 
            // PasswordField
            // 
            this.PasswordField.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PasswordField.Location = new System.Drawing.Point(111, 162);
            this.PasswordField.Name = "PasswordField";
            this.PasswordField.Size = new System.Drawing.Size(271, 29);
            this.PasswordField.TabIndex = 8;
            this.PasswordField.TabStop = false;
            this.PasswordField.Enter += new System.EventHandler(this.PasswordField_Enter);
            this.PasswordField.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PasswordField_KeyPress);
            this.PasswordField.Leave += new System.EventHandler(this.PasswordField_Leave);
            this.PasswordField.MouseHover += new System.EventHandler(this.PasswordField_MouseHover);
            // 
            // LoginField
            // 
            this.LoginField.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LoginField.Location = new System.Drawing.Point(111, 85);
            this.LoginField.Name = "LoginField";
            this.LoginField.Size = new System.Drawing.Size(271, 29);
            this.LoginField.TabIndex = 7;
            this.LoginField.TabStop = false;
            this.LoginField.Enter += new System.EventHandler(this.LoginField_Enter);
            this.LoginField.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.LoginField_KeyPress);
            this.LoginField.Leave += new System.EventHandler(this.LoginField_Leave);
            this.LoginField.MouseHover += new System.EventHandler(this.LoginField_MouseHover);
            // 
            // PasswordRepeatField
            // 
            this.PasswordRepeatField.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PasswordRepeatField.Location = new System.Drawing.Point(111, 228);
            this.PasswordRepeatField.Name = "PasswordRepeatField";
            this.PasswordRepeatField.Size = new System.Drawing.Size(271, 29);
            this.PasswordRepeatField.TabIndex = 12;
            this.PasswordRepeatField.TabStop = false;
            this.PasswordRepeatField.Enter += new System.EventHandler(this.PasswordRepeatField_Enter);
            this.PasswordRepeatField.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PasswordRepeatField_KeyPress);
            this.PasswordRepeatField.Leave += new System.EventHandler(this.PasswordRepeatField_Leave);
            this.PasswordRepeatField.MouseHover += new System.EventHandler(this.PasswordRepeatField_MouseHover);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(107, 201);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(178, 24);
            this.label3.TabIndex = 13;
            this.label3.Text = "Повторите пароль";
            // 
            // buttonRegistration
            // 
            this.buttonRegistration.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonRegistration.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonRegistration.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRegistration.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonRegistration.Location = new System.Drawing.Point(128, 314);
            this.buttonRegistration.Name = "buttonRegistration";
            this.buttonRegistration.Size = new System.Drawing.Size(237, 43);
            this.buttonRegistration.TabIndex = 14;
            this.buttonRegistration.Text = "Зарегистрироваться";
            this.buttonRegistration.UseVisualStyleBackColor = true;
            this.buttonRegistration.Click += new System.EventHandler(this.buttonRegistration_Click);
            // 
            // Registration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(490, 450);
            this.Controls.Add(this.buttonRegistration);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.PasswordRepeatField);
            this.Controls.Add(this.pictureBoxLogin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PasswordField);
            this.Controls.Add(this.LoginField);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(506, 489);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(506, 489);
            this.Name = "Registration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registration";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxLogin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox PasswordField;
        private System.Windows.Forms.TextBox LoginField;
        private System.Windows.Forms.TextBox PasswordRepeatField;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonRegistration;
    }
}