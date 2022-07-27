using CarProduction.Domain;
using System.Data;
using System.Data.SqlClient;

namespace CarProduction.Repositories
{
    public class CarDealershipRepository: ICarDealershipRepository
    {
        private readonly string _connectionString;

        public CarDealershipRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<CarDealership> GetAll()
        {
            var result = new List<CarDealership>();

            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            using SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = "select [DealershipId], [NameDealership], [Supplier] from [CarDealership]";

            using SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                result.Add(new CarDealership 
                {
                    DealershipId = Convert.ToInt32(reader["DealershipId"]),
                    NameDealership = Convert.ToString(reader["NameDealership"]),
                    Supplier = Convert.ToInt32(reader["Supplier"])
                });
            }

            return result;
        }

        public int CreateCarDealership(CarDealership carDealership)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            using SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = "insert into [CarDealership] (NameDealership, Supplier) values (@nameDealership, @supplier) ";
            sqlCommand.Parameters.Add("@nameDealership", SqlDbType.NVarChar, 100).Value = carDealership.NameDealership;
            sqlCommand.Parameters.Add("@supplier)", SqlDbType.Int).Value = carDealership.Supplier;

            return Convert.ToInt32(sqlCommand.ExecuteScalar());
        }

    }
}
