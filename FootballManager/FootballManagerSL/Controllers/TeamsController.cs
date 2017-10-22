using FootballManagerBL.Interfaces;
using FootballManagerBL.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballManagerSL.Controllers
{
    [Route("api/[controller]")]
    public class TeamsController : Controller
    {
        private IUnitOfWork _unit { get; set; }
        public TeamsController(IUnitOfWork unit)
        {
            _unit = unit;
        }

        // GET api/values
        [HttpGet]
        public string Get()
        {
            var result = _unit.Teams.GetAll();
            return JsonConvert.SerializeObject(result);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(Guid id)
        {
            var result = _unit.Teams.Get(id);
            return JsonConvert.SerializeObject(result);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Team team)
        {
            _unit.Teams.Create(team);
            _unit.Save();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(/*Guid id,*/ [FromBody]Team team)
        {
            _unit.Teams.Update(team);
            _unit.Save();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _unit.Teams.Delete(id);
            _unit.Save();
        }
    }
}