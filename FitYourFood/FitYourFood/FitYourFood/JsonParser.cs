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
using Newtonsoft.Json.Linq;

namespace FitYourFood
{
    public class JsonParser
    {
        public List<RecipeInformation> parseLocal(string sourceFile)
        {
            //var assembly = typeof(Model.RecipeDetail.RecipeInformation).GetTypeInfo().Assembly;
            //Stream stream = assembly.GetManifestResourceStream(file);
            //string text = "";
            //using (var reader = new System.IO.StreamReader(stream))
            //{
            //    text = reader.ReadToEnd();
            //}
            //RecipeInformation list = JsonConvert.DeserializeObject<RecipeInformation>(text);
            //return list;
            var assembly = typeof(Model.RecipeDetail.RecipeInformation).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream(sourceFile);
            List<RecipeInformation> ro = new List<RecipeInformation>();
            using (StreamReader r = new StreamReader(stream))
            {
                string json = r.ReadToEnd();
                ro = JsonConvert.DeserializeObject<List<RecipeInformation>>(json);
            }

            return ro;
            //JObject o1 = JObject.Parse(File.ReadAllText(sourceFile));

            //// read JSON directly from a file
            //using (StreamReader file = File.OpenText(@"c:\videogames.json"))
            //using (JsonTextReader reader = new JsonTextReader(file))
            //{
            //    JObject o2 = (JObject)JToken.ReadFrom(reader);
            //}
        }

        public async Task<dynamic> parseOnline(string url)
        {
            string contents;
            string Url = String.Format("http://api.getwox.com/plugin/106/");
            HttpClient hc = new HttpClient();
            contents = await hc.GetStringAsync(Url);
            dynamic bla = JsonConvert.DeserializeObject(contents);
            return bla;
        }
    }
}
