using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Ticketing_Helpers
{
    public class Config
    {
        private static IConfigurationRoot config = new ConfigurationBuilder()
                                   .SetBasePath(Directory.GetCurrentDirectory())
                                   .AddJsonFile("appSettings.json")
                                   .Build();
        public static string GetConnectionString(string connStringName)
        {
            return config.GetConnectionString(connStringName);
        }

        public static IConfigurationSection GetSection(string sectionName)
        {
            return config.GetSection(sectionName);
        }
        //string cs = config.GetConnectionString("TicketDb");

    }
}
