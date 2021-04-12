using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security;
using Diploma.DAL;
using Diploma.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using System.Configuration;

namespace Diploma
{
    public partial class FormMain : Form
    {
        private SqlCommandBuilder sqlBuilder { get; set; }
        private SqlDataAdapter sqlDataAdapter { get; set; }
        private DataSet dataSet { get; set; }
        private string connectionString { get; set; }
        private int userId { get; set; } = 1; // Будем передовать сюда userId
        public FormMain()
        {
            InitializeComponent();
        }

        #region ButtonClick

        /// <summary>
        /// Метод для обработки нажатия на кнопку
        /// </summary>
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            FolderBrowserDialogShow();
            ReloadData();
        }

        /// <summary>
        /// Метод добавляющий данные в таблицу userDatas
        /// </summary>
        private void AddData(FolderBrowserDialog FBD)
        {
            var likeExe = "*.exe";
            var path = FBD.SelectedPath;
            try
            {
                foreach (var findedFile in Directory.EnumerateFiles(path, likeExe, SearchOption.AllDirectories))
                {
                    FileInfo fileInfo = new FileInfo(findedFile);
                    using (DataContext context = new DataContext())
                    {
                        var user = context.users.Where(u => u.userId == 1).FirstOrDefault();
                        UserData userData = new UserData()
                        {
                            userId = userId,
                            name = fileInfo.Name,
                            path = fileInfo.FullName,
                            user = user

                        };
                        context.userDatas.Add(userData);
                        context.SaveChanges();
                    }

                }
            }
            catch (SecurityException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Метод отвечающий за вызов диалога с выбором директории
        /// </summary>
        private void FolderBrowserDialogShow()
        {
            try
            {
                FolderBrowserDialog FBD = new FolderBrowserDialog();
                FBD.ShowNewFolderButton = false;
                if (FBD.ShowDialog() == DialogResult.OK)
                {
                    AddData(FBD);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region StartSettings

        /// <summary>
        /// Метод вызывающийся при загрузке формы
        /// </summary>
        private void FormMain_Load(object sender, EventArgs e)
        {
            StartSetings();
            connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            var sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            ShowData(sqlConnection);
        }

        /// <summary>
        /// Метод для начальной установки настроек dataGridViewMain
        /// </summary>
        private void StartSetings()
        {

            try
            {
                dataGridViewMain.RowTemplate.Height = 40; // Устанавливает высоту строки
                dataGridViewMain.RowHeadersVisible = false; // Удаляет леввый столбец в отображении таблиц
                dataGridViewMain.DefaultCellStyle.SelectionBackColor = Color.White; // Устанавливает цвет выбранной ячейки
                dataGridViewMain.AllowUserToResizeColumns = false; // Запрещает изменение размера стобца
                dataGridViewMain.AllowUserToResizeRows = false; // Запрещает изменение размера строки
                dataGridViewMain.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 14); // Устанавливает размер и тип текста
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Метод для показа уже существующийх данных
        /// </summary>
        private void ShowData(SqlConnection sqlConnection)
        {
            try
            {
                sqlDataAdapter = new SqlDataAdapter($"Select name as [Название],'Удалить' as [Удалить] from userDatas where userId = {userId}", sqlConnection);
                sqlBuilder = new SqlCommandBuilder(sqlDataAdapter);
                dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet, "userDatas");
                dataGridViewMain.DataSource = dataSet.Tables["userDatas"];
                dataGridViewRowAndCellsSettings();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region DataGridViewMainContentClick
        /// <summary>
        /// Метод обрабатывающий нажатие на поле DataGridView
        /// </summary>
        private void dataGridViewMain_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0) // Запуск
                {
                    StartExe(e);
                }
                else if (e.ColumnIndex == 1) // Удаление
                {
                    DeletData(e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Метод для запуска приложений
        /// </summary>
        private void StartExe(DataGridViewCellEventArgs e)
        {
            try
            {
                int rowIndex = e.RowIndex;
                var name = dataSet.Tables["userDatas"].Rows[rowIndex][0].ToString();
                string path;
                using (DataContext context = new DataContext())
                {
                    path = context.userDatas.Where(p => p.name == name).Select(ud => ud.path).FirstOrDefault();
                }
                System.Diagnostics.Process Proc = new System.Diagnostics.Process();
                Proc.StartInfo.FileName = path;
                Proc.Start();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Метод для удаления данных из таблицы
        /// </summary>
        /// <param name="e"></param>
        private void DeletData(DataGridViewCellEventArgs e)
        {
            try
            {
                if ((MessageBox.Show("Удалить данные?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) == DialogResult.Yes)
                {
                    int rowIndex = e.RowIndex;
                    var name = dataSet.Tables["userDatas"].Rows[rowIndex][0].ToString();
                    using (DataContext context = new DataContext())
                    {
                        var data = context.userDatas.Where(p => p.name == name).FirstOrDefault();
                        context.userDatas.Remove(data);
                        context.SaveChanges();
                    }
                    ReloadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        /// <summary>
        /// Метод для настрокий столбцов и строк DataGridView
        /// </summary>
        private void dataGridViewRowAndCellsSettings()
        {
            try
            {
                for (int i = 0; i < dataGridViewMain.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridViewMain.ColumnCount; j++)
                    {
                        dataGridViewMain.Rows[i].Cells[j].ReadOnly = true;
                    }
                }
                for (int i = 0; i < dataGridViewMain.Rows.Count; i++)
                {
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    linkCell.LinkColor = Color.Black; // Устанавливает черный цвет для текста
                    dataGridViewMain[1, i] = linkCell;
                }
                for (int i = 0; i < dataGridViewMain.Rows.Count; i++)
                {
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    linkCell.LinkColor = Color.Black;
                    dataGridViewMain[0, i] = linkCell;
                    dataGridViewMain[0, i].Style.Alignment = DataGridViewContentAlignment.MiddleLeft; // Устанавливает текст слева, а для другого столбца в конструкторе установленно на центр
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Метод для обновления данных
        /// </summary>
        private void ReloadData()
        {
            try
            {
                dataSet.Tables["userDatas"].Clear();
                sqlDataAdapter.Fill(dataSet, "userDatas");
                dataGridViewMain.DataSource = dataSet.Tables["userDatas"];
                dataGridViewRowAndCellsSettings();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
