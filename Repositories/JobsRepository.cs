using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using gregs_list_mysql.Models;

namespace gregs_list_mysql.Repositories
{
    public class JobsRepository
    {
        public readonly IDbConnection _db;

        public JobsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal IEnumerable<Job> Get()
        {
            string sql = "SELECT * FROM jobs;";
            return _db.Query<Job>(sql);
        }

        internal Job Get(int id)
        {
            string sql = "SELECT * FROM jobs WHERE id = @id;";
            return _db.QueryFirstOrDefault<Job>(sql, new { id });
        }

        internal Job Create(Job newJob)
        {
            string sql = @"
            INSERT INTO jobs
            (company, jobTitle, hours, rate, description)
            VALUES
            (@Company, @JobTitle, @Hours, @Rate, @Description)
            SELECT LAST_INSERT_ID();
            ";
            int id = _db.ExecuteScalar<int>(sql, newJob);
            newJob.Id = id;
            return newJob;
        }

        internal Job Edit(Job original)
        {
            string sql = @"
            UPDATE jobs
            SET
                company = @Company,
                jobTitle = @JobTitle,
                hours = @Hours,
                rate = @Rate,
                description = @Description
            WHERE id = @id;
            SELECT * FROM jobs WHERE id = @id;
            ";
            return _db.QueryFirstOrDefault<Job>(sql, original);
        }

        internal void Delete(int id)
        {
            string sql = @"
            DELETE FROM jobs WHERE id = @id;
            ";
            _db.Execute(sql, new { id });
            return;
        }
    }
}