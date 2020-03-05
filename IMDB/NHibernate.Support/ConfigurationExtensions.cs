using NHibernate.Mapping.ByCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NHibernateConfiguration = global::NHibernate.Cfg.Configuration;
using NHibernateDialect = global::NHibernate.Dialect.Dialect;
using NHibernateEnvironment = NHibernate.Cfg.Environment;
using SystemType = System.Type;

namespace NHibernate.Support
{
    public static class ConfigurationExtensions
    {
        public static NHibernateConfiguration SetupConnection(this NHibernateConfiguration configuration, string connectionString, NHibernateDialect dialect)
        {
            configuration.SetProperty(NHibernateEnvironment.ConnectionString, connectionString);

            if (string.IsNullOrEmpty(configuration.GetProperty(NHibernateEnvironment.ConnectionProvider)))
            {
                configuration.SetProperty(NHibernateEnvironment.ConnectionProvider, "NHibernate.Connection.DriverConnectionProvider");
            }

            configuration.SetProperty(NHibernateEnvironment.Dialect, dialect.GetType().FullName);

            return configuration;
        }

        public static NHibernateConfiguration AddClassMappingAssemblies(this NHibernateConfiguration configuration, params Assembly[] classMappingAssemblies)
        {
            var classMappingTypes = classMappingAssemblies.SelectMany(a => a.GetTypes().Where(t => typeof(IConformistHoldersProvider).IsAssignableFrom(t))).ToArray();
            return AddClassMappingTypes(configuration, classMappingTypes);
        }

        public static NHibernateConfiguration AddClassMappingTypes(this NHibernateConfiguration configuration, params SystemType[] classMappingTypes)
        {
            var modelMapper = new ModelMapper();
            modelMapper.AddMappings(classMappingTypes.OrderBy(t => t, new TypeHierarchyComparer()));
            configuration.AddMapping(modelMapper.CompileMappingForAllExplicitlyAddedEntities());
            return configuration;
        }

        private class TypeHierarchyComparer : IComparer<SystemType>
        {
            /// <summary>
            /// Compares two objects and returns a value indicating whether one is less than, equal to, or greater than the other.
            /// </summary>
            /// <param Name="x">The first object to compare.</param>
            /// <param Name="y">The second object to compare.</param>
            /// <returns>A signed integer that indicates the relative values of x and y, as shown in the following table.
            /// Less than zero: x is less than y.
            ///	Zero: x equals y.
            ///	Greater than zero: x is greater than y.</returns>
            public int Compare(SystemType x, SystemType y)
            {
                if (x == null)
                {
                    throw new ArgumentNullException("x");
                }

                if (y == null)
                {
                    throw new ArgumentNullException("y");
                }

                if (x == y)
                {
                    return 0;
                }

                if (x.IsAssignableFrom(y))
                {
                    return -1;
                }

                if (y.IsAssignableFrom(x))
                {
                    return 1;
                }

                return 0;
            }
        }
    }
}
