using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace FitYourFood
{
    public class App : Application
    {
        public App()
        {
            MainPage = new StartScreen();
            // The root page of your application
            //MainPage = new ContentPage
            //{
            //    Content = new StackLayout
            //    {
            //        VerticalOptions = LayoutOptions.Center,
            //        Children = {
            //            new Label {
            //                HorizontalTextAlignment = TextAlignment.Center,
            //                Text = "Welcome to Xamarin Forms!"

            //            },
            //            new Button
            //            {
            //                Text = "Click Me!",
            //                Font = Font.SystemFontOfSize(NamedSize.Large),
            //                BorderWidth = 1,
            //                HorizontalOptions = LayoutOptions.Center,
            //                VerticalOptions = LayoutOptions.End
            //            }
            //        }
            //    }
            //};
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
