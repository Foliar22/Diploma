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
        public FormMain()
        {
            InitializeComponent();
           
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            FolderBrowserDialogShow();
        }

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
            dataGridViewMain.RowTemplate.Height = 40; // Устанавливает высоту строки
            dataGridViewMain.RowHeadersVisible = false; // Удаляет леввый столбец в отображении таблиц
            dataGridViewMain.DefaultCellStyle.SelectionBackColor = Color.White; // Устанавливает цвет выбранной ячейки
            dataGridViewMain.AllowUserToResizeColumns = false; // Запрещает изменение размера стобца
            dataGridViewMain.AllowUserToResizeRows = false; // Запрещает изменение размера строки
            dataGridViewMain.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 14); // Устанавливает размер и тип текста
        }

        /// <summary>
        /// Метод для настрокий столбцов и строк DataGridView
        /// </summary>
        private void dataGridViewRowAndCellsSettings()
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

        /// <summary>
        /// Метод для показа уже существующийх данных
        /// </summary>
        private void ShowData(SqlConnection sqlConnection)
        {
            sqlDataAdapter = new SqlDataAdapter("Select name as [Название],'Удалить' as [Удалить] from userDatas where userId = 1", sqlConnection);
            sqlBuilder = new SqlCommandBuilder(sqlDataAdapter);
            dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet, "UserData");
            dataGridViewMain.DataSource = dataSet.Tables["UserData"];
            dataGridViewRowAndCellsSettings();
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
                    MessageBox.Show($"Имя {fileInfo.Name}\npath {fileInfo.FullName}");
                    using (DataContext context = new DataContext())
                    {
                        var user = context.users.Where(u => u.userId == 1).FirstOrDefault();
                        UserData userData = new UserData()
                        {
                            userId = 1,
                            name = fileInfo.Name,
                            path = fileInfo.FullName,
                            user = user

                        };
                        context.userDatas.Add(userData);
                        context.SaveChanges();
                    }

                }
            }
            catch (SecurityException)
            {
                MessageBox.Show("Доступ запрещен");
            }
            catch (Exception)
            {
                MessageBox.Show("Доступ запрещен");
            }
        }

        /// <summary>
        /// Метод отвечающий за вызов диалога с выбором директории
        /// </summary>
        private void FolderBrowserDialogShow()
        {
            FolderBrowserDialog FBD = new FolderBrowserDialog();
            FBD.ShowNewFolderButton = false;
            if (FBD.ShowDialog() == DialogResult.OK)
            {
                AddData(FBD);
            }
        }
    }
}
