using Microsoft.AspNetCore.Mvc;
using nba_api.Models;
using nba_api.Services;

namespace nba_api.Controllers
{ 
    [Route("api/[controller]")]
    public class TeamController : Controller
    {
        ITeamService teamService;
        NBAContext nbaContext;

        public TeamController(ITeamService service, NBAContext db)
        {
            teamService = service;
            nbaContext = db;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(teamService.Get());
        }

        [HttpPost]
        public IActionResult Post([FromBody] Team team)
        {
            teamService.Save(team);
            return Ok();
        }


        //Crear la db
        [HttpGet]
        [Route("createdb")]
        public IActionResult CreateDB()
        {
            nbaContext.Database.EnsureCreated();
            return Ok();
        }


    




    }
}
