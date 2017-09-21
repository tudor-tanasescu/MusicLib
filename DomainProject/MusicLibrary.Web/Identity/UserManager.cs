using Microsoft.AspNet.Identity;
using MusicLibrary.Domain.Entities;

namespace MusicLibrary.Web.Models.Identity
{
    public class UserManager : UserManager<User, int>
    {
        public UserManager(IUserStore<User, int> store) : base(store)
        {
            UserValidator = new UserValidator<User, int>(this);
            PasswordValidator = new PasswordValidator();
        }
    }
}