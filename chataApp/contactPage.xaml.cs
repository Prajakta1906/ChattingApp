using chataApp.Models;
using Firebase.Database;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace chataApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class contactPage : ContentPage
    {
        // FirebaseClient firebaseClient = new FirebaseClient("https://chatsapp-15e29-default-rtdb.asia-southeast1.firebasedatabase.app/");

        globalDetail gd = new globalDetail();

        public contactPage()
        {
            InitializeComponent();
            myconlist.RefreshCommand = new Command(() =>
            {
                myconlist.IsRefreshing = true;
                myconlist.IsRefreshing = false;

            });


        }


        protected override async void OnAppearing()
        {
            var myy = await gd.getAll();
            myconlist.ItemsSource = myy ;
          
            
        }

        //public void getAll()

        //{
        //    SQLiteConnection con = new SQLiteConnection(App.LocalDatabase);
        //    con.CreateTable<contactClass>();
        //    contactClass cc = new contactClass();
        //    var mydata = con.Query<contactClass>("delete FROM contactClass");

        //    myconlist.ItemsSource = mydata;

        //    con.Close();
          
        //}

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new addconPage());
        }


        async void myconlist_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var temp = await DisplayActionSheet("SELECT", "Cancle", "", "ADD FRIEND", "VIEW PROFILE");


            var selected = (contactClass)e.SelectedItem;

            if (temp == "ADD FRIEND")
            {
                //myFriends mff = new myFriends();

                //SQLiteConnection com = new SQLiteConnection(App.LocalDatabase);

               // var list2 = com.Query<myFriends>("SELECT mynumber FROM myFriends");
               // if (selected.number != list2[0])
                //{
                    SQLiteConnection con = new SQLiteConnection(App.LocalDatabase);
                    con.CreateTable<myFriends>();
                    contactClass cc = new contactClass();

                    myFriends mf = new myFriends()
                    {

                        myusername = selected.username,
                        mynumber = selected.number,
                        ID = selected.userID,
                        myphotolink = selected.thelink
                        

                    };
                    var data = con.Insert(mf);
                    con.Close();
                //}
                //else
                //{
                //    DisplayAlert("HAHAHA", $"you added {mff.ID} already !", "OK");
                //}

            }

            else if (temp == "VIEW PROFILE")
            {
                await DisplayAlert($"H! its , {selected.username}", selected.number, "ok");
            }
        }




        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            SQLiteConnection con = new SQLiteConnection(App.LocalDatabase);
            myconlist.ItemsSource = con.Table<contactClass>().Where(x => x.userID.StartsWith(e.NewTextValue));

        }
    }
}