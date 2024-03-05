using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace Exersare.Classes
{
    public class Admin
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public static List<Admin> readAdminData(string filePath)
        {
            string json = File.ReadAllText(filePath);
            List<Admin> admins = JsonConvert.DeserializeObject<List<Admin>>(json);
            return admins;
        }
    }
    
}
