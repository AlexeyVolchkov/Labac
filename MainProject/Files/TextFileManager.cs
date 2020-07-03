using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainProject.Files
{
    public class TextFileManager : IFileManager
    {
        public List<Book> books { get; set; }
        public TextFileManager(List<Book> books)
        {
            this.books = books;
        }
        public bool Load(string filepath)
        {
            books.Clear();
            try
            {
                using (StreamReader sr = new StreamReader(filepath, Encoding.UTF8))
                {
                    while (!sr.EndOfStream)
                    {
                        Book book = new Book();
                        string line;
                        line = sr.ReadLine();
                        line = line.Substring(line.IndexOf(":") + 1).Trim();
                        book.name = line;

                        line = sr.ReadLine();
                        line = line.Substring(line.IndexOf(":") + 1).Trim();
                        book.author = line;

                        line = sr.ReadLine();
                        line = line.Substring(line.IndexOf(":") + 1).Trim();
                        book.genre = EnumHelper.StringToGenre(line);

                        line = sr.ReadLine();
                        line = line.Substring(line.IndexOf(":") + 1).Trim();
                        if (BookHelper.IsCorrectYear(line))
                        {
                            book.year = Int32.Parse(line);
                        } else
                        {
                            throw new Exception();
                        }
                        books.Add(book);
                    }
                }
            } catch
            {
                return false;
            }

            return true;
        }

        public bool Save(string filepath)
        {
            using (StreamWriter sw = new StreamWriter(filepath, false, Encoding.UTF8))
            {
                foreach (Book book in books)
                {
                    sw.WriteLine("Название: " + book.name);
                    sw.WriteLine("Автор: " + book.author);
                    sw.WriteLine("Жанр: " + EnumHelper.GenreToString(book.genre));
                    sw.WriteLine("Год издания: " + book.year);
                }
            }
            return true;
        }
    }
}
