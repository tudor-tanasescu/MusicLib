using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicLibrary.Dal.Implementations;
using MusicLibrary.Domain.Entities;

namespace MusicLibraryNHTests
{
    [TestClass]
    public class DataGenerationNew
    {
        private Repository _repo;

        [TestMethod]
        public void DataInsert()
        {
            Repository.ResetDb();
            _repo = new Repository(new UnitOfWork());
            _repo._unitOfWork.BeginTransaction();

            var user1 = new User
            {
                UserName = "a.a",
                Alias = "A A",
                Email = "a.a@",
                PasswordHash = @"ALCWeGsuUCwOjdorihLgSCcJuBxSrJajV7WQZgGhVMzg/kcyyotB+aasMAtYwlxX3w==",
                RecievesEmailNotifications = true
            };
            var user2 = new User
            {
                UserName = "b.b",
                Alias = "B B",
                Email = "b.b@",
                PasswordHash = @"ALCWeGsuUCwOjdorihLgSCcJuBxSrJajV7WQZgGhVMzg/kcyyotB+aasMAtYwlxX3w=="
            };
            var user3 = new User
            {
                UserName = "c.c",
                Alias = "C C",
                Email = "c.c@",
                PasswordHash = @"ALCWeGsuUCwOjdorihLgSCcJuBxSrJajV7WQZgGhVMzg/kcyyotB+aasMAtYwlxX3w=="
            };

            var tedUser = new User
            {
                UserName = "ted",
                Alias = "Ted",
                Email = "ted@mail.com",
                PasswordHash = @"ALCWeGsuUCwOjdorihLgSCcJuBxSrJajV7WQZgGhVMzg/kcyyotB+aasMAtYwlxX3w=="
            };

            var user4 = new User
            {
                UserName = "d.d",
                Alias = "D D",
                Email = "d.d@",
                PasswordHash = @"ALCWeGsuUCwOjdorihLgSCcJuBxSrJajV7WQZgGhVMzg/kcyyotB+aasMAtYwlxX3w==",
                RecievesEmailNotifications = true
            };

            _repo.Create(user1);
            _repo.Create(user2);
            _repo.Create(user3);
            _repo.Create(user4);
            _repo.Create(tedUser);
            

            var fl1 = new Follower {DateFollowed = DateTime.UtcNow, FollowingUser = user3, FollowedUser = user1};
            var fl2 = new Follower {DateFollowed = DateTime.UtcNow, FollowingUser = user4, FollowedUser = user1};
            var fl3 = new Follower {DateFollowed = DateTime.UtcNow, FollowingUser = user3, FollowedUser = user2};
            var fl4 = new Follower {DateFollowed = DateTime.UtcNow, FollowingUser = user1, FollowedUser = user3};

            _repo.Create(fl1);
            _repo.Create(fl2);
            _repo.Create(fl3);
            _repo.Create(fl4);
            

            var track1 = new Track
            {
                Title = "Places 0",
                Duration = TimeSpan.FromMinutes(5),
                Uploader = user1,
                UrlId = "places-0",
                Likes = 10,
                Artwork = ""
            };
            var track2 = new Track
            {
                Title = "Sunlight",
                Duration = new TimeSpan(0, 3, 36),
                Uploader = user2,
                UrlId = "sunlight",
                Likes = 500,
                Artwork = ""
            };
            var track3 = new Track
            {
                Title = "Joy and Sadness",
                Duration = new TimeSpan(0, 4, 50),
                Uploader = user3,
                UrlId = "joy-and-sadness",
                Likes = 25,
                Artwork = ""
            };
            var track4 = new Track
            {
                Title = "Relocate",
                Duration = new TimeSpan(0, 6, 28),
                Uploader = user4,
                UrlId = "relocate",
                Likes = 20,
                Artwork = ""
            };

            _repo.Create(track1);
            _repo.Create(track2);
            _repo.Create(track3);
            _repo.Create(track4);
            

            var genre1 = new Genre{Name = "DeepHouse"};
            var genre2 = new Genre{ Name = "Pop" }; 

            var comment1 = new Comment {User = user3, Content = "This Track Rocks!", Track = track1};
            var comment3 = new Comment {User = user2, Content = "Dope beats", Track = track1 };
            var comment2 = new Comment {User = user4, Content = "This Track Sucks!", Track = track2 };

            _repo.Create(comment1);
            _repo.Create(comment2);
            _repo.Create(comment3);

            _repo.Create(genre1);
            _repo.Create(genre2);
            

            track1.Genres.Add(genre1);
            track1.Genres.Add(genre2);
            track2.Genres.Add(genre2);

            _repo.Create(track1);
            _repo.Create(track2);
            

            var pl1 = new Playlist {Name = "My Playlist", Creator = user1, UrlId = "my-playlist"};

            _repo.Create(pl1);


            var playlistsTracks1 = new PlaylistTrack {Playlist = pl1, Track = track1};
            var playlistsTracks2 = new PlaylistTrack {Playlist = pl1, Track = track2};
            var playlistsTracks3 = new PlaylistTrack {Playlist = pl1, Track = track3};
            var playlistsTracks4 = new PlaylistTrack {Playlist = pl1, Track = track4};

            _repo.Create(playlistsTracks1);
            _repo.Create(playlistsTracks2);
            _repo.Create(playlistsTracks3);
            _repo.Create(playlistsTracks4);


            var pl2 = new Playlist {Name = "Bezt Songz", Creator = user2, UrlId = "best-songz"};
            _repo.Create(pl2);
            

            var playlistsTracks12 = new PlaylistTrack {Playlist = pl2, Track = track2};
            var playlistsTracks13 = new PlaylistTrack {Playlist = pl2, Track = track3};

            _repo.Create(playlistsTracks12);
            _repo.Create(playlistsTracks13);
            

            var uspl = new UserSavedPlaylist
            {
                User = user1,
                SavedPlaylist = pl2
            };
            _repo.Create(uspl);
            

            var lt1 = new LikedTrack {Track = track1, User = user1};
            var lt2 = new LikedTrack {Track = track2, User = user1};

            _repo.Create(lt1);
            _repo.Create(lt2);
        }
    }
}