using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exersare.Classes
{
    public class Category
    {
        public static Dictionary<string, List<Word>> readCategoryData(string filePath)
        {
            string json = System.IO.File.ReadAllText(filePath);
            List<string> names = Newtonsoft.Json.JsonConvert.DeserializeObject<List<string>>(json);
            Dictionary<string, List<Word>> Categories = new Dictionary<string, List<Word>>();

            foreach (string name in names)
            {
                Categories.Add(name, new List<Word>());
            }

            return Categories;
        }
    }
}
