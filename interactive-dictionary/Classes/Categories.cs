using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exersare.Classes
{
    public class CategoryMap
    {
        public Dictionary<string, List<Word>> Categories { get; set; }

        public static CategoryMap readCategoryData(string filePath)
        {
            string json = System.IO.File.ReadAllText(filePath);
            CategoryMap categories = Newtonsoft.Json.JsonConvert.DeserializeObject<CategoryMap>(json);
            return categories;
        }
    }
}
