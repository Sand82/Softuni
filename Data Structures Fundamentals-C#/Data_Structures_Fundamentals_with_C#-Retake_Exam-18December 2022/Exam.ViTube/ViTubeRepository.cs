using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam.ViTube
{
    public class ViTubeRepository : IViTubeRepository
    {
        private List<User> usersList = new List<User>();

        private Dictionary<string, User> usersDictionary = new Dictionary<string, User>();

        private List<Video> videoList = new List<Video>();

        private Dictionary<string, Video> videoDictionary = new Dictionary<string, Video>();

        private Dictionary<string, User> passiveUsers = new Dictionary<string, User>();    

        public void RegisterUser(User user)
        {
            if (!usersDictionary.ContainsKey(user.Id))
            {
                usersDictionary.Add(user.Id, user);
                passiveUsers.Add(user.Id, user);                
                usersList.Add(user);
            }
        }

        public void PostVideo(Video video)
        {
            if (!videoDictionary.ContainsKey(video.Id))
            {
                videoDictionary.Add(video.Id, video);
                videoList.Add(video);
            }
        }

        public bool Contains(User user)
        {
           return usersDictionary.ContainsKey(user.Id);
        }   

        public bool Contains(Video video)
        {
            return videoDictionary.ContainsKey(video.Id);
        }

        public IEnumerable<Video> GetVideos()
        {
            return new List<Video>(videoList);
        }

        public void WatchVideo(User user, Video video)
        {
            CheckForVideo(video.Id);
            CheckForUser(user.Id);

            video.Views++;
            passiveUsers.Remove(user.Id);
            user.WatchCount++;
        }

        public void LikeVideo(User user, Video video)
        {
            CheckForVideo(video.Id);
            CheckForUser(user.Id);

            passiveUsers.Remove(user.Id);
            user.VoteVideo++;            
            video.Likes++;
        }

        public void DislikeVideo(User user, Video video)
        {
            CheckForVideo(video.Id);
            CheckForUser(user.Id);

            passiveUsers.Remove(user.Id);
            user.VoteVideo++;            
            video.Likes--;
        }

        public IEnumerable<User> GetPassiveUsers()
        {  
            return passiveUsers.Values;
        }

        public IEnumerable<Video> GetVideosOrderedByViewsThenByLikesThenByDislikes()
        {

            var result = new List<Video>();

            if (videoDictionary.Count == 0)
            {
                return result;
            }

            result = videoDictionary
                .Values.OrderByDescending(v => v.Views)
                .ThenByDescending(v => v.Likes)
                .ThenBy(v => v.Dislikes)
                .ToList();

            return result;
        }

        public IEnumerable<User> GetUsersByActivityThenByName()
        {
            var result = new List<User>();

            if (usersList.Count == 0)
            {
                return result;
            }

            result = usersDictionary.Values
                .OrderByDescending(x => x.WatchCount)
                .ThenByDescending(x => x.VoteVideo)
                .ThenBy(x => x.Username)
                .ToList();

            return result;
        }

        private void CheckForVideo(string id)
        {
            if (!videoDictionary.ContainsKey(id))
            {
                throw new ArgumentException();
            }
        }

        private void CheckForUser(string id)
        {
            if (!usersDictionary.ContainsKey(id))
            {
                throw new ArgumentException();
            }
        }
    }
}
