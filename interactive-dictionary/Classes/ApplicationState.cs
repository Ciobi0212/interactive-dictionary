using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//unordered_map<string, vector<Word>>
namespace Exersare.Classes
{
    public static class ApplicationState
    {
        static ApplicationState()
        {
            isAdmin = false;
            categories = CategoryMap.readCategoryData("D:\\repos\\interactive-dictionary\\interactive-dictionary\\JSON\\Categories.json").Categories;
            words = WordList.readWordData("D:\\repos\\interactive-dictionary\\interactive-dictionary\\JSON\\Words.json").Words;
        }

       
        public static bool isAdmin { get; set; }

        public static List<Word> words { get; set; }

        public static Dictionary<string, List<Word>> categories { get; set; }


       

        //public static List<Admin> admins { get; set; }
    }
}
