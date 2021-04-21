using Diploma.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Diploma.Forms
{
    public partial class Authorization : Form
    {
        public Authorization()
        {
            InitializeComponent();
            StartSetings();
        }
        /// <summary>
        /// Начальные настройки
        /// </summary>
        private void StartSetings()
        {
            LoginField.Text = "Введите логин";
            LoginField.ForeColor = Color.Gray;
            PasswordField.UseSystemPasswordChar = false;
            PasswordField.Text = "Введите пароль";
            PasswordField.ForeColor = Color.Gray;
            buttonLogin.Enabled = false;
        }

        #region FieldEnter
        private void LoginField_Enter(object sender, EventArgs e)
        {
            if (LoginField.Text == "Введите логин")
            {
                LoginField.ForeColor = Color.Black;
                LoginField.Text = "";
                buttonLogin.Enabled = true;
            }
        }
        private void PasswordField_Enter(object sender, EventArgs e)
        {

            if (PasswordField.Text == "Введите пароль")
            {
                PasswordField.UseSystemPasswordChar = true;
                PasswordField.ForeColor = Color.Black;
                PasswordField.Text = "";
                buttonLogin.Enabled = true;
            }
        }
        #endregion
        #region FieldLeave
        private void LoginField_Leave(object sender, EventArgs e)
        {
            if (LoginField.Text == "")
            {
                LoginField.Text = "Введите логин";
                LoginField.ForeColor = Color.Gray;
                buttonLogin.Enabled = false;
            }
        }
        private void PasswordField_Leave(object sender, EventArgs e)
        {
            if (PasswordField.Text == "")
            {
                PasswordField.UseSystemPasswordChar = false;
                PasswordField.Text = "Введите пароль";
                PasswordField.ForeColor = Color.Gray;
                buttonLogin.Enabled = false;
            }
        }
        #endregion
        #region FieldKeyPress
        /// <summary>
        /// Обработка события нажатой клавиши в поле логина
        /// </summary>
        private void LoginField_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPress(e);
        }
        /// <summary>
        /// Обработка события нажатой клавиши в поле пароля
        /// </summary>
        private void PasswordField_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPress(e);
        }
        /// <summary>
        /// Метод для проверки нажатой клавиши
        /// </summary>
        private void keyPress(KeyPressEventArgs e)
        {
            var keyChar = e.KeyChar;
            if ((e.KeyChar <= 64 || e.KeyChar >= 90) && (e.KeyChar <= 47 || e.KeyChar >= 58) && (e.KeyChar <= 96 || e.KeyChar >= 122) && keyChar != 8 && keyChar != 42 && keyChar != 95 && keyChar != 45) //цифры,буквы на английском, клавиша BackSpace и звездочка в ASCII
            {
                e.Handled = true;
            }
        }
        #endregion
        #region Button
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (PasswordField.Text != "Введите пароль" && LoginField.Text != "Введите логин"
                && PasswordField.Text != "" && LoginField.Text != "")
            {
                if(Verification(LoginField.Text,PasswordField.Text) == true)
                {
                    MessageBox.Show($"Добро пожаловать!\n{LoginField.Text}");
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show($"Введен не правильнй логин или пароль");
                }
            }

        }

        private void buttonRegistration_Click(object sender, EventArgs e)
        {
            Registration regForm = new Registration();
            regForm.Show();
        }
        #endregion

        /// <summary>
        /// Метод проверяющий логин и пароль
        /// </summary>
        private bool Verification(string log, string pas)
        {
            try
            {
                using (DataContext context = new DataContext())
                {
                    var user = context.users.FromSqlRaw($"SELECT * FROM users where login = '{log}' COLLATE SQL_Latin1_General_CP1_CS_AS and password = '{pas}' COLLATE SQL_Latin1_General_CP1_CS_AS").FirstOrDefault();
                    if (user != null)
                    {
                        UserID.userId = user.userId;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
