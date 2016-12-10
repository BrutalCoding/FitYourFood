using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitYourFood.Model.RecipeDetail
{

    public class RecipeStep
    {
        public object stepTool { get; set; }
        public object stepImage { get; set; }
        public string stepDescription { get; set; }
        public string sequence { get; set; }
        public string recipeType { get; set; }
        public string recipeStepIngredients { get; set; }
        public string recipeStepId { get; set; }
        public int? machineParametersTemperature { get; set; }
        public bool machineParametersStirrer { get; set; }
        public int? machineParametersDuration { get; set; }
        public bool lid { get; set; }
    }

    public class RecipeIngredient
    {
        public string unit { get; set; }
        public string quantity { get; set; }
        public string ingredientName { get; set; }
        public string ingredientId { get; set; }
        public string amountUSCustomary { get; set; }
        public string amountUKImperial { get; set; }
        public string amountMetric { get; set; }
    }

    public class RecipeInformation
    {
        public bool vegetarian { get; set; }
        public string typeOfRecipe { get; set; }
        public int totalTime { get; set; }
        public object toolsImageURL { get; set; }
        public string temperatureUnit { get; set; }
        public string source { get; set; }
        public string shortDescription { get; set; }
        public string servings { get; set; }
        public string season { get; set; }
        public string region { get; set; }
        public string recipeTitle { get; set; }
        public List<object> recipeTipsAndTricks { get; set; }
        public object recipeTags { get; set; }
        public List<RecipeStep> recipeSteps { get; set; }
        public List<RecipeIngredient> recipeIngredients { get; set; }
        public object recipeImageURL { get; set; }
        public string recipeId { get; set; }
        public string recipeDescription { get; set; }
        public List<object> recipeAccessory { get; set; }
        public int preparationTime { get; set; }
        public string mainIngredients { get; set; }
        public bool locked { get; set; }
        public string lastUpdatedTime { get; set; }
        public string language { get; set; }
        public object ingredientImageURL { get; set; }
        public string englishTitle { get; set; }
        public string englishCusine { get; set; }
        public string englishCourse { get; set; }
        public string coverImage { get; set; }
        public string course { get; set; }
        public object countryOfOrigin { get; set; }
        public int cookingTime { get; set; }
        public string cookingMethod { get; set; }
        public object advice { get; set; }
    }

    public class RecipeInformationRootObject
    {
        public string requestId { get; set; }
        public List<RecipeInformation> recipeInformation { get; set; }
        public string message { get; set; }
    }

}
