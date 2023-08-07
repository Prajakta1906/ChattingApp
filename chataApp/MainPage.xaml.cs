using chataApp.Models;
using Firebase.Auth.Repository;
using Firebase.Database;
using Firebase.Database.Query;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace chataApp
{
    public partial class MainPage : ContentPage

    {
        globalDetail _globalDetail = new globalDetail();
        FirebaseClient firebaseClient = new FirebaseClient("https://chatsapp-15e29-default-rtdb.asia-southeast1.firebasedatabase.app/");

        
        public MainPage()
        {
            InitializeComponent();

            bool hasKey = Preferences.ContainsKey("AIzaSyBKzXtJuEjN5cvsgfIVvGq-_84QOBH8H9I");
            if (hasKey)
            {
                string token = Preferences.Get("AIzaSyBKzXtJuEjN5cvsgfIVvGq-_84QOBH8H9I", "");
                if (!string.IsNullOrEmpty(token))
                {
                    Navigation.PushAsync(new homePage());
                }
            }


        }

        private void loginbtn_Clicked(object sender, EventArgs e)
        {
            globalDetail gd = new globalDetail();
            
            
            //var my = gd.validate(User_entry.Text, Pass_entry.Text );
            


            {
                Navigation.PushAsync(new homePage());
            }

        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new signupPage());

        }     
    }

}

