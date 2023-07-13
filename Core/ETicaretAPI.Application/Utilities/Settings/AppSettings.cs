using Newtonsoft.Json;
using OnionArchitecture.Application.Utilities.Settings;

namespace Core.Application.Utilities.Settings
{
    public class AppSettings
    {
        private const string JsonFilePath = "..\\Core\\Application\\Utilities\\Settings\\settings.json";

        private AppSettings()
        {

        }
        static AppSettings()
        {
            ReloadSettings();
        }

        //Settings.json faylındakı obyektlərin qarşılığı =>
        public DbConnectionModel AppDbConnectionModel { get; set; }
        public JwtConfiguration JwtConfiguration { get; set; }
        public MailConfiguration MailConfiguration { get; set; }



        public static AppSettings Settings { get; private set; }


        public static void ReloadSettings()
        {
            JsonSerializer serializer = new JsonSerializer();

          
            using (StreamReader sr = new StreamReader(JsonFilePath))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                while (reader.Read())
                {
                    if (reader.TokenType == JsonToken.StartObject)
                    {
                        Settings = serializer.Deserialize<AppSettings>(reader);
                    }
                }
            }
        }




    }
}
