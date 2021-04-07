using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using gregs_list_mysql.Models;

namespace gregs_list_mysql.Repositories
{
    public class CarsRepository
    {
        public readonly IDbConnection _db;

        public CarsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal IEnumerable<Car> Get()
        {
            string sql = "SELECT * FROM cars;";
            return _db.Query<Car>(sql);

        }

        internal Car Get(int id)
        {
            string sql = "SELECT * FROM cars WHERE id = @id;";
            return _db.QueryFirstOrDefault<Car>(sql, new { id });
        }

        internal Car Create(Car newCar)
        {
            string sql = @"
            INSERT INTO cars
            (make, model, year, miles, price)
            VALUES
            (@Make, @Model, @Year, @Miles, @Price);
            SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, newCar);
            newCar.Id = id;
            return newCar;
        }

        internal Car Edit(Car original)
        {
            string sql = @"
            UPDATE cars
            SET
                make = @Make,
                model = @Model,
                year = @Year,
                miles = @Miles,
                price = @Price
            WHERE id = @id;
            SELECT * FROM cars WHERE id = @id;
            ";
            return _db.QueryFirstOrDefault<Car>(sql, original);
        }

        internal void Delete(int id)
        {
            string sql = @"
            DELETE FROM cars WHERE id = @id;
            ";
            _db.Execute(sql, new { id });
            return;
        }
    }
}