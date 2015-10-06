using System;

namespace MuscleTherapyJournal.Domain.Model
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string LastName { get; set; }
        public string MobilePhoneNumber { get; set; }
        public DateTime BirthDay { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string LivingLocation { get; set; }
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }

        public override string ToString()
        {
            return
                String.Format(
                    "CustomerId: {0}, FirstName: {1}, SurName: {2}, LastName: {3}, MobilePhoneNumber: {4}, BirthDay: {5}"
                    + "Address: {6}, ZipCode: {7}, LivingLocation: {8}, Email: {9}, CreatedDate: {10}", CustomerId, FirstName, Surname,
                    LastName, MobilePhoneNumber, BirthDay, Address, ZipCode, LivingLocation, Email, CreatedDate);
        }
    }
}
