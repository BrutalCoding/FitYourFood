using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using FitYourFood.Model.RecipeDetail;
using Xamarin.Forms;

namespace FitYourFood
{
    public class StartScreen : ContentPage
    {
        Switch checkBoxVegan;
        Picker picker;
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
            checkBoxVegan = new Switch
            {
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };

            ObservableCollection<string> selectedIngredients = new ObservableCollection<string>();

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

            picker = new Picker
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

            lstView.ItemsSource = selectedIngredients;
            lstView.RowHeight = 45;

            //Stacklayout
            FillPicker();
            layout_veganButton.Padding = 15;
            layout_veganButton.Children.Add(labelVegan);
            layout_veganButton.Children.Add(checkBoxVegan);
            layout.Children.Add(layout_veganButton);
            layout.Children.Add(picker);
            layout.Children.Add(labelLstview);
            layout.Children.Add(lstView);
            layout.Children.Add(searchBtn);
            
            checkBoxVegan.Toggled += (sender, args) =>
            {
                FillPicker();
            };

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
                Navigation.PushAsync(new RecipeScreen(selectedIngredients));
            };

            Content = layout;
        }
        public void FillPicker()
        {
            picker.Items.Clear();
            JsonParser parser = new JsonParser();
            if (checkBoxVegan.IsToggled)
            {
                var x = parser.parseLocal("FitYourFood.Assets.recipe_Detail.json");
                //foreach (var x in parser.parseLocal("FitYourFood.Assets.recipe_Detail.json"))
                //{
                //    if (x.vegetarian)
                //    {
                //        picker.Items.Add(x.vegetarian.ToString());
                //    }
                //}

                //picker.Items.Add("King prawns");
                //picker.Items.Add("Plain yogurt");
                //picker.Items.Add("Garlic");
                //picker.Items.Add("Ginger");
                //picker.Items.Add("Cumin powder");
                //picker.Items.Add("Paprika powder");
                //picker.Items.Add("Coriander powder");
                //picker.Items.Add("Tandoori colour powder");
            }
            else
            {
                var x = parser.parseLocal("FitYourFood.Assets.recipe_Detail.json");
                //foreach (var x in parser.parseLocal("FitYourFood.Assets.recipe_Detail.json"))
                //{
                //    if (!x.vegetarian)
                //    {
                //        picker.Items.Add(x.vegetarian.ToString());
                //    }
                //}
                //picker.Items.Add("Chicken");
                //picker.Items.Add("Paprika powder");
                //picker.Items.Add("Coriander powder");
                //picker.Items.Add("Cow");
                //picker.Items.Add("Plain yogurt");
                //picker.Items.Add("Cheese");
                //picker.Items.Add("Egg");
                //picker.Items.Add("Bread");
                //picker.Items.Add("King prawns");
                //picker.Items.Add("Garlic");
                //picker.Items.Add("Ginger");
                //picker.Items.Add("Pig");
                //picker.Items.Add("Frog");
                //picker.Items.Add("Cumin powder");
                //picker.Items.Add("Tandoori colour powder");
            }
        }
    }
}