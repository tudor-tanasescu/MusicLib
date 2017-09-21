using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MusicLibraryNHTests.RepositoriesTests
{
    [TestClass]
    public class UserRepositoryTests
    {
        //[TestMethod]
        //public void ShowTracksLikeByEachUser()
        //{
        //    var repo = new UserRepository();

        //    var users = repo.GetAll<User>();

        //    foreach (var user in users)
        //    {
        //        Console.WriteLine($"{user.UserName} {user.LikedTracks.Count}");
        //        var likedTraks = repo.GetTracksLikedByUser(user);

        //        foreach (var track in likedTraks)
        //        {
        //            Console.WriteLine($"\t\t{track.Author} - {track.Title} by {track.Uploader}");
        //        }
        //    }
        //}

        //[TestMethod]
        //public void CheckIfATrackIsLikeByAnUser()
        //{
        //    var repo = new UserRepository();
        //    var trackRepo = new TrackRepository();

        //    var userA = repo.FindUserByUserName("a.a");

        //    var track1 = trackRepo.FindTrackByTitle("Places 0");
        //    var track2 = trackRepo.FindTrackByTitle("Joy and Sadness");


        //    if (track1 != null && userA != null)
        //    {
        //        Console.Write($"{track1.Author} - {track1.Title} is liked by {userA.UserName} = ");

        //        Console.WriteLine(repo.IsTrackLikedByUser(userA, track1));
        //    }

        //    if (track2 != null && userA != null)
        //    {
        //        Console.Write($"{track2.Author} - {track2.Title} is liked by {userA.UserName} = ");

        //        Console.WriteLine(repo.IsTrackLikedByUser(userA, track2));
        //    }

        //}

        //[TestMethod]
        //public void ShowFollowersForUsers()
        //{
        //    var repo = new UserRepository();

        //    var users = repo.GetAll<User>();

        //    foreach (var user in users)
        //    {
        //        var fl = repo.GetUsersThatFollowAnUser(user);

        //        Console.WriteLine($"{user.UserName} {user.Followers.Count}");

        //        foreach (var fUser in fl)
        //        {
        //            Console.WriteLine($"\t\t{fUser.UserName}");
        //        }
        //    }
        //}

        //[TestMethod]
        //public void GetUsersEmailDto()
        //{
        //    var repo = new UserRepository();

        //    var userA = repo.FindUserByUserName("c.c");

        //    var userAEmailDto = repo.GetUserEmailDto(userA);

        //    if (userAEmailDto != null) Console.WriteLine($"Single:\n\t{userAEmailDto.Name} {userAEmailDto.Email}");

        //    var allEmailDtos = repo.GetAllUsersEmailDto();

        //    Console.WriteLine("All:");
        //    foreach (var dto in allEmailDtos)
        //    {
        //        Console.WriteLine($"\t{dto.Name} {dto.Email} {dto.Age}");
        //    }
        //}

        //[TestMethod]
        //public void GetUsersWithMoreFollowersThanValue()
        //{
        //    var repo = new UserRepository();
        //    var users = repo.GetUsersWithMoreFollowersThan(1);

        //    foreach (var user in users)
        //    {
        //        Console.WriteLine(user.UserName);
        //    }
        //}

        //[TestMethod]
        //public void GetUsersWithFolowers()
        //{
        //    var repo = new UserRepository();
        //    var users = repo.GetUsersWithFollowers();

        //    foreach (var user in users)
        //    {
        //        Console.WriteLine(user.UserName);
        //    }
        //}
        
        //[TestMethod]
        //public void GetsUserCommentsAndPlaylistsDeffered()
        //{
        //    var repo = new UserRepository();

        //    var user = repo.FindUserByUserName("b.b");

        //    var comments = repo.GetUserCommentsDeffered(user);

        //    var playlists = repo.GetUserPlaylistsDeffered(user);

        //    var tracksCount = repo.GetUserPlaylistTotalTrackCount(user);


        //    Console.WriteLine(user.UserName);

        //    Console.WriteLine("Comments:");
        //    foreach (var comment in comments)
        //    {
        //        Console.WriteLine($"\t{comment.Content}");
        //    }

        //    Console.WriteLine($"Playlists ({tracksCount.Value} tracks):");
        //    foreach (var playlist in playlists)
        //    {
        //        Console.WriteLine($"\t{playlist.Name}");
        //    }
        //}

        //[TestMethod]
        //public void GetsUsersWhoFollowTheirFollowers()
        //{
        //    var repo = new UserRepository();

        //    var users = repo.GetUsersWhoFollowTheirFollowers();

        //    foreach (var user in users)
        //    {
        //        Console.WriteLine(user.UserName);
        //    }
        //}
    }
}
