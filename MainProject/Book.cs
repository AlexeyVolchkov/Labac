using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainProject
{
    [Serializable]
    public class Book
    {
        public string name { get; set; }
        public string author { get; set; }
        public enumGenre genre { get; set; }
        public int year { get; set; }

        public Book()
        {}
        public Book(string name, enumGenre genre, string author, int year)
        {
            this.name = name;
            this.author = author;
            this.genre = genre;
            this.year = year;
        }
    }
    public class MyComparer : IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            return y.year - x.year;
        }
    }
}
