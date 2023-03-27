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
        private bool MoviesExists(int? id)
        {
            return _db.Movie.Any(e => e.Id == id);
        }
        [HttpPost]
        public async Task<IActionResult> CreateMovies([FromBody] Movies model)
        {
            //Movies.Nota = model.Nota;
            //Movies.Autora = model.Autora;
            //Movies.Editora = model.Editora;
            //Movies.Descricao = model.Descricao;
            //Movies.ImageUrl = model.ImageUrl;
            //Movies.Visto = model.Visto;

            var movies = new Movies();
            _db.Movie.Add(model);
            await _db.SaveChangesAsync();
            movies.Validate();
            return CreatedAtAction("Post", new { id = model.Id }, model);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetId(int id)
        {
            var movies = await _db.Movie.FindAsync(id);

            if (movies == null)
            {
                return NotFound();
            }
            return movies;
        }

        [HttpPut]
        public async Task<IActionResult> EditMovies(int? id, Movies movies)
        {
            if (id != movies.Id)
            {
                return BadRequest();
            }

            _db.Entry(movies).State = EntityState.Modified;

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

        [HttpDelete]
        public async Task<IActionResult> DeletMovies(int id)
        {
            var movies = await _db.Movie.FindAsync(id);
            if (movies == null)
            {
                return NotFound();
            }

            _db.Movie.Remove(movies);
            await _db.SaveChangesAsync();

            return NoContent();
        }
    }
}
