namespace Exam.ViTube
{
    public class User
    {
        public int VoteVideo { get; set; }

        public int WatchCount { get; set; }

        public int Activity { get; set; }

        public string Id { get; set; }

        public string Username { get; set; }

        public User(string id, string username)
        {
            Id = id;
            Username = username;
        }


    }
}
