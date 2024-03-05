using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Exersare.Classes
{
    public static class ApplicationState
    {
        static ApplicationState()
        {
            // Admin is not logged in by default
            isAdmin = false;

            // Admin is not adding a new word by default
            isAdding = false;

            // Read data from JSON files
            categoriesMap = Category.readCategoryData("D:\\repos\\interactive-dictionary\\interactive-dictionary\\JSON\\Categories.json");
            words = Word.readWordData("D:\\repos\\interactive-dictionary\\interactive-dictionary\\JSON\\Words.json");
            admins = Admin.readAdminData("D:\\repos\\interactive-dictionary\\interactive-dictionary\\JSON\\admins_data.json");

            // Initialize the variables we need for the application
            suggestedWords = new ObservableCollection<Word>();
            categoriesNames = new ObservableCollection<string>(categoriesMap.Keys);
            selectedWord = new Word();
        }

        public static void saveData()
        {
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(categoriesMap.Keys);
            System.IO.File.WriteAllText("D:\\repos\\interactive-dictionary\\interactive-dictionary\\JSON\\Categories.json", json);

            json = Newtonsoft.Json.JsonConvert.SerializeObject(words);
            System.IO.File.WriteAllText("D:\\repos\\interactive-dictionary\\interactive-dictionary\\JSON\\Words.json", json);

            json = Newtonsoft.Json.JsonConvert.SerializeObject(admins);
            System.IO.File.WriteAllText("D:\\repos\\interactive-dictionary\\interactive-dictionary\\JSON\\admins_data.json", json);
        }
        public static bool isAdmin { get; set; }
        public static bool isAdding { get; set; }
        public static List<Word> words { get; set; }
        public static Dictionary<string, List<Word>> categoriesMap { get; set; }
        public static List<Admin> admins { get; set; }
        public static Word selectedWord { get; set; }

        public static ObservableCollection<Word> suggestedWords;

        public static ObservableCollection<string> categoriesNames;
    }
}
