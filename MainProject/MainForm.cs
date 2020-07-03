using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainProject
{
    public partial class MainForm : Form
    {
        // Класс для работы с файлами
        FileManager fm = null;
        List<Book> books;
        public MainForm()
        {
            InitializeComponent();
            dgv.TopLeftHeaderCell.Value = "№";
            books = new List<Book>();
            fm = new FileManager(books);
        }
        public void UpdateDgv()
        {
            dgv.Rows.Clear();
            if (books.Count > 0)
            {
                dgv.DataSource = null;
                dgv.DataSource = books;
                dgv.Columns["name"].HeaderText = "Название";
                dgv.Columns["author"].HeaderText = "Автор";
                dgv.Columns["genre"].HeaderText = "Жанр";
                dgv.Columns["year"].HeaderText = "Год";
            }
        }
        private void BtAdd_Click(object sender, EventArgs e)
        {
            using (InputBookForm inForm = new InputBookForm())
            {
                if (inForm.ShowDialog() == DialogResult.OK)
                {
                    books.Add(inForm.book);
                    UpdateDgv();
                }
            }
        }
        private void ChangeRow(DataGridViewRow row)
        {
            using (InputBookForm inForm = new InputBookForm((Book)row.DataBoundItem))
            {
                inForm.EditOrFind();
                if (inForm.DialogResult == DialogResult.OK)
                {
                    books.Add(inForm.book);
                    UpdateDgv();
                }
            }
        }
        private void Dgv_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ChangeRow(dgv.SelectedRows[0]);
        }
        private void BtDelete_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                books.Remove((Book)dgv.SelectedRows[0].DataBoundItem);
                UpdateDgv();
            }
        }

        private void BtTask_Click(object sender, EventArgs e)
        {
            enumGenre genre;
            using (InputForm inputForm = new InputForm("Введите жанр"))
            {
                if (inputForm.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                genre = EnumHelper.StringToGenre(inputForm.inText.ToString());
                if (genre == enumGenre.Null)
                {
                    MessageBox.Show("Вы ввели некорректный жанр!");
                    return;
                }
            }
            List<Book> bookList = new List<Book>();
            foreach (Book book in books)
            {
                if (book.genre == genre)
                {
                    bookList.Add(book);
                }
            }
            bookList.Sort(new MyComparer());
            string message = "Количество книг с заданным жанром: " + bookList.Count + "\n";
            foreach(Book book in bookList)
            {
                message += book.name + "\n";
            }
            MessageBox.Show(message);
        }

        private void Dgv_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            stripLabel.Text = "Количество элементов: " + dgv.Rows.Count;
        }

        private void Dgv_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            stripLabel.Text = "Количество элементов: " + dgv.Rows.Count;
        }

        private void MenuClear_Click(object sender, EventArgs e)
        {
            dgv.Rows.Clear();
        }

        private void MenuCreate_Click(object sender, EventArgs e)
        {
            books.Clear();
            UpdateDgv();
        }

        private void MenuSave_Click(object sender, EventArgs e)
        {
            if (fm.Filepath != "")
            {
                fm.Save();
            }
            UpdateDgv();
        }

        private void BtEdit_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите строку");
                return;
            }
            int rowIndex = dgv.SelectedRows[0].Index;
            Book book = (Book) dgv.SelectedRows[0].DataBoundItem;
            using (InputBookForm inputBookForm = new InputBookForm(book))
            {
                inputBookForm.EditOrFind();
                if (inputBookForm.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                book = inputBookForm.book;
                books.Add(book);
                UpdateDgv();
            }
        }

        private void MenuOpen_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                fm.Filepath = openFileDialog.FileName;
                if (!fm.Load())
                {
                    MessageBox.Show("Не удалось загрузить файл");
                }
                UpdateDgv();
            }
        }

        private void MenuSaveAs_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                fm.Filepath = saveFileDialog.FileName;
                if (!fm.Save())
                {
                    MessageBox.Show("Не удалось сохранить файл");
                }
                UpdateDgv();
            }
        }
    }
}
