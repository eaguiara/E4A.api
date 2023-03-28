using E4A.Api.Data;
using E4A.Api.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E4A.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        public List<Movies> Movies { get; set; } = new List<Movies>();
        private readonly Context _db;

        public MoviesController(Context db)
        {
            _db = db;
        }
        [HttpPost]
        public async Task<ActionResult<Movies>> Post(Movies movie)
        {
            _db.Movie.Add(movie);
            await _db.SaveChangesAsync();
            movie.Validate();
            return CreatedAtAction(nameof(GetId), new { id = movie.Id }, movie);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movies>>> Get()
        {
            return await _db.Movie.ToListAsync();

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Movies>> GetId(int id)
        {
            var movies = await _db.Movie.FindAsync(id);

            if (movies == null)
            {
                return NotFound();
            }
            return movies;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditMovies(int id, Movies movies)
        {
            if (id != movies.Id)
            {
                return BadRequest();
            }

            _db.Movie.Update(movies);

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MoviesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool MoviesExists(int id)
        {
            return _db.Movie.Any(e => e.Id == id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletMovies(int id)
        {
            Movies movie = await _db.Movie.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            _db.Movie.Remove(movie);
            await _db.SaveChangesAsync();

            return NoContent();
        }
    }
}
