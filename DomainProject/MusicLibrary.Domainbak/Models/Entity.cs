using System;

namespace MusicLibrary.Domain.Models
{
    public class Entity
    {
        public virtual Guid Id { get; }
        public Entity()
        {
            //Id = Guid.NewGuid();
        }
    }
}