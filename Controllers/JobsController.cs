using System.Collections.Generic;
using gregs_list_mysql.Models;
using gregs_list_mysql.Services;
using Microsoft.AspNetCore.Mvc;

namespace gregs_list_mysql.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobsController : ControllerBase
    {
        private readonly JobsService _service;

        public JobsController(JobsService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Job>> Get()
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
        public ActionResult<Job> Get(int id)
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
        public ActionResult<Job> Create([FromBody] Job newJob)
        {
            try
            {
                return Ok(_service.Create(newJob));
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Job> Edit([FromBody] Job editJob, int id)
        {
            try
            {
                editJob.Id = id;
                return Ok(_service.Edit(editJob));
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<Job> Delete(int id)
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
