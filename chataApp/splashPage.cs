using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection.Emit;
using System.Linq;
using Xamarin.Forms;

namespace chataApp
{
    public class splashPage : contactPage
    {
        Image splashImage;

        public splashPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);

            var sub = new AbsoluteLayout();
            splashImage = new Image
            {
                Source = "appicon.png" ,
                WidthRequest = 100,
                HeightRequest = 100,

            };

            AbsoluteLayout.SetLayoutFlags(splashImage, AbsoluteLayoutFlags.PositionProportional);

            AbsoluteLayout.SetLayoutBounds(splashImage , new Rectangle(0.5,0.5,AbsoluteLayout.AutoSize,AbsoluteLayout.AutoSize));

            sub.Children.Add(splashImage);

            this.BackgroundColor = Color.White;
            this.Content= sub;

        }


        protected override async void OnAppearing()
        {
           
            await splashImage.ScaleTo(0.5, 200 );
            await splashImage.ScaleTo(0.5, 200 );
            
            await splashImage.ScaleTo(0.5, 200 );


            await splashImage.ScaleTo(0.2, 100, Easing.BounceIn);
            await splashImage.ScaleTo(1, 400, Easing.BounceOut);


            Application.Current.MainPage = new NavigationPage(new MainPage());


        }


    }

        

    
}
