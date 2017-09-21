namespace MusicLibrary.Domain.Entities
{
    public class Genre : Entity
    {
        public virtual string Name { get; set; }
        
        public Genre()
        {
        }
    }
}