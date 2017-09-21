using MusicLibrary.Dal.Interfaces;
using MusicLibrary.Domain.Entities;
using NHibernate;

namespace MusicLibrary.Dal.Repositories
{
    public class UserRepository : Repository, IUserRepository
    {
        public UserRepository(ISession session) : base(session)
        {
        }

        public User GetByName(string username)
        {
            return Session.QueryOver<User>()
                .Where(u => u.UserName == username)
                .SingleOrDefault();
        }
    }
}