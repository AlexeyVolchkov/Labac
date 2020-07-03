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
    public partial class InputBookForm : Form
    {
        public Book book = null;
        public InputBookForm(Book book = null)
        {
            InitializeComponent();
            if (book != null)
            {
                tbName.Text = book.name;
                tbAuthor.Text = book.author;
                tbGenre.Text = EnumHelper.GenreToString(book.genre);
                tbYear.Text = book.year.ToString();
            }
        }

        public void EditOrFind()
        {
            btAction.Text = "Изменить";
        }

        private void BtAction_Click(object sender, EventArgs e)
        {
            if (tbName.Text.Trim() == "")
            {
                MessageBox.Show("Введите название");
                return;
            }
            if (tbAuthor.Text.Trim() == "")
            {
                MessageBox.Show("Введите автора");
                return;
            }
            if (EnumHelper.StringToGenre(tbGenre.Text) == enumGenre.Null)
            {
                MessageBox.Show("Введите жанр");
                return;
            }
            if (!BookHelper.IsCorrectYear(tbYear.Text))
            {
                MessageBox.Show("Введите корректный год");
                return;
            }
            book = new Book(tbName.Text, EnumHelper.StringToGenre(tbGenre.Text), tbAuthor.Text, Int32.Parse(tbYear.Text));
            DialogResult = DialogResult.OK;
        }
    }
}
