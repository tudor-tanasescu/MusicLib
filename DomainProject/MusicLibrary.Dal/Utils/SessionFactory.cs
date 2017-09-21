
#define SHOW_SQL

using System;
using System.Configuration;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using MusicLibrary.Dal.Conventions;
using MusicLibrary.Domain.Entities;
using NHibernate;

namespace MusicLibrary.Dal.Utils
{
    public static class SessionFactory
    {
        private static readonly Lazy<ISessionFactory> Lazy = new Lazy<ISessionFactory>(CreateSessionFactory);
        public static ISessionFactory Instance => Lazy.Value;

        private static ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
                .Database(MsSqlConfiguration
                    .MsSql2012
#if SHOW_SQL
                    .ShowSql().FormatSql()
#endif
                    .ConnectionString(
                        ConfigurationManager.ConnectionStrings["Database"].ConnectionString
                    )
                )
                .Mappings(m => m.FluentMappings
                    .AddFromAssemblyOf<Entity>()
                    .Conventions.AddFromAssemblyOf<DateTimeConvention>())
                .BuildSessionFactory();
        }
    }
}