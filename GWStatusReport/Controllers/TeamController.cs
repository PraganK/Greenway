using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GWStatusReport.DAL;
using GWStatusReport.Models;
using Microsoft.AspNetCore.Mvc;


namespace GWStatusReport.Controllers
{
    [Route("api/Team")]
    public class TeamController : Controller
    {
        TeamDAL oteam = new TeamDAL();

        // GET: api/Team
        [HttpGet]
        public IEnumerable<Team> Get()
        {
            return oteam.GetAllTeams();
        }

        // GET api/Team/{id}
        [HttpGet("{id}")]
        public Team Get(int id)
        {
            return oteam.GetTeamData(id);
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
