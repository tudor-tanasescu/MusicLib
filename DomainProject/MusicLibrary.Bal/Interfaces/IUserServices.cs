using MusicLibrary.Domain.DTO;
using MusicLibrary.Domain.Entities;

namespace MusicLibrary.Bal.Interfaces
{
    public interface IUserServices
    {
        void Create(User user);
        void Update(User user);
        void Delete(User user);
        User GetByUserName(string username);
        User GetById(int id);
        User Create(UserRegisterDto dto);
    }
}