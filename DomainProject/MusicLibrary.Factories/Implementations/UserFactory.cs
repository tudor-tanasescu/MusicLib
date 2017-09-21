using System;
using MusicLibrary.Domain.DTO;
using MusicLibrary.Domain.Entities;
using MusicLibrary.Factories.Interfaces;

namespace MusicLibrary.Factories.Implementations
{
    public class UserFactory : IUserFactory
    {
        public User CreateUser(UserRegisterDto dto)
        {
            if (string.IsNullOrEmpty(dto.Alias)) throw new ArgumentException(nameof(dto.Alias));
            if (string.IsNullOrEmpty(dto.UserName)) throw new ArgumentException(nameof(dto.UserName));
            if (string.IsNullOrEmpty(dto.Email)) throw new ArgumentException(nameof(dto.Email));

            return new User
            {
                Alias = dto.Alias,
                UserName = dto.UserName,
                Email = dto.Email,
                RecievesEmailNotifications = dto.RecievesEmailNotifications
            };
        }
    }
}
