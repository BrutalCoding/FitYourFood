using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitYourFood.Model.RecipeList
{
    public class RecipeInformation
    {
        public string recipeTitle { get; set; }
        public string recipeId { get; set; }
        public string lastUpdatedTime { get; set; }
    }

    public class RootObject
    {
        public string serverTime { get; set; }
        public List<RecipeInformation> recipeInformation { get; set; }
        public string message { get; set; }
    }

}
