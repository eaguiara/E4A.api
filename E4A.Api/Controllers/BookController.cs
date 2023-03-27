using E4A.Api.Entities;
using E4A.Api.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using E4A.Api.Data;

namespace E4A.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        public List<Book> Books { get; set; } = new List<Book>();
        private readonly Context _db;

        public BookController(Context db)
        {
            _db = db;
        }
        private bool BookExists(int? id)
        {
            return _db.Book.Any(e => e.Id == id);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody] Book model)
        {
            //book.Nota = model.Nota;
            //book.Autora = model.Autora;
            //book.Editora = model.Editora;
            //book.Descricao = model.Descricao;
            //book.ImageUrl = model.ImageUrl;
            //book.Visto = model.Visto;

            var book = new Book();
            _db.Book.Add(model);
            await _db.SaveChangesAsync();
            book.Validate();
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
            var book = await _db.Book.FindAsync(id);

            if (book == null)
            {
                return NotFound();
            }
            return book;
        }

        [HttpPut]
        public async Task<IActionResult> EditBook(int? id, Book book)
        {
            if (id != book.Id)
            {
                return BadRequest();
            }

            _db.Entry(book).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(id))
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
        public async Task<IActionResult> DeletBook(int id)
        {
            var book = await _db.Book.FindAsync(id);
            if(book == null)
            {
                return NotFound();
            }

            _db.Book.Remove(book);
            await _db.SaveChangesAsync();

            return NoContent();
        }
    }
}
