using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FootballManagerBL.DAL
{
    internal static class ConfigurationManager
    {
        static ConfigurationManager()
        {
        }

        private const string _connection = "Server=(localdb)\\mssqllocaldb;Database=FootballManagerDB;Trusted_Connection=True;";

        public static DbContextOptions<EFContext> GetConnectionOptions(Action<DbContextOptionsBuilder> optionsAction = null)
        {
            var optionBuilder = new DbContextOptionsBuilder<EFContext>();

            if (optionsAction == null)
            {
                optionsAction = options => options.UseSqlServer(_connection);
            }

            optionsAction(optionBuilder);

            return optionBuilder.Options;
        }

    }
}
