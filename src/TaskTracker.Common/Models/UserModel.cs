using System;
using System.ComponentModel.DataAnnotations;

namespace TaskTracker.Common.Models
{
    public class UserModel
    {
        [Key]
        public Guid UserID { get; set; }

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