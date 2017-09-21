using MusicLibrary.Domain.DTO;
using MusicLibrary.Domain.Entities;

namespace MusicLibrary.Factories.Interfaces
{
    public interface ITrackFactory
    {
        Track Produce(UploadTrackDto trackDto);
    }
}
