using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FootballManagerBL.Interfaces;
using Newtonsoft.Json;
using FootballManagerBL.Model;

namespace FootballManagerSL.Controllers
{
    [Route("api/[controller]")]
    public class PlayersController : Controller
    {
        private IUnitOfWork _unit { get; set; }
        public PlayersController(IUnitOfWork unit)
        {
            _unit = unit;
        }

        // GET api/values
        [HttpGet]
        public string Get()
        {
            var result = _unit.Players.GetAll();
            return JsonConvert.SerializeObject(result);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(Guid id)
        {
            var result = _unit.Players.Get(id);
            return JsonConvert.SerializeObject(result);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Player player)
        {
            _unit.Players.Create(player);
            _unit.Save();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(/*Guid id,*/ [FromBody]Player player)
        {
            _unit.Players.Update(player);
            _unit.Save();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _unit.Players.Delete(id);
            _unit.Save();
        }
    }
}
