using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MusicLibraryNHTests.RepositoriesTests
{
    [TestClass]
    public class TrackRepositoryTests
    {
        //[TestMethod]
        //public void FindsTracksUploadedByEachUser()
        //{
        //    var repo = new TrackRepository();

        //    var userRepo = new UserRepository();

        //    var users = userRepo.GetAll<User>();

        //    foreach (var user in users)
        //    {
        //        Console.WriteLine($"{user.UserName}");
        //        var tracks = repo.GetTracksUploadedByUser(user);

        //        foreach (var track in tracks)
        //        {
        //            Console.WriteLine($"\t\t{track.Author} - {track.Title}");
        //        }
        //    }
        //}

        //[TestMethod]
        //public void GetTitleForTracksInPlaylist()
        //{
        //    var repo = new TrackRepository();

        //    var pl = new Repository().GetAll<Playlist>().SingleOrDefault(p => p.Name == "My Playlist");

        //    if (pl != null)
        //    {
        //        var titles = repo.GetTitlesForTracksInPlaylist(pl);

        //        Console.WriteLine($"{pl.Name}:");
        //        foreach (var title in titles)
        //        {
        //            Console.WriteLine($"\t{title}");
        //        }
        //    }
        //}


        ////[TestMethod]
        ////public void GetPlaylistTracksEagerly()
        ////{
        ////    var repo = new TrackRepository();

        ////    Playlist pl = new PlaylistRepository().GetAll<Playlist>().SingleOrDefault(p => p.Name == "My Playlist");

        ////    Console.WriteLine("/******/");
        ////    if (pl != null)
        ////    {
        ////        var pt = repo.FetchTracksFromPlaylist(pl).First();
        ////        foreach (var ptr in pt.PlaylistsTracks)
        ////        {
        ////            Console.WriteLine(ptr.Track.Title);
        ////        }
        ////    }
        ////}

        //[TestMethod]
        //public void GetsTrackWithItsComments()
        //{
        //    var repo = new TrackRepository();
            
        //    var track = repo.GetTrackWithFetchedCommentById(Guid.Parse("7516C64F-0241-40F3-8DEB-A7D300FDB67D"));
            
        //    Console.WriteLine($"{track.Author} - {track.Title}");
        //    foreach (var comment in track.Comments)
        //    {
        //        Console.WriteLine($"\t{comment.Content}");
        //    }
        //}


        //[TestMethod]
        //public void GetsMostLikedTrackInPlaylist()
        //{
        //    var repo = new TrackRepository();

        //    var playlist = new PlaylistRepository().GetAll<Playlist>().SingleOrDefault(p => p.Name == "My Playlist");

        //    Console.WriteLine(playlist?.Name);

        //    var track = repo.GetMostLikedTrackInPlaylist(playlist);

        //    Console.WriteLine($"{track.Author} - {track.Title}");
        //}
    }
}
