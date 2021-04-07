using gregs_list_mysql.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using gregs_list_mysql.Models;

namespace gregs_list_mysql.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarsController : ControllerBase
    {

        private readonly CarsService _service;

        public CarsController(CarsService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Car>> Get()
        {
            try
            {
                return Ok(_service.Get());
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Car> Get(int id)
        {
            try
            {
                return Ok(_service.Get(id));
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public ActionResult<Car> Create([FromBody] Car newCar)
        {
            try
            {
                return Ok(_service.Create(newCar));
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Car> Edit([FromBody] Car editCar, int id)
        {
            try
            {
                editCar.Id = id;
                return Ok(_service.Edit(editCar));
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<Car> Delete(int id)
        {
            try
            {
                return Ok(_service.Delete(id));
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}