using Microsoft.AspNetCore.Mvc;

namespace OurRestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController] 
    public class MatchesController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok( new {message="Hello, Matches Controller is Working"});
        }
        [HttpGet("/players")]
        public IActionResult Players()
        {
            List<string> footballPlayers = new List<string>
        {
            "Lionel Messi",
            "Cristiano Ronaldo",
            "Neymar Jr",
            "Kylian Mbappe",
            "Kevin De Bruyne",
            "Robert Lewandowski",
            "Mohamed Salah",
            "Sadio Mane",
            "Virgil van Dijk",
            "Harry Kane",
            "Erling Haaland",
            "Karim Benzema",
            "Luka Modric",
            "Sergio Ramos",
            "Paul Pogba",
            "Raheem Sterling",
            "Jadon Sancho",
            "Eden Hazard",
            "Toni Kroos",
            "Manuel Neuer"
        };
            return Ok( footballPlayers);
        }
    }
}
