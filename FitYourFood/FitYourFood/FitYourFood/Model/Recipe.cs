using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitYourFood.Model.Recipe
{
    public class Step
    {
        public int sequence { get; set; }
        public object stepTitle { get; set; }
        public string stepDescription { get; set; }
        public string stepType { get; set; }
        public object tip { get; set; }
        public object stepImage { get; set; }
    }

    public class Quantity
    {
        public double number { get; set; }
        public object size { get; set; }
        public string amountInUnit { get; set; }
        public string measurementUnit { get; set; }
    }

    public class Ingredient
    {
        public string name { get; set; }
        public Quantity quantity { get; set; }
    }

    public class InformationProperties
    {
    }

    public class TagsDictionary
    {
        public string Centrifugal { get; set; }
        public string Masticating { get; set; }
        public string Blender { get; set; }
        public string Preparation_time { get; set; }
        public object Search_String { get; set; }
    }

    public class FilterDictionary
    {
        public string Taste { get; set; }
        public string Source { get; set; }
        public string Device { get; set; }
        public string Type_of_drink { get; set; }
        public string Allergen { get; set; }
        public object Benefit { get; set; }
        public string Health_Benefit { get; set; }
    }

    public class Nutrition
    {
        public string nutrionEnglishTitle { get; set; }
        public object nutrionTitle { get; set; }
        public string nutrionUnit { get; set; }
        public string gper250ml { get; set; }
        public string gper100ml { get; set; }
        public string dailyPercentageIntake { get; set; }
        public string recommendedIntake { get; set; }
    }

    public class Recipe
    {
        public string sourceType { get; set; }
        public string recipeType { get; set; }
        public string coverImage { get; set; }
        public string mappingId { get; set; }
        public string recipeTitle { get; set; }
        public string englishTitle { get; set; }
        public object recipeDescription { get; set; }
        public object recipeEnglishDescription { get; set; }
        public string language { get; set; }
        public int totalTime { get; set; }
        public object searchString { get; set; }
        public string servings { get; set; }
        public string locked { get; set; }
        public object keywords { get; set; }
        public List<Step> steps { get; set; }
        public List<Ingredient> ingredients { get; set; }
        public List<string> challenges { get; set; }
        public InformationProperties informationProperties { get; set; }
        public TagsDictionary tagsDictionary { get; set; }
        public FilterDictionary filterDictionary { get; set; }
        public List<Nutrition> nutrition { get; set; }
    }

    public class RootObject
    {
        public List<Recipe> recipes { get; set; }
    }
}
