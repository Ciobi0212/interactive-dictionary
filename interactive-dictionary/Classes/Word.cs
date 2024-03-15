using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace Exersare.Classes
{
    public class Word
    {
        public string Name { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }

        public Word()
        {
            Name = "";
            CategoryName = "";
            Description = "";
            ImagePath = "E:\\repos\\interactive-dictionary\\WordImages\\noimg.png";
        }

        [JsonConstructor]
        public Word(string name, string categoryName, string description, string imagePath)
        {
            Name = name;
            CategoryName = categoryName;
            Description = description;
            ImagePath = imagePath;

            ApplicationState.categoriesMap[categoryName].Add(this);

            ApplicationState.categoriesMap["All"].Add(this);
        }

        public static List<Word> readWordData(string filePath)
        {
            string json = System.IO.File.ReadAllText(filePath);
            List<Word> words = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Word>>(json);
            return words;
        }
    }
}
