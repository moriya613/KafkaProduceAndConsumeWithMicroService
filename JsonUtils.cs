using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Consumer
{
    public class JsonUtils
    {
        public static List<string> GetListOfMessagesFromFile()
        {
            List<string> Messages = new List<string>();
            //  read JSON directly from a file
            using (StreamReader file = File.OpenText(@"Resources\event_messages.json"))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                while (reader.Read())
                {
                    if (reader.TokenType == JsonToken.StartObject)
                    {
                        JObject jObject = JObject.Load(reader);
                        Messages.Add(jObject.ToString());
                    }
                }
            }

            return Messages;

        }



    }
}
