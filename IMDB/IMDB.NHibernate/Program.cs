using Microsoft.Extensions.Configuration;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Support;
using System;
using System.IO;

namespace IMDB.NHibernate
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
              .AddJsonFile("appsettings.json", true, true)
              .Build();

            var hibernateConfiguration = new Configuration()
                .SetupConnection(configuration.GetConnectionString("ContosoUniversity"), new MsSql2012Dialect())
                .AddClassMappingAssemblies(typeof(AssemblyLocator).Assembly);

            string schemaPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, configuration["outputPath"]);

            SchemaExporter.ExportSchema(hibernateConfiguration, new FileInfo(schemaPath));
        }
    }
}
