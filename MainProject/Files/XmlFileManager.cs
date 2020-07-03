using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace MainProject.Files
{
    class XmlFileManager : IFileManager
    {
        public List<Book> books { get; set; }
        public XmlFileManager(List<Book> books)
        {
            this.books = books;
        }
        public bool Load(string filepath)
        {
            try
            {
                XmlSerializer formatter = new XmlSerializer(typeof(List<Book>));
                using (FileStream fs = new FileStream(filepath, FileMode.OpenOrCreate))
                {
                    books = (List<Book>)formatter.Deserialize(fs);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Save(string filepath)
        {
            try
            {
                XmlSerializer formatter = new XmlSerializer(typeof(List<Book>));
                using (FileStream fs = new FileStream(filepath, FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, books);
                }
                return true;
            } catch
            {
                return false;
            }
        }
    }
}
