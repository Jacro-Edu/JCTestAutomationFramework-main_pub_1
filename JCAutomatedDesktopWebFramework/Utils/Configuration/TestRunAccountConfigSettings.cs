using Newtonsoft.Json;

namespace JCAutomatedDesktopWebFramework.Utils.Configuration
{
    public class TestRunAccountConfigSettings
    {
        private static string AccountConfigFilePath => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, 
            "..\\..\\..",
            "Utils", 
            "Configuration",
            "AccountConfigSettings.json");

        public string? Username { get; }
        public string? Password { get; }
        public string? InvUsername { get; }
        public string? InvPassword { get; }

        private class AccountConfigSettings
        {
            public string? Username { get; set; }
            public string? Password { get; set; }
            public string? InvUsername { get; set; }
            public string? InvPassword { get; set; }
        }
        public TestRunAccountConfigSettings() 
        {
            Console.WriteLine($"Current Directory: {Directory.GetCurrentDirectory}");
            Console.WriteLine($"ConfigFilePath: {AccountConfigFilePath}");
            if (File.Exists(AccountConfigFilePath))
            {
                string jsonContent = File.ReadAllText(AccountConfigFilePath);
                AccountConfigSettings AccountConfigData = JsonConvert.DeserializeObject<AccountConfigSettings>(jsonContent);
                Username = AccountConfigData.Username;
                Password = AccountConfigData.Password;
                InvUsername = AccountConfigData.InvUsername;
                InvPassword = AccountConfigData.InvPassword;
            }
            else
            {
                // If the config file is not found, throw new exception
                throw new FileNotFoundException("'TestRunAccountConfigSettings.json' file not found.");
            }
        }
    }
}