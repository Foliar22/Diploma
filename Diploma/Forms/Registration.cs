using Diploma.DAL;
using Diploma.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diploma.Forms
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
            StartSetings();
        }
        private void StartSetings()
        {
            LoginField.Text = "Введите логин";
            LoginField.ForeColor = Color.Gray;
            PasswordField.UseSystemPasswordChar = false;
            PasswordRepeatField.UseSystemPasswordChar = false;
            PasswordField.Text = "Введите пароль";
            PasswordField.ForeColor = Color.Gray;
            PasswordRepeatField.Text = "Повторите пароль";
            PasswordRepeatField.ForeColor = Color.Gray;
            buttonRegistration.Enabled = false;
        }
        #region FieldEnter
        private void LoginField_Enter(object sender, EventArgs e)
        {
            if (LoginField.Text == "Введите логин")
            {
                LoginField.ForeColor = Color.Black;
                LoginField.Text = "";
                buttonRegistration.Enabled = true;
            }
        }
        private void PasswordField_Enter(object sender, EventArgs e)
        {
            if (PasswordField.Text == "Введите пароль")
            {
                PasswordField.UseSystemPasswordChar = true;
                PasswordField.ForeColor = Color.Black;
                PasswordField.Text = "";
                buttonRegistration.Enabled = true;
            }
        }
        private void PasswordRepeatField_Enter(object sender, EventArgs e)
        {
            if (PasswordRepeatField.Text == "Повторите пароль")
            {
                PasswordRepeatField.UseSystemPasswordChar = true;
                PasswordRepeatField.ForeColor = Color.Black;
                PasswordRepeatField.Text = "";
                buttonRegistration.Enabled = true;
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
                buttonRegistration.Enabled = false;
            }

        }
        private void PasswordField_Leave(object sender, EventArgs e)
        {
            if (PasswordField.Text == "")
            {
                PasswordField.UseSystemPasswordChar = false;
                PasswordField.Text = "Введите пароль";
                PasswordField.ForeColor = Color.Gray;
                MessageBox.Show("Введите пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                buttonRegistration.Enabled = false;
            }
        }
        private void PasswordRepeatField_Leave(object sender, EventArgs e)
        {
            if (PasswordRepeatField.Text == "")
            {
                PasswordRepeatField.UseSystemPasswordChar = false;
                PasswordRepeatField.Text = "Повторите пароль";
                PasswordRepeatField.ForeColor = Color.Gray;
                MessageBox.Show("Повторите пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                buttonRegistration.Enabled = false;
            }
        }
        #endregion
        #region FieldKeyPress

        private void LoginField_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPress(e);
        }

        private void PasswordField_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPress(e);
        }

        private void PasswordRepeatField_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPress(e);
        }

        #endregion
        #region ToolTip
        /// <summary>
        /// Метод обрабатывающий удержание указателя мышки на элементе LoginField
        /// </summary>
        /// <remarks>
        /// Создает элемент ToolTip при удерживании
        /// </remarks>
        private void LoginField_MouseHover(object sender, EventArgs e)
        {
            var toolTip = new ToolTip();
            toolTip.SetToolTip(LoginField, "Буквы [A,a - Z,z]\nЦифры\nСимволы: * - _");
        }
        /// <summary>
        /// Метод обрабатывающий удержание указателя мышки на элементе PasswordField
        /// </summary>
        /// <remarks>
        /// Создает элемент ToolTip при удерживании
        /// </remarks>
        private void PasswordField_MouseHover(object sender, EventArgs e)
        {
            var toolTip = new ToolTip();
            toolTip.SetToolTip(PasswordField, "Буквы [A,a - Z,z]\nЦифры\nСимволы: * - _");
        }
        /// <summary>
        /// Метод обрабатывающий удержание указателя мышки на элементе PasswordRepeatField
        /// </summary>
        /// <remarks>
        /// Создает элемент ToolTip при удерживании
        /// </remarks>
        private void PasswordRepeatField_MouseHover(object sender, EventArgs e)
        {
            var toolTip = new ToolTip();
            toolTip.SetToolTip(PasswordRepeatField, "Буквы [A,a - Z,z]\nЦифры\nСимволы: * - _");
        }
        #endregion
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

        /// <summary>
        /// Метод для проверки уникальности логина
        /// </summary>
        private bool UniquenessCheck(string login)
        {
            bool res = true;
            using (DataContext context = new DataContext())
            {
                var user = context.users.Where(u => u.login == login).FirstOrDefault();
                if (user != null)
                {
                   if(String.Equals(user.login, login))
                    {
                        MessageBox.Show("Логин занят", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LoginField.Focus();
                        return res = false;
                    }

                }
            }
            return res;
        }
        private void buttonRegistration_Click(object sender, EventArgs e)
        {
            if (LoginField.Text != "Введите логин")
            {
                if (UniquenessCheck(LoginField.Text) == true)
                {
                    if (!String.Equals(PasswordField.Text,PasswordRepeatField.Text))
                    {
                        MessageBox.Show("Пароли не совпадают", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        PasswordRepeatField.Focus();
                    }
                    else
                    {
                        try
                        {
                            using (DataContext context = new DataContext())
                            {
                                var newUser = new User()
                                {
                                    login = LoginField.Text,
                                    password = PasswordField.Text
                                };
                                context.users.Add(newUser);
                                context.SaveChanges();
                            }
                            MessageBox.Show("Регистрация прошла успешно ", "Завершение регистрации", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Введите логин", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

    }
}
