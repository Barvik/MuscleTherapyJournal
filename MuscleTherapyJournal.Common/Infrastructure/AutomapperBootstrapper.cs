using AutoMapper;
using MuscleTherapyJournal.Domain.Model;
using MuscleTherapyJournal.Persitance.Entity;

namespace MuscleTherapyJournal.Common.Infrastructure
{
    public static class AutomapperBootstrapper
    {
        public static void Bootstrap()
        {
            Mapper.CreateMap<User, UserEntity>();
            Mapper.CreateMap<UserEntity, User>();

            Mapper.CreateMap<Customer, CustomerEntity>();
            Mapper.CreateMap<CustomerEntity, Customer>();

            Mapper.CreateMap<AfflictionAreaEntity, AfflictionArea>();
            Mapper.CreateMap<AfflictionArea, AfflictionAreaEntity>();

            Mapper.CreateMap<AfflictionAreaEntity[], AfflictionArea[]>();
            Mapper.CreateMap<AfflictionArea[], AfflictionAreaEntity[]>();

            Mapper.CreateMap<Treatment, TreatmentEntity>();
            Mapper.CreateMap<TreatmentEntity, Treatment>();
        }
    }
}
