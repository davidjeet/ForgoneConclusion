namespace Web.Api.Infrastructure.Configuration
{
    using System.Configuration;

    public interface ISettings
    {
        string ConnectionString { get; }
        string DatabaseName { get; }

        // add more settings here later if desired
    }


    public class Settings : ISettings
    {
        private Settings()
        {

        }

        public static ISettings Current
        {
            get
            {
                return new Settings();
            }
        }

        public string ConnectionString
        {
            get { return ConfigurationManager.AppSettings.Get("MongoDBConnectionString"); }
        }

        public string DatabaseName
        {
            get { return ConfigurationManager.AppSettings.Get("MongoDBName"); }
        }
    }
}