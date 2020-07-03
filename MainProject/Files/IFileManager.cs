using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.Files
{
    public interface IFileManager
    {
        bool Save(string filepath);
        bool Load(string filepath);
    }
}
