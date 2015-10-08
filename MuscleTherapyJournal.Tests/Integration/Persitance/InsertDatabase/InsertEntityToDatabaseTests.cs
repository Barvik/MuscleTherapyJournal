using System;
using MuscleTherapyJournal.Persitance;
using MuscleTherapyJournal.Persitance.Entity;
using NUnit.Framework;

namespace MuscleTherapyJournal.Tests.Integration.Persitance.InsertDatabase
{
    [TestFixture]
    public class InsertEntityToDatabaseTests
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void AddNewCustomerToDatabase()
        {
            var customer = new CustomerEntity
            {
                FirstName = "Petter",
                LastName = "Petter",
                BirthDay = DateTime.Now,
                CreatedDate = DateTime.Now

            };

            using (var db = new MuscleTherapyContext())
            {
                db.Customers.Add(customer);
                db.SaveChanges();
            }
        }

        [Test]
        public void AddNewUserToDatabase()
        {
            var user = new UserEntity
            {
                FirstName = "Petter",
                LastName = "Petter",
                DateOfBirth = DateTime.Now
            };

            using (var db = new MuscleTherapyContext())
            {
                db.Users.Add(user);
                db.SaveChanges();
            }
        }
    }
}
