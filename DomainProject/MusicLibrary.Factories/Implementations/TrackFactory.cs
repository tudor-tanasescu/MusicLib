using System;
using MusicLibrary.Domain.DTO;
using MusicLibrary.Domain.Entities;
using MusicLibrary.Factories.Interfaces;

namespace MusicLibrary.Factories.Implementations
{
    public class TrackFactory : ITrackFactory
    {
        public Track Produce(UploadTrackDto trackDto)
        {
            if (trackDto == null) throw new ArgumentNullException(nameof(trackDto));

            if (string.IsNullOrEmpty(trackDto.Title)) throw new ArgumentException(nameof(trackDto.Title));
            
            return  new Track
            {
                Title = trackDto.Title,
                Description = trackDto.Description,
                Artwork = trackDto.Artwork,
                YearReleased = trackDto.YearReleased
            };
        }
    }
}
