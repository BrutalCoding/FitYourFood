using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Reflection;

namespace FitYourFood
{
    public class StartScreen : ContentPage
    {
        

        public StartScreen()
        {
            var layout = new StackLayout();
            layout.HorizontalOptions = LayoutOptions.FillAndExpand;

            var layout_veganButton = new StackLayout();
            layout_veganButton.Orientation = StackOrientation.Horizontal;

            var labelVegan = new Label
            {
                Text = "Vegan",
                Font = Font.BoldSystemFontOfSize(20),
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.Start
            };
            var checkBoxVegan = new Switch
            {
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };
            bool isVegan = checkBoxVegan.IsToggled;

            List<string> fruit = new List<string>
            {
                "apple", "Bananana", "Pineapple", "pen", "fles", "tas", "laptop", "pc", "Friet", "Burger",
                "Beker"
            };

            var labelLstview = new Label
            {
                Text = "Select recipe ingredients",
                Font = Font.BoldSystemFontOfSize(10),
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.Start
            };

            ListView lstView = new ListView {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                HeightRequest = 160
            };
            lstView.ItemsSource = fruit;
            lstView.RowHeight = 30;

            //Stacklayout
            layout_veganButton.Padding = 15;
            layout_veganButton.Children.Add(labelVegan);
            layout_veganButton.Children.Add(checkBoxVegan);
            layout.Children.Add(layout_veganButton);
            layout.Children.Add(labelLstview);
            layout.Children.Add(lstView);


            
            Content = layout;
        }
    }
}