using System;
using System.Collections.Generic;
using gregs_list_mysql.Models;
using gregs_list_mysql.Repositories;

namespace gregs_list_mysql.Services
{
    public class CarsService
    {
        private readonly CarsRepository _repo;

        public CarsService(CarsRepository repo)
        {
            _repo = repo;
        }

        internal IEnumerable<Car> Get()
        {
            return _repo.Get();
        }

        internal Car Get(int id)
        {
            Car car = _repo.Get(id);
            if (car != null)
            {
                return car;
            }
            throw new Exception("Invalid ID");
        }

        internal Car Create(Car newCar)
        {
            return _repo.Create(newCar);
        }

        internal object Edit(Car editCar)
        {
            Car original = Get(editCar.Id);

            original.Make = editCar.Make != null ? editCar.Make : original.Make;
            original.Model = editCar.Model != null ? editCar.Model : original.Model;
            original.Year = editCar.Year != null ? editCar.Year : original.Year;
            original.Miles = editCar.Miles != null ? editCar.Miles : original.Miles;
            original.Price = editCar.Price != null ? editCar.Price : original.Price;

            return _repo.Edit(original);

        }

        internal Car Delete(int id)
        {
            Car original = Get(id);
            _repo.Delete(id);
            return original;
        }
    }
}