using Class03.Homework.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Class03.Homework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Book>> GetAllBooks()
        {
            try
            {
                return Ok(StaticDb.Books);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error occurred");
            }
        }

        [HttpGet("oneBook")]
        public ActionResult<List<Book>> OneBook(int? index)
        {
            try
            {
                if (index == null)
                {
                    return BadRequest("You are required to indicate the index");
                }

                if (index < 0)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "The index can not be negative");
                }

                Book bookDb = StaticDb.Books.FirstOrDefault(x => x.Id == index);
                return Ok(bookDb);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error occurred");
            }
        }

        [HttpGet("filterByTitleOrAuthor")]
        public ActionResult<List<Book>> FilterBook(string? title, string? author)
        {
            try
            {
                if(string.IsNullOrEmpty(title)) 
                {
                    List<Book> bookDb = StaticDb.Books.Where(x => x.Author.ToLower().Contains(author.ToLower())).ToList();
                    return Ok(bookDb);
                }

                if (string.IsNullOrEmpty(author))
                {
                    List<Book> bookDb = StaticDb.Books.Where(x => x.Title.ToLower().Contains(title.ToLower())).ToList();
                    return Ok(bookDb);
                }

                List<Book> filteredBooks = StaticDb.Books.Where(x => x.Title.ToLower().Contains(title.ToLower()) && x.Author.ToLower().Contains(author.ToLower())).ToList();
                return Ok(filteredBooks);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error occurred");
            }
        }

        [HttpPost]
        public IActionResult AddBook([FromBody] Book book)
        {
            try
            {
                if (string.IsNullOrEmpty(book.Title))
                {
                    return BadRequest("You need to provide a title");
                }

                if (string.IsNullOrEmpty(book.Author))
                {
                    return BadRequest("You need to provide the author");
                }

                StaticDb.Books.Add(book);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error occurred");
            }
        }

        [HttpPost("listOfBooks")]
        public IActionResult listOfBookTitle([FromBody] List<Book> books)
        {
            try
            {
                if(books == null || books.Count == 0)
                {
                    return BadRequest("There is no books");
                }

                List<string> bookTitles = books.Select(x => x.Title).ToList();
                return Ok(bookTitles);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error occurred");
            }
        }
    }
}
