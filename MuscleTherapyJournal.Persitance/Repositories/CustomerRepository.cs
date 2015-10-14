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

namespace MuscleTherapyJournal.Persitance.DAO
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof (CustomerRepository));
        private IDbConnection _dapperDbConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["MuscleTherapyDatabase"].ConnectionString);

        private string SearchCustomer_Query = "SELECT * " +
                                                       "FROM Customer ";

        private readonly string Query_CustomerName = "CustomerName LIKE @CustomerName ";
        private readonly string Query_MobilePhone = " MobilePhoneNumber = @MobilePhoneNumber ";
        private readonly string Query_Profession = " Profession = @Profession ";

        public void UpdateExistingCustomer(CustomerEntity customer)
        {
            _logger.DebugFormat("Updating Existing customer with customerId: {0}", customer.CustomerId);

            using (var db = new MuscleTherapyContext())
            {
                db.Customers.Attach(customer);
                db.SaveChanges();
            }
        }

        public void UpdateNewCustomer(CustomerEntity customer)
        {
            _logger.DebugFormat("Updating new customer");
            using (var db = new MuscleTherapyContext())
            {
                db.Customers.Add(customer);
                db.SaveChanges();
            }
        }

        public CustomerEntity GetCustomerByCustomerId(int customerId)
        {
            _logger.DebugFormat("GetCustomerByCustomerId");
            using (var db = new MuscleTherapyContext())
            {
                return db.Customers.Find(customerId);
            }
        }

        public List<CustomerEntity> GetAllCustomers()
        {
            _logger.DebugFormat("GetAllCustomers");
            using (var db = new MuscleTherapyContext())
            {
                return db.Customers.ToList();
            }
        }

        public List<CustomerEntity> GetCustomerBySearchParameters(SearchParameters searchParameters)
        {
            DynamicParameters parameters = null;
            var isWhereClauseAppended = false;
            var needForAndClause = false;

            if (!string.IsNullOrWhiteSpace(searchParameters.CustomerName))
            {
                isWhereClauseAppended = true;
                needForAndClause = true;
                if (parameters == null)
                {
                    parameters = new DynamicParameters();
                }

                SearchCustomer_Query += "WHERE ";
                SearchCustomer_Query += Query_CustomerName;
                parameters.Add("CustomerName", "%" + searchParameters.CustomerName + "%");
            }

            if (!string.IsNullOrWhiteSpace(searchParameters.PhoneNumber))
            {
                if (parameters == null)
                {
                    parameters = new DynamicParameters();
                }
                if (!isWhereClauseAppended)
                {
                    SearchCustomer_Query += "WHERE ";
                    isWhereClauseAppended = true;
                }
                if (needForAndClause)
                {
                    SearchCustomer_Query += "AND ";
                    needForAndClause = true;
                }

                SearchCustomer_Query += Query_MobilePhone;
                parameters.Add("MobilePhoneNumber", searchParameters.PhoneNumber);
            }

            if (!string.IsNullOrWhiteSpace(searchParameters.Profession))
            {
                if (parameters == null)
                {
                    parameters = new DynamicParameters();
                }

                if (!isWhereClauseAppended)
                {
                    SearchCustomer_Query += "WHERE ";
                    isWhereClauseAppended = true;
                }

                if (needForAndClause)
                {
                    SearchCustomer_Query += "AND ";
                    needForAndClause = true;
                }

                SearchCustomer_Query += Query_Profession;
                parameters.Add("Profession", searchParameters.Profession);
            }

            _logger.DebugFormat("GetCustomerBySearchParameters");
            var result = DapperConnectionSingleton.DapperConnection.Query<CustomerEntity>(SearchCustomer_Query, parameters);

            return result.ToList();
        }
    }
}
