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
    }

    public class AdminList
    {
        public List<Admin> Admins { get; set; }

        public static AdminList readAdminData(string filePath)
        {
            string json = File.ReadAllText(filePath);
            AdminList admins = JsonConvert.DeserializeObject<AdminList>(json);
            return admins;
        }
    }


   
    
}
