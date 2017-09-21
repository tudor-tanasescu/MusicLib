using MusicLibrary.Dal.Interfaces;
using MusicLibrary.Dal.Utils;
using NHibernate;

namespace MusicLibrary.Dal.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private ITransaction _transaction;

        public ISession Session { get; }
        
        public UnitOfWork()
        {
            Session = SessionFactory.Instance.OpenSession();
        }

        public void BeginTransaction()
        {
            _transaction = Session.BeginTransaction();
        }

        public void Commit()
        {
            try
            {
                if (_transaction != null && _transaction.IsActive)
                    _transaction.Commit();
            }
            catch
            {
                if (_transaction != null && _transaction.IsActive)
                    _transaction.Rollback();

                throw;
            }
            finally
            {
                Session.Dispose();
            }
        }

        public void Rollback()
        {
            try
            {
                if (_transaction != null && _transaction.IsActive)
                    _transaction.Rollback();
            }
            finally
            {
                Session.Dispose();
            }
        }
    }
}
