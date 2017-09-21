using System.Collections.Generic;
using MusicLibrary.Domain.Entities;

namespace MusicLibrary.Dal.Interfaces
{
    public interface IRepository
    {
        void Create<T>(T entity) where T : Entity;
        T Load<T>(int id) where T : Entity;
        T GetById<T>(int id) where T : Entity;
        void Update<T>(T entity) where T : Entity;
        IList<T> GetAll<T>() where T : Entity;
        void Delete<T>(T obj) where T : Entity;
    }
}