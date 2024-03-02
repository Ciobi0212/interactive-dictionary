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
        private string Name { get; set; }
        private string CategoryName { get; set; }
        private string Description { get; set; }
        private string ImagePath { get; set; }

        [JsonConstructor]
        public Word(string name, string categoryName, string description, string imagePath)
        {
            Name = name;
            CategoryName = categoryName;
            Description = description;
            ImagePath = imagePath;

            ApplicationState.categories[categoryName].Add(this);
        }
    }

    public class WordList
    {
        public List<Word> Words { get; set; }

        public static WordList readWordData(string filePath)
        {
            string json = System.IO.File.ReadAllText(filePath);
            WordList words = Newtonsoft.Json.JsonConvert.DeserializeObject<WordList>(json);
            return words;
        }
    }
}
