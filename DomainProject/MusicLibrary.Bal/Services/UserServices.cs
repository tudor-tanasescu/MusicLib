using MusicLibrary.Bal.Interfaces;
using MusicLibrary.Dal.Interfaces;
using MusicLibrary.Domain.DTO;
using MusicLibrary.Domain.Entities;
using MusicLibrary.Factories.Interfaces;

namespace MusicLibrary.Bal.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserFactory _userFactory;

        public UserServices(IUserRepository userRepository, IUserFactory userFactory)
        {
            _userRepository = userRepository;
            _userFactory = userFactory;
        }

        public void Create(User user)
        {
            _userRepository.Create(user);
        }

        public void Delete(User user)
        {
            _userRepository.Delete(user);
        }

        public User GetById(int id)
        {
            return _userRepository.GetById<User>(id);
        }

        public User Create(UserRegisterDto dto)
        {
            return _userFactory.CreateUser(dto);
        }

        public User GetByUserName(string username)
        {
            return _userRepository.GetByName(username);
        }

        public void Update(User user)
        {
            _userRepository.Update(user);
        }
    }
}