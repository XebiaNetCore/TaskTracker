using System;

namespace TaskTracker.Common.Models
{
    public class UserModel
    {
        public string UserID { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public UserType Usertype { get; set; }
    }

    public enum UserType
    {
        Admin,
        TeamMember
    }
}