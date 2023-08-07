using chataApp.Models;
using Firebase.Database;
using SQLite;
using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Firebase.Database.Query;
using System.Drawing;
using Firebase.Auth;

namespace chataApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class conversationPage : ContentPage
    {
        public ObservableCollection<chatClass> DatabaseItems { get; set; } = new
            ObservableCollection<chatClass>();
        public object MyLabel { get; private set; }

       // public object userinfo { get; private set; }
        public object UILineBreakMode { get; private set; }

        FirebaseClient firebaseClient = new FirebaseClient("https://chatsapp-15e29-default-rtdb.asia-southeast1.firebasedatabase.app/");

        public conversationPage()
        {
            InitializeComponent();
            getinfo();
            BindingContext = this;
            
            


            var collection = firebaseClient
                .Child("Records")
                .AsObservable<chatClass>()
                .Subscribe((dbevent) =>
                {
                    if(dbevent.Object != null)
                    {
                        DatabaseItems.Add(dbevent.Object);
                    }

                });
            

            //var collectin = firebaseClient
            //    .Child("photo")
            //    .AsObservable<chatClass>()
            //    .Subscribe((dbevent) =>
            //    {
            //        DatabaseItems.Add(dbevent.Object);
            //    });
            
        }

        public void getinfo()
        {
           
            SQLiteConnection con = new SQLiteConnection(App.LocalDatabase);
            con.CreateTable<myFriends>();
         
            myFriends mf = new myFriends();
            
            con.Close();
        }

        myFriends ccc = new myFriends();
        

        void Button_Clicked(object sender, EventArgs e)
        {
            if(recordData.Text != string.Empty)
            {
                firebaseClient.Child("Records").PostAsync(new chatClass
                {
                    MyProperty = recordData.Text 
                    

                });

                recordData.Text = "";

                //firebaseClient.Child("photo").PostAsync(new chatClass
                //{

                //    Myimg = ccc.myphotolink

                //});



            }   
            
            
           
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {

            firebaseClient.Child("posts").OrderBy("ActivityID").EqualTo(ActivityID).DeleteAsync();
            
        }

        private string ActivityID()
        {
            throw new NotImplementedException();
        }
    }
}