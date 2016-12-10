using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FitYourFood
{
    public class JsonParser
    {
        public object parseLocal(string file)
        {
            var assembly = typeof(Model.RecipeDetail.RecipeInformation).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream("FitYourFood.Assets.recipe_Detail.txt");
            string text = "";
            using (var reader = new System.IO.StreamReader(stream))
            {
                text = reader.ReadToEnd();
            }
            return JsonConvert.DeserializeObject(text);
        }

        public async Task<object> parseOnline(string url)
        {
            string contents;
            string Url = String.Format("http://api.getwox.com/plugin/106/");
            HttpClient hc = new HttpClient();
            contents = await hc.GetStringAsync(Url);

            return JsonConvert.DeserializeObject(contents);
        }
    }
}
