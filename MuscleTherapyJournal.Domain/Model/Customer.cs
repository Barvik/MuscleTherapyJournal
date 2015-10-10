using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MuscleTherapyJournal.Domain.Model
{
    public class Customer
    {
        public int CustomerId { get; set; }
        [DisplayName("Fornavn")]
        [Required(ErrorMessage = "Fornavn må fylles ut.")]
        public string FirstName { get; set; }
        [DisplayName("Mellomnavn")]
        public string Surname { get; set; }
        [DisplayName("Etternavn")]
        public string LastName { get; set; }
        public string CustomerName { get; set; }
        [DisplayName("Telefonnummer")]
        public string MobilePhoneNumber { get; set; }
        [DisplayName("Fødselsdato")]
        public DateTime? BirthDay { get; set; }
        [DisplayName("Adresse")]
        public string Address { get; set; }
        [DisplayName("Postnummer")]
        public string ZipCode { get; set; }
        [DisplayName("Sted")]
        public string LivingLocation { get; set; }
        [DisplayName("E-post")]
        public string Email { get; set; }
        [DisplayName("Yrke")]
        public string Profession { get; set; }
        [DisplayName("Fornavn")]
        public DateTime CreatedDate { get; set; }

        public override string ToString()
        {
            return
                String.Format(
                    "CustomerId: {0}, FirstName: {1}, SurName: {2}, LastName: {3}, MobilePhoneNumber: {4}, BirthDay: {5}"
                    + "Address: {6}, ZipCode: {7}, LivingLocation: {8}, Email: {9}, Profession: {10}, CreatedDate: {11}", 
                    CustomerId, FirstName, Surname, LastName, MobilePhoneNumber, BirthDay, Address, ZipCode, LivingLocation, Email, 
                    Profession, CreatedDate);
        }
    }
}
