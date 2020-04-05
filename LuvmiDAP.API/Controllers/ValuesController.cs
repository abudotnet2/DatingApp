using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LuvmiDAP.API.Data;
using LuvmiDAP.API.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LuvmiDAP.API.Controllers
{
   // [Authorize]
    [Route("api/[controller]")]
    //[ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly DataContext _context;

        public ValuesController(DataContext context)
        {
            this._context = context;
        }
        // GET: api/Values
        [HttpGet]
        public async Task<  IActionResult> Get()
        {
            var values = await  _context.DValues.ToListAsync();

            return Ok(values);
        }

        [AllowAnonymous]
        // GET: api/Values/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
