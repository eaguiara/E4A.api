using E4A.Api.Data;
using E4A.Api.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E4A.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicController : ControllerBase
    {
        public List<Music> Music { get; set; } = new List<Music>();
        private readonly Context _db;

        public MusicController(Context db)
        {
            _db = db;
        }
        private bool MusicExists(int? id)
        {
            return _db.Music.Any(e => e.Id == id);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody] Music model)
        {
            //book.Nota = model.Nota;
            //book.Autora = model.Autora;
            //book.Editora = model.Editora;
            //book.Descricao = model.Descricao;
            //book.ImageUrl = model.ImageUrl;
            //book.Visto = model.Visto;

            var music = new Music();
            _db.Music.Add(model);
            await _db.SaveChangesAsync();
            music.Validate();
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
            var music = await _db.Music.FindAsync(id);

            if (music == null)
            {
                return NotFound();
            }
            return music;
        }

        [HttpPut]
        public async Task<IActionResult> EditMusic(int? id, Music music)
        {
            if (id != music.Id)
            {
                return BadRequest();
            }

            _db.Entry(music).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MusicExists(id))
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
        public async Task<IActionResult> DeletMusic(int id)
        {
            var music = await _db.Music.FindAsync(id);
            if (music == null)
            {
                return NotFound();
            }

            _db.Music.Remove(music);
            await _db.SaveChangesAsync();

            return NoContent();
        }
    }
}
