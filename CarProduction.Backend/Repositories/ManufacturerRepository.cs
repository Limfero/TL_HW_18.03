﻿using CarProduction.Domain;
using System.Data;
using System.Data.SqlClient;

namespace CarProduction.Repositories
{
    public class ManufacturerRepository: IManufacturerRepository
    {
        private readonly string _connectionString;

        public ManufacturerRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IReadOnlyList<Manufacturer> GetAll()
        {
            var result = new List<Manufacturer>();

            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            using SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = "select [ManufacturerId], [NameFactory], [Headquarters], [FoundationDate] from [Manufacturer]";

            using SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                result.Add(new Manufacturer
                {
                    ManufacturerId = Convert.ToInt32(reader["ManufacturerId"]),
                    NameFactory = Convert.ToString(reader["NameFactory"]),
                    Headquarters = Convert.ToString(reader["Headquarters"]),
                    FoundationDate = Convert.ToDateTime(reader["FoundationDate"])
                });
            }

            return result;
        }

        public Manufacturer GetManufacturerById(int manufacturerId)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            using SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = "select [ManufacturerId], [NameFactory], [Headquarters], [FoundationDate] from [Manufacturer] where [ManufacturerId] = @manufacturerId";
            sqlCommand.Parameters.Add("@manufacturerId", SqlDbType.Int).Value = manufacturerId;

            using SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.Read())
            {
                return new Manufacturer
                {
                    ManufacturerId = Convert.ToInt32(reader["ManufacturerId"]),
                    NameFactory = Convert.ToString(reader["NameFactory"]),
                    Headquarters = Convert.ToString(reader["Headquarters"]),
                    FoundationDate = Convert.ToDateTime(reader["FoundationDate"])
                };
            }
            else
            {
                return null;
            }
        }
    }
}
