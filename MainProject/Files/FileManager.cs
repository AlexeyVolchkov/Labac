using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using MainProject.Files;

namespace MainProject
{
    class FileManager
    {
        List<Book> books;
        private string filepath;
        public string Filepath
        {
            get
            {
                return filepath;
            }
            set
            {
                filepath = value;
            }
        }

        public FileManager(List<Book> books)
        {
            this.books = books;
        }
        private IFileManager GetFileManager(string ext)
        {
            if (ext == ".txt")
            {
                return new TextFileManager(books);
            }
            else if (ext == ".xml")
            {
                return new XmlFileManager(books);
            }
            else
            {
                return new BinaryFileManager(books);
            }
        }
        public bool Load()
        {
            if (filepath.IndexOf(".") == -1)
            {
                MessageBox.Show("Неподдерживаемое расширение файла. Поддерживаются bin, xml, txt");
                return false;
            }
            IFileManager fileManager = GetFileManager(filepath.Substring(filepath.IndexOf(".")));
            return fileManager.Load(filepath);
        }
        public bool Save()
        {
            if (filepath.IndexOf(".") == -1)
            {
                MessageBox.Show("Неподдерживаемое расширение файла. Поддерживаются bin, xml, txt");
                return false;
            }
            IFileManager fileManager = GetFileManager(filepath.Substring(filepath.IndexOf(".")));
            return fileManager.Save(filepath);
        }
    }
}
