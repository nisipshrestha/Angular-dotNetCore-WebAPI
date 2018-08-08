using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Repository;

namespace WebApi.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/Product")]
    public class ProductController : Controller
    {
        private IGenericRepository<Product> _repo;
        public ProductController(IGenericRepository<Product> repo)
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

        // GET: api/Product/5
        [HttpGet("{id}", Name = "GetProduct")]
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
        public IActionResult Post([FromBody]Product product)
        {
            var body = _repo.Add(product);
            var response = Ok(new
            {
                code = 100,
                body = body
            });
            return response;
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Product product)
        {
            var body = _repo.Edit(product, id);
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
