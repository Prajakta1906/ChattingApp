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
    public partial class addconPage : ContentPage
    {
        public addconPage()
        {
            InitializeComponent();
        }

        private void savebtn_Clicked(object sender, EventArgs e)
        {
            SQLiteConnection con = new SQLiteConnection(App.LocalDatabase);
            con.CreateTable<contactClass>();
            contactClass cc = new contactClass()
            {
                username = name.Text,

                number = num.Text 

            };

            var data = con.Insert(cc);
            if (data > 0)
            {
                con.Close();
                DisplayAlert("Hi Bro", "Your record added successfully", "ok");

            }
            else
            {
                DisplayAlert("sorry Bro", "failed to add record in datdbase", "try again");
            }



          
        }
    }
}