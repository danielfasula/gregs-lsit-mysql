using System;
using System.Collections.Generic;
using gregs_list_mysql.Models;
using gregs_list_mysql.Repositories;

namespace gregs_list_mysql.Services
{
    public class HousesService
    {
        private readonly HousesRepository _repo;

        public HousesService(HousesRepository repo)
        {
            _repo = repo;
        }

        internal IEnumerable<House> Get()
        {
            return _repo.Get();
        }

        internal House Get(int id)
        {
            House house = _repo.Get(id);
            if (house != null)
            {
                return house;
            }
            throw new Exception("Invalid ID");
        }

        internal House Create(House newHouse)
        {
            return _repo.Create(newHouse);
        }

        internal House Edit(House editHouse)
        {
            House original = Get(editHouse.Id);

            original.Bedrooms = editHouse.Bedrooms != null ? editHouse.Bedrooms : original.Bedrooms;
            original.Bathrooms = editHouse.Bathrooms != null ? editHouse.Bathrooms : original.Bathrooms;
            original.Levels = editHouse.Levels != null ? editHouse.Levels : original.Levels;
            original.Description = editHouse.Description != null ? editHouse.Description : original.Description;
            original.Price = editHouse.Price != null ? editHouse.Price : original.Price;

            return _repo.Edit(original);
        }

        internal House Delete(int id)
        {
            House original = Get(id);
            _repo.Delete(id);
            return original;
        }
    }
}
