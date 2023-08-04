using Microsoft.Extensions.Configuration;
using OnionArchitecture.Application.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Application.Utilities.Settings
{
    public static class AppSettings
    {
        private static IConfiguration _config;
        public static void AppSettingsConfigure(IConfiguration config)
        {
            _config = config ?? throw new ArgumentNullException(nameof(config));
        }
        public static T GetSetting<T> (SettingOptions settingOption)
        {
            string sectionName = Enum.GetName(typeof(SettingOptions), settingOption);

            var section = _config.GetSection(sectionName);

            if (section == null)
            {
                throw new InvalidOperationException($"Configuration section '{sectionName}' not found.");
            }

            var value = section.Get<T>();

            if (value == null)
            {
                throw new InvalidOperationException($"Could not parse configuration section '{sectionName}' to target type '{typeof(T).FullName}'.");
            }

            return value;
        } 
        public static string GetSetting(SettingOptions settingOption, string key) 
        {
           
            string sectionName = Enum.GetName(typeof(SettingOptions), settingOption);

            if (sectionName == null)
            {
                throw new ArgumentException($"Provided setting option '{settingOption}' does not correspond to a known configuration section.");
            }

            var section = _config.GetSection(sectionName);

            if (section == null)
            {
                throw new InvalidOperationException($"Configuration section '{sectionName}' not found.");
            }
            return section[key];
        }
    }
}
