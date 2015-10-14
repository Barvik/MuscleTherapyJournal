using System;

namespace MuscleTherapyJournal.Persitance.RelationshipEntities
{
    public class TreatmentCustomerEntity
    {
        public int TreatmentId { get; set; }
        public int CustomerId { get; set; }
        public DateTime TreatmentCreatedDate { get; set; }
        public DateTime ChangedDate { get; set; }
        public int UserId { get; set; }
        public string Anamnesis { get; set; }
        public string Observations { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string LastName { get; set; }
        public string CustomerName { get; set; }
        public string MobilePhoneNumber { get; set; }
        public DateTime? BirthDay { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string LivingLocation { get; set; }
        public string Email { get; set; }
        public string Profession { get; set; }
        public DateTime CustomerCreatedDate { get; set; }
        
    }
}
