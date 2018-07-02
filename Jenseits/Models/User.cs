using System;
namespace Jenseits.Models
{
    public class User
    {
        public string UserId { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string FullName { get; set; }

        public string PersonalPhoto { get; set; }

        public string PersonalAddress { get; set; }

        public string Email { get; set; }

        public int MobileNumber { get; set; }

        public string NIDNumber { get; set; }

        public DateTime NIDValidUntil { get; set; }

        public string NIDPhotoCopy { get; set; }

        public string PassportNumber { get; set; }

        public DateTime PassportValidUntil { get; set; }

        public string PassportPhotoCopy { get; set; }
    }
}
