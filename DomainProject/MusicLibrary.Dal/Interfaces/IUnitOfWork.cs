using NHibernate;

namespace MusicLibrary.Dal.Interfaces
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        void Commit();
        void Rollback();
        ISession Session { get; }
    }
}