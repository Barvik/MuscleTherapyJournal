using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuscleTherapyJournal.Persitance.Entity
{
    public class UserEntity
    {
        [Key]
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string MobilePhoneNumber { get; set; }
        public bool MustChangePassword { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool Blocked { get; set; }
        public bool Activated { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public string UserName { get; set; }
    }
}
