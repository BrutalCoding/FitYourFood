using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FitYourFood
{
    class RecipeScreen : ContentPage
    {
        public RecipeScreen(ObservableCollection<string> listExcludedIngredients)
        {
            ListView lstView = new ListView
            {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                HeightRequest = 500
            };

            List<string> listRecipes = new List<string>() { "Kebab", "Nasi", "Bami", "Noodles",
                                                            "Krab", "Prawns", "test", "test1",
                                                            "test2", "test3", "test4", "test5",
                                                            "test6", "test7"};

            var recipeLabel = new Label()
            {
                Text = "Recipe list",
                Font = Font.BoldSystemFontOfSize(15)
            };

            lstView.ItemsSource = listRecipes;

            var layout = new StackLayout();
            layout.HorizontalOptions = LayoutOptions.FillAndExpand;

            layout.Padding = 15;
            layout.Children.Add(recipeLabel);
            layout.Children.Add(lstView);

            Content = layout;

        }
    }
}
