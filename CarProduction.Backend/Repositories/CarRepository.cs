using CarProduction.Domain;
using System.Data;
using System.Data.SqlClient;

namespace CarProduction.Repositories
{
    public class CarRepository: ICarRepository
    {
        private readonly string _connectionString;

        public CarRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Car> GetAll()
        {
            var result = new List<Car>();

            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            using SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = "select [CarId], [Model], [BuildData], [Price], [ManufacturerId] from [Car]";

            using SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                result.Add(new Car{
                    CarId = Convert.ToInt32(reader["CarId"]),
                    Model = Convert.ToString(reader["Model"]),
                    BuildData = Convert.ToDateTime(reader["BuildData"]),
                    Price = Convert.ToInt32(reader["Price"]),
                    ManufacturerId = Convert.ToInt32(reader["ManufacturerId"])
                });
            }

            return result;
        }

        public List<Car> GetCarByManufacturerId(int manufacturerId)
        {
            var result = new List<Car>();

            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            using SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = "select [CarId], [Model], [BuildData], [Price], [ManufacturerId] from [Car] where [ManufacturerId] = @manufacturerId";
            sqlCommand.Parameters.Add("@manufacturerId", SqlDbType.Int).Value = manufacturerId;

            using SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                result.Add(new Car
                {
                    CarId = Convert.ToInt32(reader["CarId"]),
                    Model = Convert.ToString(reader["Model"]),
                    BuildData = Convert.ToDateTime(reader["BuildData"]),
                    Price = Convert.ToInt32(reader["Price"]),
                    ManufacturerId = Convert.ToInt32(reader["ManufacturerId"])
                });
            }

            return result;
        }

        public Car GetCarById(int carId)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            using SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = "select [CarId], [Model], [BuildData], [Price], [ManufacturerId] from [Car] where [CarId] = @carId";
            sqlCommand.Parameters.Add("@carId", SqlDbType.Int).Value = carId;

            using SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.Read())
            {
                return new Car
                {
                    CarId = Convert.ToInt32(reader["CarId"]),
                    Model = Convert.ToString(reader["Model"]),
                    BuildData = Convert.ToDateTime(reader["BuildData"]),
                    Price = Convert.ToInt32(reader["Price"]),
                    ManufacturerId = Convert.ToInt32(reader["ManufacturerId"])
                };
            }
            else
            {
                return null;
            }
        }

        public int UpdateCar(Car car)
        {
            if (car == null)
            {
                throw new ArgumentNullException(nameof(car));
            }

            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            using SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = "update [Car] set [Model] = @model, [BuildData] = @buildData, [Price] = @price, [ManufacturerId] = @manufacturerId where [CarId] = @carId";
            sqlCommand.Parameters.Add("@carId", SqlDbType.Int).Value = car.CarId;
            sqlCommand.Parameters.Add("@model", SqlDbType.NVarChar, 100).Value = car.Model;
            sqlCommand.Parameters.Add("@buildData", SqlDbType.DateTime).Value = car.BuildData;
            sqlCommand.Parameters.Add("@price", SqlDbType.Int).Value = car.Price;
            sqlCommand.Parameters.Add("@manufacturerId", SqlDbType.Int).Value = car.ManufacturerId;

            return Convert.ToInt32(sqlCommand.ExecuteScalar());

        }

        public void DeleteCar(Car car)
        {
            if (car == null)
            {
                throw new ArgumentNullException(nameof(car));
            }

            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            using SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = "delete [Car] where [CarId] = @carId";
            sqlCommand.Parameters.Add("@carId", SqlDbType.Int).Value = car.CarId;
            sqlCommand.ExecuteNonQuery();
        }

        public List<Car> GroupFromCountOrder(int count)
        {
            var result = new List<Car>();

            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            using SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = "select * from [Car] where [CarId] in ( select [CarId] from [PurchaseOrder] group by [CarId] having count(*) >= @count )";
            sqlCommand.Parameters.Add("@count", SqlDbType.Int).Value = count;

            using SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                result.Add(new Car
                {
                    CarId = Convert.ToInt32(reader["CarId"]),
                    Model = Convert.ToString(reader["Model"]),
                    BuildData = Convert.ToDateTime(reader["BuildData"]),
                    Price = Convert.ToInt32(reader["Price"]),
                    ManufacturerId = Convert.ToInt32(reader["ManufacturerId"])
                });
            }

            return result;
        }

        public int CreateCar(Car car)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            using SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = "insert into [Car] (Model, BuildData, Price, ManufacturerId) values (@model, @buildData, @price, @manufacturerId) ";
            sqlCommand.Parameters.Add("@model", SqlDbType.NVarChar, 100).Value = car.Model;
            sqlCommand.Parameters.Add("@buildData", SqlDbType.DateTime).Value = car.BuildData;
            sqlCommand.Parameters.Add("@price", SqlDbType.Int).Value = car.Price;
            sqlCommand.Parameters.Add("@manufacturerId", SqlDbType.Int).Value = car.ManufacturerId;

            return Convert.ToInt32(sqlCommand.ExecuteScalar());
        }
    }
}
