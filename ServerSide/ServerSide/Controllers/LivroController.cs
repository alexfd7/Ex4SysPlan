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
    public class LivroController : ControllerBase
    {


        private readonly ISession _session;

        public LivroController(ISession session)
        {
            _session = session;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<IEnumerable<Livro>> Get()
        {
            return await _session.Query<Livro>().ToListAsync();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<Livro> Get(int id)
        {
            return await _session.GetAsync<Livro>(id);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task PostAsync([FromBody] Livro livro)
        {

            using (ITransaction transaction = _session.BeginTransaction())
            {
                await _session.SaveOrUpdateAsync(livro);
                await transaction.CommitAsync();
            }

        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            var livro = await _session.GetAsync<Livro>(id);

            using (ITransaction transaction = _session.BeginTransaction())
            {
                await _session.DeleteAsync(livro);
                await transaction.CommitAsync();
            }

        }
    }
}
