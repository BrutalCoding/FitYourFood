using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

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
            ObservableCollection<string> selectedIngredients = new ObservableCollection<string>();

            //List<string> selectedIngredients = new List<string>();

            var labelLstview = new Label
            {
                Text = "Excluded ingredients",
                Font = Font.BoldSystemFontOfSize(10),
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.Start
            };

            ListView lstView = new ListView {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                HeightRequest = 310
            };

            Picker picker = new Picker
            {
                Title = "Exclude recipe ingredients",
                VerticalOptions = LayoutOptions.Start
            };

            Button searchBtn = new Button
            {
                Text = "Search for recipes",
                VerticalOptions = LayoutOptions.EndAndExpand,
                HorizontalOptions = LayoutOptions.Center
            };

            picker.Items.Add("Apple");
            picker.Items.Add("Banana");
            picker.Items.Add("pineApple");
            picker.Items.Add("Kiwi");
            picker.Items.Add("Pen");
            picker.Items.Add("Tas");
            picker.Items.Add("Fles");
            picker.Items.Add("PC");
            picker.Items.Add("Computer");

            lstView.ItemsSource = selectedIngredients;
            lstView.RowHeight = 45;
            
            //Stacklayout
            layout_veganButton.Padding = 15;
            layout_veganButton.Children.Add(labelVegan);
            layout_veganButton.Children.Add(checkBoxVegan);
            layout.Children.Add(layout_veganButton);
            layout.Children.Add(picker);
            layout.Children.Add(labelLstview);
            layout.Children.Add(lstView);
            layout.Children.Add(searchBtn);
            
            picker.SelectedIndexChanged += (sender, args) =>
            {
                if (!selectedIngredients.Contains(picker.Items[picker.SelectedIndex]))
                {
                    selectedIngredients.Add(picker.Items[picker.SelectedIndex]);
                } 
            };

            lstView.ItemTapped += (sender, args) =>
            {
                selectedIngredients.Remove(lstView.SelectedItem.ToString());
            };

            searchBtn.Clicked += (sender, args) =>
            {

            };

            Content = layout;
        }
    }
}