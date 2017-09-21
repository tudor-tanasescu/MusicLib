using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MusicLibraryNHTests.RepositoriesTests
{
    [TestClass]
    public class PlaylistRepositoryTests
    {
        //[TestMethod]
        //public void TestMethod1()
        //{
        //    var plr = new PlaylistRepository();

        //    var users = plr.GetAll<User>();

        //    foreach (var user in users)
        //    {
        //        Console.WriteLine($"{user.UserName} {user.SavedPlaylists.Count} {user.UserPlaylists.Count}");
        //        var playlists = plr.GeUserSavedPlaylists(user);

        //        foreach (var pl in playlists)
        //        {
        //            Console.WriteLine($"\tSaved: \"{pl.Name}\" {pl.PlaylistsTracks.Count} from {pl.Creator}");
        //            foreach (var pt in pl.PlaylistsTracks)
        //            {
        //                Console.WriteLine($"\t\t{pt.Track.Author} - {pt.Track.Title}");
        //            }
        //        }

        //        if (playlists.Any()) Console.WriteLine();
        //        foreach (var pl in user.UserPlaylists)
        //        {
        //            Console.WriteLine($"\tCreated: \"{pl.Name}\" {pl.PlaylistsTracks.Count}");
        //            foreach (var pt in pl.PlaylistsTracks)
        //            {
        //                Console.WriteLine($"\t\t{pt.Track.Author} - {pt.Track.Title}");
        //            }
        //        }
        //    }
        //}

        //[TestMethod]
        //public void GetAllPlaylistsForUsers()
        //{
        //    var plr = new PlaylistRepository();

        //    var users = plr.GetAll<User>();

        //    foreach (var user in users)
        //    {
        //        Console.WriteLine($"{user.UserName} {user.SavedPlaylists.Count} {user.UserPlaylists.Count}");
        //        var playlists = plr.GetAllPlaylistsForUser(user);

        //        foreach (var pl in playlists)
        //        {
        //            Console.WriteLine($"\t\"{pl.Name}\" {pl.PlaylistsTracks.Count} by {pl.Creator}");
        //            foreach (var pt in pl.PlaylistsTracks)
        //            {
        //                Console.WriteLine($"\t\t{pt.Track.Author} - {pt.Track.Title}");
        //            }
        //        }
        //    }
        //}

        //[TestMethod]
        //public void GetPlaylistTitlesForEachUser()
        //{
        //    var plr = new PlaylistRepository();

        //    var users = plr.GetAll<User>();

        //    foreach (var user in users)
        //    {
        //        Console.WriteLine(user.UserName);
        //        var plTitles = plr.GetUserCreatedPlaylistTitles(user);

        //        foreach (var title in plTitles)
        //        {
        //            Console.WriteLine($"\t{title}");
        //        }
        //    }
        //}
    }
}
