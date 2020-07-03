using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject
{
    [Serializable]
    public enum enumGenre { Horror, Business, Drama, Roman, Null = -1 }
    public class EnumHelper
    {
        public static enumGenre StringToGenre(string genre)
        {
            genre = genre.Trim();
            if (genre.ToLower() == "хоррор")
            {
                return enumGenre.Horror;
            }
            if (genre.ToLower() == "бизнес")
            {
                return enumGenre.Business;
            }
            if (genre.ToLower() == "драма")
            {
                return enumGenre.Drama;
            }
            if (genre.ToLower() == "роман")
            {
                return enumGenre.Roman;
            }
            return enumGenre.Null;
        }
        public static string GenreToString(enumGenre genre)
        {
            if (genre == enumGenre.Horror)
            {
                return "Хоррор";
            }
            if (genre == enumGenre.Business)
            {
                return "Бизнес";
            }
            if (genre == enumGenre.Drama)
            {
                return "Драма";
            }
            if (genre == enumGenre.Roman)
            {
                return "Роман";
            }
            return "Неизвестно";
        }
    }
}
