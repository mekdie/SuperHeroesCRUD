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

        [HttpPost] //add new hero
        public async Task<ActionResult<List<SuperHero>>> CreateSuperHero(SuperHero hero)
        {
            _context.SuperHeroes.Add(hero);
            await _context.SaveChangesAsync();

            return Ok(await _context.SuperHeroes.ToListAsync());
        }

        [HttpPut] //update
        public async Task<ActionResult<List<SuperHero>>> UpdateSuperHero(SuperHero hero)
        {
            var dbHero = await _context.SuperHeroes.FindAsync(hero.Id);
            if (dbHero == null)
                return BadRequest("Hero not found");

            dbHero.Name = hero.Name;
            dbHero.FirstName = hero.FirstName;
            dbHero.LastName = hero.LastName;
            dbHero.Place = hero.Place;

            await _context.SaveChangesAsync();

            return Ok(await _context.SuperHeroes.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> DeleteSuperHero(int id)
        {
            var dbHero = await _context.SuperHeroes.FindAsync(id);
            if (dbHero == null)
                return BadRequest("Hero not found");

            _context.SuperHeroes.Remove(dbHero);
            await _context.SaveChangesAsync();

            return Ok(await _context.SuperHeroes.ToListAsync());

        }
    }
}
