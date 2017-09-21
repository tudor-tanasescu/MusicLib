using NHibernate;

namespace MusicLibrary.Dal.Interfaces
{
    public interface IUnitOfWork
    {
        ISession Session { get; }

        void BeginTransaction();
        void Commit();
        void Rollback();
    }
}