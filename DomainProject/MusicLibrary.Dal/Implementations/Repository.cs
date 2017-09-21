using System.Collections.Generic;
using System.Configuration;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using MusicLibrary.Dal.Conventions;
using MusicLibrary.Dal.Interfaces;
using MusicLibrary.Domain.Entities;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using Configuration = NHibernate.Cfg.Configuration;

namespace MusicLibrary.Dal.Implementations
{
    public class Repository : IRepository//, IDisposable
    {
        protected ISession Session => _unitOfWork.Session;

        public readonly IUnitOfWork _unitOfWork;

        public Repository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public T Load<T>(int id) where T : Entity
        {
            return Session.Load<T>(id);
        }

        public T GetById<T>(int id) where T : Entity
        {
            return Session.Get<T>(id);
        }

        public void Update<T>(T entity) where T : Entity
        {
            using (var transaction = Session.BeginTransaction())
            {
                Session.SaveOrUpdate(entity);
                transaction.Commit();
            }
        }

        public IList<T> GetAll<T>() where T : Entity
        {
            return Session.QueryOver<T>().List<T>();
        }

        public void Create<T>(T entity) where T : Entity
        {
            using (var transaction = Session.BeginTransaction())
            {
                Session.SaveOrUpdate(entity);
                transaction.Commit();
            }
        }

        public void Delete<T>(T obj) where T : Entity
        {
            using (var transaction = Session.BeginTransaction())
            {
                Session.Delete(obj);
                transaction.Commit();
            }
        }
        
        public static void ResetDb()
        {
            Fluently.Configure()
                .Database(MsSqlConfiguration
                    .MsSql2012
                    .ConnectionString(ConfigurationManager.ConnectionStrings["Database"].ConnectionString))
                .Mappings(m => m.FluentMappings
                    .AddFromAssemblyOf<Entity>()
                    .Conventions.AddFromAssemblyOf<DateTimeConvention>())
                .ExposeConfiguration(GenerateSchema)
                .BuildConfiguration();

            void GenerateSchema(Configuration cfg)
            {
                var schemaExport = new SchemaExport(cfg);
                schemaExport.Drop(false, true);
                schemaExport.Create(false, true);
            }
        }

        //public void Dispose()
        //{
        //    if (Session?.IsOpen == true)
        //    {
        //        Session.Flush();
        //        Session.Close();
        //        Session.Dispose();
        //    }
        //}
    }
}