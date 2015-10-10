using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MuscleTherapyJournal.Persitance.Entity
{
    public class UserEntity
    {
        [Key]
        public int UserId { get; set; }
        [MaxLength(255), Column(TypeName = "VARCHAR")]
        public string FirstName { get; set; }
        [MaxLength(255), Column(TypeName = "VARCHAR")]
        public string LastName { get; set; }
        [MaxLength(255), Column(TypeName = "VARCHAR")]
        public string Email { get; set; }
        [MaxLength(255), Column(TypeName = "VARCHAR")]
        public string MobilePhoneNumber { get; set; }
        public bool MustChangePassword { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool Blocked { get; set; }
        public bool Activated { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        [MaxLength(255), Column(TypeName = "VARCHAR")]
        public string UserName { get; set; }
    }
}
