using System;
using System.Collections.Generic;
using gregs_list_mysql.Models;
using gregs_list_mysql.Repositories;

namespace gregs_list_mysql.Services
{
    public class JobsService
    {
        private readonly JobsRepository _repo;

        public JobsService(JobsRepository repo)
        {
            _repo = repo;
        }

        internal IEnumerable<Job> Get()
        {
            return _repo.Get();
        }

        internal Job Get(int id)
        {
            Job job = _repo.Get(id);
            if (job != null)
            {
                return job;
            }
            throw new Exception("Invalid ID");
        }

        internal Job Create(Job newJob)
        {
            return _repo.Create(newJob);
        }

        internal Job Edit(Job editJob)
        {
            Job original = Get(editJob.Id);

            original.Company = editJob.Company != null ? editJob.Company : original.Company;
            original.JobTitle = editJob.JobTitle != null ? editJob.JobTitle : original.JobTitle;
            original.Hours = editJob.Hours != null ? editJob.Hours : original.Hours;
            original.Rate = editJob.Rate != null ? editJob.Rate : original.Rate;
            original.Description = editJob.Description != null ? editJob.Description : original.Description;

            return _repo.Edit(original);
        }

        internal Job Delete(int id)
        {
            Job original = Get(id);
            _repo.Delete(id);
            return original;
        }
    }
}