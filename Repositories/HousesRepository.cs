using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using gregs_list_mysql.Models;

namespace gregs_list_mysql.Repositories
{
    public class HousesRepository
    {
        public readonly IDbConnection _db;

        public HousesRepository(IDbConnection db)
        {
            _db = db;
        }

        internal IEnumerable<House> Get()
        {
            string sql = "SELECT * FROM houses;";
            return _db.Query<House>(sql);
        }

        internal House Get(int id)
        {
            string sql = "SELECT * FROM houses WHERE id = @id;";
            return _db.QueryFirstOrDefault<House>(sql, new { id });
        }

        internal House Create(House newHouse)
        {
            string sql = @"
            INSERT INTO houses
            (bedrooms, bathrooms, levels, description, price)
            VALUES
            (@Bedrooms, @Bathrooms, @Levels, @Description, @Price);
            SELECT LAST_INSERT_ID();
            ";
            int id = _db.ExecuteScalar<int>(sql, newHouse);
            newHouse.Id = id;
            return newHouse;
        }

        internal House Edit(House original)
        {
            string sql = @"
            UPDATE houses
            SET
                bedrooms = @Bedrooms,
                bathrooms = @Bathrooms,
                levels = @Levels,
                description = @Description,
                price = @Price
            WHERE id = @id;
            SELECT * FROM houses WHERE id = @id;
            ";
            return _db.QueryFirstOrDefault<House>(sql, original);
        }

        internal void Delete(int id)
        {
            string sql = @"
            DELETE FROM houses WHERE id = @id;
            ";
            _db.Execute(sql, new { id });
            return;
        }
    }
}