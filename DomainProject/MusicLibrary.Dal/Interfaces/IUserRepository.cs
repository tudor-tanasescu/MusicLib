using MusicLibrary.Domain.Entities;

namespace MusicLibrary.Dal.Interfaces
{
    public interface IUserRepository: IRepository
    {
        User GetByName(string username);
    }
}