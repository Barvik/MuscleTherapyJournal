using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace MuscleTherapyJournal.Persitance
{
    public class DapperConnectionSingleton
    {
        private static IDbConnection instance;

        public static IDbConnection DapperConnection
        {
            get
            {
                if (instance == null)
                {
                    instance = new SqlConnection(ConfigurationManager.ConnectionStrings["MuscleTherapyDatabase"].ConnectionString);
                }
                return instance;
            }
        }

    }
}
