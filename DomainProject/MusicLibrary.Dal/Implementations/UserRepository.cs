using MusicLibrary.Dal.Interfaces;
using MusicLibrary.Domain.Entities;
using NHibernate;

namespace MusicLibrary.Dal.Implementations
{
    public class UserRepository : Repository, IUserRepository
    {
        public UserRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
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