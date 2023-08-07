using Firebase.Database;
using Firebase.Database.Query;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using Firebase.Auth.Providers;
using System.Text;
using System.Threading.Tasks;
using Firebase.Auth;

namespace chataApp.Models
{
    public class globalDetail 
    {
        FirebaseClient firebaseClient = new FirebaseClient("https://chatsapp-15e29-default-rtdb.asia-southeast1.firebasedatabase.app/");

        //string webAPIKey = "AIzaSyBKzXtJuEjN5cvsgfIVvGq-_84QOBH8H9I";
        //FirebaseAuthProvider authProvider;

       




        contactClass cc = new contactClass();

        public async Task<bool> Save(contactClass cc)
        {
            var data = await firebaseClient.Child("user info").Child(cc.userID).PostAsync(JsonConvert.SerializeObject(cc));
            {
                if(string.IsNullOrEmpty(data.Key))
                {
                    return false;
                }
                return true;
            }

        }


        //public async Task<List<contactClass>> validate(string uname , string pass)
        //{


        //    return (await firebaseClient.Child("user info").Child(uname).Child("password").ClientEquals(pass));
        //    {
        //        validatepass =item.Object.password
                
        //    }).ToList();
        //}





        public async Task<List<contactClass>>getAll()
        {
           
            
            return (await firebaseClient.Child("user info").Child(nameof(contactClass.userID)).OnceAsync<contactClass>()).Select(item => new contactClass
            {
                userID = item.Object.userID,
                number= item.Object.number,
                thelink = item.Object.thelink,
                username= item.Object.username,

            }).ToList();
        }


        public async Task<List<contactClass>> getuserDetails()
        {


            return (await firebaseClient.Child("user info").Child(nameof(contactClass.userID)).OnceAsync<contactClass>()).Select(item => new contactClass
            {
                userID = item.Object.userID

            }).ToList();
        }

    }
}
