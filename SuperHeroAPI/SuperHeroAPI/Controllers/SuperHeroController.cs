using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperHeroAPI.Data;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly DataContext _context;

        //constructor
        public SuperHeroController(DataContext context)
        {
            _context = context;
        }
        [HttpGet] //this is an attributes from c# https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/attributes/ 
        public async Task<ActionResult<List<SuperHero>>> GetSuperHeroes()
        {
            /* return new List<SuperHero>
            {
                new SuperHero
                {
                    Name = "Spider Man From c#",
                    FirstName = "Peter",
                    LastName = "Parker",
                    Place = "New York City"
                }
            }; */
            return Ok(await _context.SuperHeroes.ToListAsync());
        }
    }
}
