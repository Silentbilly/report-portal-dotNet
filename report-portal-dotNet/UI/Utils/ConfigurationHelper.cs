using System.Configuration;


namespace report_portal_dotNet.UI.Utils
{
    public static class ConfigurationHelper
    {
        public static T Get<T>(string name)
        {
            /*            ExeConfigurationFileMap configFileMap = new ExeConfigurationFileMap { ExeConfigFilename = "C:\\Learn\\NetProj\\report-portal-dotNet\\report-portal-dotNet\\App.config" };
                        Configuration config = ConfigurationManager.OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.None);*/
            ConfigurationFileMap configMap = new ConfigurationFileMap("./app.config");
            Configuration configuration = ConfigurationManager.OpenMappedMachineConfiguration(configMap);
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var configFilePath = config.FilePath;

            Console.WriteLine("Configuration file path: " + configFilePath);


            var value = ConfigurationManager.AppSettings[name];
            Guard.IsNotNull<InvalidOperationException>(value, "AppSetting with name {0} not found. Please check the application configuration file.", name);
            if (typeof(T).IsEnum)
                return (T)Enum.Parse(typeof(T), value);
            return (T)Convert.ChangeType(value, typeof(T));
        }
        public static string GetConnectionString(string name)
        {
            var value = ConfigurationManager.ConnectionStrings[name];
            Guard.IsNotNull<InvalidOperationException>(value, "ConnectionString with name {0} not found. Please check the application configuration file.", name);
            return value.ConnectionString;
        }
    }
}
