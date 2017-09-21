using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using MusicLibrary.Bal.Interfaces;
using MusicLibrary.Domain.Entities;

namespace MusicLibrary.Web.Models.Identity
{
    public class UserStore : IUserPasswordStore<User, int>, IUserLockoutStore<User, int>,
        IUserTwoFactorStore<User, int>
    {
        private readonly IUserServices _userServices;

        public UserStore(IUserServices userServices)
        {
            _userServices = userServices;
        }
        

        #region IUserStore

        public Task CreateAsync(User user)
        {
            return Task.Run(() => _userServices.Create(user));
        }

        public Task DeleteAsync(User user)
        {
            return Task.Run(() => _userServices.Delete(user));
        }

        public Task<User> FindByIdAsync(int userId)
        {
            return Task.Run(() => _userServices.GetById(userId));
        }

        public Task<User> FindByNameAsync(string userName)
        {
            return Task.Run(() => _userServices.GetByUserName(userName));
        }

        public Task UpdateAsync(User user)
        {
            return Task.Run(() => _userServices.Update(user));
        }

        #endregion

        #region IUserPasswordStore

        public Task SetPasswordHashAsync(User user, string passwordHash)
        {
            return Task.Run(() => user.PasswordHash = passwordHash);
        }

        public Task<string> GetPasswordHashAsync(User user)
        {
            return Task.FromResult(user.PasswordHash);
        }

        public Task<bool> HasPasswordAsync(User user)
        {
            return Task.FromResult(true);
        }

        #endregion

        #region IUserLockoutStore Stubbed

        public Task<DateTimeOffset> GetLockoutEndDateAsync(User user)
        {
            return Task.FromResult(DateTimeOffset.MaxValue);
        }

        public Task SetLockoutEndDateAsync(User user, DateTimeOffset lockoutEnd)
        {
            return Task.Run(() => { });
        }

        public Task<int> IncrementAccessFailedCountAsync(User user)
        {
            return Task.FromResult(0);
        }

        public Task ResetAccessFailedCountAsync(User user)
        {
            return Task.Run(() => { });
        }

        public Task<int> GetAccessFailedCountAsync(User user)
        {
            return Task.FromResult(0);
        }

        public Task<bool> GetLockoutEnabledAsync(User user)
        {
            return Task.FromResult(false);
        }

        public Task SetLockoutEnabledAsync(User user, bool enabled)
        {
            return Task.Run(() => { });
        }

        #endregion

        #region IUserTwoFactorStore

        public Task SetTwoFactorEnabledAsync(User user, bool enabled)
        {
            return Task.Run(() => { });
        }

        public Task<bool> GetTwoFactorEnabledAsync(User user)
        {
            return Task.FromResult(false);
        }

        #endregion

        public void Dispose()
        {

        }
    }
}