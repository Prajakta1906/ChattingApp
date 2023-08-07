using chataApp.Models;
using SQLite;
using Xamarin.Essentials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using Firebase.Storage;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System.Diagnostics;
using LiteDB;

namespace chataApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class signupPage : ContentPage
    {
        MediaFile file;
        globalDetail gd = new globalDetail();

        

        public signupPage()
        {
            InitializeComponent();

        }

        private void Back_button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
            
        }

        private async void SignUpDone_button_Clicked(object sender, EventArgs e)
        {
            string url = await StoreImages(file.GetStream());

            //SQLiteConnection con = new SQLiteConnection(App.LocalDatabase);
            //con.CreateTable<contactClass>();
            //contactClass cc = new contactClass()
            //{
            //    userID = Username_entry.Text,
            //    username = Name_entry.Text,
            //    password = Password_entry.Text,
            //    number = Mobile_entry.Text,
            //    thelink = url.ToString()              
            //};
            //var data = con.Insert(cc);
            //con.Close();

            contactClass ccc = new contactClass();
            ccc.userID = Username_entry.Text;
            ccc.username = Name_entry.Text;
            ccc.password = Password_entry.Text;
            ccc.number = Mobile_entry.Text;
            ccc.thelink = url.ToString();  
            
            var isSaved = await gd.Save(ccc);

            if(isSaved)
            {
                await DisplayAlert("Noice", "User Added Successfully <3","OK");
            }
            else
            {
                await DisplayAlert("Oops", "User can't be Added !!", "OK");
            }

            contactClass cc = new contactClass();

        }


        public async Task<string> StoreImages(Stream imageStream)
        {
            var stroageImage = await new FirebaseStorage("chatsapp-15e29.appspot.com")
               
                .Child("images")
                .Child(Username_entry.Text+".png")
                .PutAsync(imageStream);
            string imgurl = stroageImage;
            return imgurl;



           
           


        }
       

        async void pickerbtn_Clicked(object sender, EventArgs e)
        {

            await CrossMedia.Current.Initialize();
            try
            {
                file = await Plugin.Media.CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
                {
                    PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium
                });
                if (file == null)
                    return;
                pickerbtn.Source = ImageSource.FromStream(() =>
                {
                    var imageStram = file.GetStream();
                    return imageStram;
                });
                await StoreImages(file.GetStream());
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

    }
}