using MusicLibrary.Bal.Interfaces;
using MusicLibrary.Dal.Interfaces;
using MusicLibrary.Domain.DTO;
using MusicLibrary.Domain.Entities;
using MusicLibrary.Factories.Interfaces;

namespace MusicLibrary.Bal.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _userRepo;
        private readonly IUserFactory _userFactory;

        public UserServices(IUserRepository userRepo, IUserFactory userFactory)
        {
            _userRepo = userRepo;
            _userFactory = userFactory;
        }


        public void Create(User user)
        {
            _userRepo.Create(user);
        }

        public void Delete(User user)
        {
            _userRepo.Delete(user);
        }

        public User GetById(int id)
        {
            return _userRepo.GetById<User>(id);
        }

        public User Create(UserRegisterDto dto)
        {
            return _userFactory.CreateUser(dto);
        }

        public User GetByUserName(string username)
        {
            return _userRepo.GetByName(username);
        }

        public void Update(User user)
        {
            _userRepo.Update(user);
        }
    }
}