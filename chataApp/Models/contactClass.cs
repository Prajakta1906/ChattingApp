using System;
using SQLite;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using Xamarin.Forms;
using Xamarin.Essentials;
using Firebase.Storage;
using System.Threading.Tasks;
using System.IO;

namespace chataApp.Models
{
    public class contactClass
    {
        

        [MaxLength(15)]
        public string userID { get; set; }
        public string username { get; set; }

        [PrimaryKey ,MaxLength(10)]

        public string number { get; set; }

       [MaxLength(15)]
       public string password { get; set; }

        public string thelink { get; set; }

        public string validatepass { get; set; }

        
    }
}
