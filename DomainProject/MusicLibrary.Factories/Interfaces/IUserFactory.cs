using MusicLibrary.Domain.DTO;
using MusicLibrary.Domain.Entities;

namespace MusicLibrary.Factories.Interfaces
{
    public interface IUserFactory
    {
        User CreateUser(UserRegisterDto dto);
    }
}