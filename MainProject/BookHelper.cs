using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainProject
{
    public class BookHelper
    {
        public static bool IsCorrectYear(string strYear)
        {
            int year;
            if (Int32.TryParse(strYear, out year) && year >= -2000 && year <= 2020)
            {
                return true;
            }
            return false;
        }
    }
}
