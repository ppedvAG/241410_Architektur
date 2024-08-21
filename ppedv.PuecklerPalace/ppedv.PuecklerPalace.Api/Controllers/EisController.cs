using Microsoft.AspNetCore.Mvc;
using ppedv.PuecklerPalace.Api.Model;
using ppedv.PuecklerPalace.Model.Contracts.Data;
using ppedv.PuecklerPalace.Model.Contracts.Services;
using ppedv.PuecklerPalace.Model.DomainModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ppedv.PuecklerPalace.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EisController : ControllerBase
    {
        private readonly IRepository repo;
        private readonly IEisService eisService;

        public EisController(IRepository repo, IEisService eisService)
        {
            this.repo = repo;
            this.eisService = eisService;
        }

        // GET: api/<EisController>
        [HttpGet]
        public IEnumerable<EisDTO> Get()
        {
            return EisMapper.ToEisDTOList(repo.GetAll<Eissorte>().ToList());
        }

        // GET api/<EisController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EisController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<EisController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EisController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
