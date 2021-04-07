using System.Collections.Generic;
using gregs_list_mysql.Models;
using gregs_list_mysql.Services;
using Microsoft.AspNetCore.Mvc;

namespace gregs_list_mysql.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HousesController : ControllerBase
    {
        private readonly HousesService _service;

        public HousesController(HousesService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<House>> Get()
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
        public ActionResult<House> Get(int id)
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
        public ActionResult<House> Create([FromBody] House newHouse)
        {
            try
            {
                return Ok(_service.Create(newHouse));
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<House> Edit([FromBody] House editHouse, int id)
        {
            try
            {
                editHouse.Id = id;
                return Ok(_service.Edit(editHouse));
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<House> Delete(int id)
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