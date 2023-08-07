using chataApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace chataApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class chatPage : ContentPage
    {
        public chatPage()
        {
            InitializeComponent();
            

            myflist.RefreshCommand = new Command(() =>
            {
                myflist.IsRefreshing = true;
                getfriends();
                myflist.IsRefreshing = false;
            });

        }

        public void getfriends()
        {
            SQLiteConnection con = new SQLiteConnection(App.LocalDatabase);
            con.CreateTable<myFriends>();
            myFriends mf = new myFriends();
           
            var data = con.Query<myFriends>("SELECT DISTINCT(myusername),myphotolink FROM myFriends");
 
            myflist.ItemsSource = data;

            con.Close();
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {

        }



        private void myflist_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selected = (myFriends)e.SelectedItem;
            myFriends mf = new myFriends()
            {
                temp = selected.mynumber
            };

            Navigation.PushAsync(new conversationPage());




        }
    }
}