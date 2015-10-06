using System;

namespace MuscleTherapyJournal.Domain.Model
{
    public class User
    {
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

        public override string ToString()
        {
            return
                String.Format(
                    "UserId: {0}, FirstName: {1}, LastName: {2}, Email: {3}, MobilePhoneNumber: {4}, MustChangePassword: {5}"
                    + "DateOfBirth: {6}, Blocked: {7}, Activated: {8}, UserName: {9}", UserId, FirstName, LastName,
                    Email, MobilePhoneNumber, MustChangePassword, DateOfBirth, Blocked, Activated, UserName);
        }
    }
}
