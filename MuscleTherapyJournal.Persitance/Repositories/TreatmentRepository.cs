using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using log4net;
using MuscleTherapyJournal.Domain.Search;
using MuscleTherapyJournal.Persitance.DAO.Interfaces;
using MuscleTherapyJournal.Persitance.Entity;
using MuscleTherapyJournal.Persitance.RelationshipEntities;

namespace MuscleTherapyJournal.Persitance.DAO
{
    public class TreatmentRepository : ITreatmentRepository
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(TreatmentRepository));
        private IDbConnection _dapperDbConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["MuscleTherapyDatabase"].ConnectionString);

        private string SearchTreatment_Query = "SELECT *, t.CreatedDate AS TreatmentCreatedDate, c.CreatedDate AS CustomerCreatedDate FROM Treatment t " +
                                                        "INNER JOIN Customer c ON t.CustomerId = c.CustomerId " +
                                                        "WHERE (t.createdDate >= @FromDate and t.createdDate <= @ToDate) ";

        private readonly string Query_CustomerName = " c.CustomerName LIKE @CustomerName ";
        private readonly string Query_MobilePhone = " c.MobilePhoneNumber = @MobilePhoneNumber ";

        private string SearchOldTreatments_Query =
            "SELECT * from Treatment WHERE customerId = @CustomerId ORDER BY CreatedDate DESC";

        public void CreateTreatment(TreatmentEntity treatment)
        {
            _logger.DebugFormat("Create treatment.");

            using (var db = new MuscleTherapyContext())
            {
                db.Treatments.Add(treatment);
                db.SaveChanges();
            }
        }

        public TreatmentEntity GetTreatment(int treatmentId)
        {
            _logger.DebugFormat("GetTreatment.");

            using (var db = new MuscleTherapyContext())
            {
                return db.Treatments.Find(treatmentId);
            }
        }

        public List<TreatmentCustomerEntity> GetTreatmentsBySearchCriteria(SearchParameters searchParameters, DateTime fromDate, DateTime toDate)
        {
            var parameters = new DynamicParameters();
            parameters.Add("FromDate", fromDate);
            parameters.Add("ToDate", toDate);

            if (!string.IsNullOrWhiteSpace(searchParameters.CustomerName))
            {
                SearchTreatment_Query += "AND" + Query_CustomerName;
                parameters.Add("CustomerName", "%" + searchParameters.CustomerName + "%");
            }

            if (!string.IsNullOrWhiteSpace(searchParameters.PhoneNumber))
            {
                SearchTreatment_Query += "AND" + Query_MobilePhone;
                parameters.Add("MobilePhoneNumber", searchParameters.PhoneNumber);
            }

            SearchTreatment_Query += " ORDER BY t.CreatedDate DESC";

            var result = DapperConnectionSingleton.DapperConnection.Query<TreatmentCustomerEntity>(SearchTreatment_Query, parameters);

            return result.ToList();
        }

        public List<TreatmentEntity> GetTreatmentsByCustomerId(int customerId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", customerId);

            var result = DapperConnectionSingleton.DapperConnection.Query<TreatmentEntity>(SearchOldTreatments_Query, parameters);

            return result.ToList();
        }
    }
}
