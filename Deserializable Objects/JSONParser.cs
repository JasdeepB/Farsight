using Farsight.Deserializable_Objects.Perks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;

namespace Farsight
{
    class JSONParser
    {
        public static string APIKEY = "RGAPI-ca6f062a-8c94-48f4-8740-0461b60a918f";

        static string workingDirectory = Environment.CurrentDirectory;
        static string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;

        public JSONParser()
        {

        }

        public static string ChampionsFull()
        {
            string jsonString = "";

            using (StreamReader file = File.OpenText(projectDirectory + @"\Farsight\Data\championFull.json"))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                JObject jsonObject = (JObject)JToken.ReadFrom(reader);
                jsonString = jsonObject.ToString();
            }
            return jsonString;
        }

        public static List<AllRunes> Runes()
        {
            string jsonString = "";
            List<AllRunes> allRunes;

            using (StreamReader file = File.OpenText(projectDirectory + @"\Farsight\Data\runesReforged.json"))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                JArray jsonArray = (JArray)JToken.ReadFrom(reader);
                jsonString = jsonArray.ToString();
            }

            allRunes = JsonConvert.DeserializeObject<List<AllRunes>>(jsonString);

            return allRunes;
        }
    }
}
