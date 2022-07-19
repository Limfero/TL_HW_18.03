using CarProduction.Domain;
using System.Data.SqlClient;

namespace CarProduction.Repositories
{
    public class PurchaseOrderRepository : IPurchaseOrderRepository
    {
        private readonly string _connectionString;

        public PurchaseOrderRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IReadOnlyList<PurchaseOrder> GetAll()
        {
            var result = new List<PurchaseOrder>();

            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            using SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = "select [NameBuyer], [DealershipId], [CarId] from [PurchaseOrder]";

            using SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                result.Add(new PurchaseOrder{
                    NameBuyer = Convert.ToString(reader["NameBuyer"]),
                    DealershipId = Convert.ToInt32(reader["DealershipId"]),
                    CarId = Convert.ToInt32(reader["CarId"])
                });
            }

            return result;
        }
    }
}
