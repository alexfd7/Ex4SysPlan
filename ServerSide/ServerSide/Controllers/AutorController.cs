using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using NHibernate;
using NHibernate.Linq;
using ServerSide.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ServerSide.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly ISession  _session;


        public AutorController(ISession session)
        {
            _session = session;
        }

        // GET: api/<AutorController>        
        [HttpGet]
        public async Task<IEnumerable<Autor>> Get()
        {
            return await _session.Query<Autor>().ToListAsync();
        }

        // GET api/<AutorController>/5
        [HttpGet("{id}")]
        public async Task<Autor> Get(int id)
        {
            return await _session.GetAsync<Autor>(id);
        }

        // POST api/<AutorController>
        [HttpPost]
        public async Task PostAsync([FromBody] Autor autor)
        {
            using (ITransaction transaction = _session.BeginTransaction())
            {
                await _session.SaveOrUpdateAsync(autor);
                await transaction.CommitAsync();
            }


        }


        // DELETE api/<AutorController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            var autor = await _session.GetAsync<Autor>(id);

            using (ITransaction transaction = _session.BeginTransaction())
            {
                await _session.DeleteAsync(autor);
                await transaction.CommitAsync();                
            }

        }
    }
}
