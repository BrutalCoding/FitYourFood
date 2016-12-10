using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using FitYourFood.Model.RecipeDetail;
using Newtonsoft.Json;

namespace FitYourFood
{
    public class JsonParser
    {
        public RecipeInformation parseLocal(string file)
        {
            var assembly = typeof(Model.RecipeDetail.RecipeInformation).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream(file);
            string text = "";
            using (var reader = new System.IO.StreamReader(stream))
            {
                text = reader.ReadToEnd();
            }
            RecipeInformation list = JsonConvert.DeserializeObject<RecipeInformation>(text);
            return list;
        }

        public async Task<dynamic> parseOnline(string url)
        {
            string contents;
            string Url = String.Format("http://api.getwox.com/plugin/106/");
            HttpClient hc = new HttpClient();
            contents = await hc.GetStringAsync(Url);

            return JsonConvert.DeserializeObject(contents);
        }
    }
}
