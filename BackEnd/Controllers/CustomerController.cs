using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/Customer")]
    public class CustomerController : Controller
    {
        private IGenericRepository<Customer> _repo;
        public CustomerController(IGenericRepository<Customer> repo)
        {
            _repo = repo;
        }

        // GET: api/<controller>
        [HttpGet]
        public IActionResult Get()
        {
            var body = _repo.GetAll();
            var response = Ok(new
            {
                code = 100,
                body = body
            });
            return response;
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var body = _repo.Get(id);
            var response = Ok(new
            {
                code = 100,
                body = body
            });
            return response;
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]Customer customer)
        {
            var body = _repo.Add(customer);
            var response = Ok(new
            {
                code = 100,
                body = body
            });
            return response;
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Customer customer)
        {
            var body = _repo.Edit(customer, id);
            var response = Ok(new
            {
                code = 100,
                body = body
            });
            return response;
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var body = _repo.Delete(id);
            var response = Ok(new
            {
                code = 100,
                body = body
            });
            return response;
        }
    }
}