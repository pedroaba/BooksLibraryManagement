using BooksLibraryManagement.Communication.Request;
using BooksLibraryManagement.Communication.Response;
using BooksLibraryManagement.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BooksLibraryManagement.Controllers;

public class BookController : BooksLibraryManagementBaseController
{
    public static List<Book> books = new();

    [HttpPost]
    [ProducesResponseType(typeof(ResponseBookCreateJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(BadResponseMessage), StatusCodes.Status400BadRequest)]
    public IActionResult Create([FromBody] RequestBookCreateJson request)
    {
        if (request.Price <= 0)
        {
            return BadRequest(new BadResponseMessage()
            {
                Message = "Invalid Price!"
            });
        }

        if (request.QuantityInStock <= 0)
        {
            return BadRequest(new BadResponseMessage()
            {
                Message = "Invalid Quantity in stock"
            });
        }

        var book = new Book()
        {
            Id = books.Count + 1,
            Title = request.Title,
            Author = request.Author,
            Genre = request.Genre,
            Price = request.Price,
            QuantityInStock = request.QuantityInStock,
        };

        books.Add(book);

        var response = new ResponseBookCreateJson()
        {
            Id = book.Id,
        };

        return Created(string.Empty, response);
    }

    [HttpGet]
    [ProducesResponseType(typeof(ResponseBookGetAll), StatusCodes.Status200OK)]
    public IActionResult GetAll()
    {
        var response = new ResponseBookGetAll()
        {
            books = books
        };

        return Ok(response);
    }

    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(NotFoundResponseMessage), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(BadResponseMessage), StatusCodes.Status400BadRequest)]
    public IActionResult UpdateById([FromRoute] int id, [FromBody] RequestBookUpdateJson request) 
    {
        if (request.Price <= 0)
        {
            return BadRequest(new BadResponseMessage()
            {
                Message = "Invalid Price!"
            });
        }

        if (request.QuantityInStock <= 0)
        {
            return BadRequest(new BadResponseMessage()
            {
                Message = "Invalid Quantity in stock"
            });
        }

        var bookIndex = books.FindIndex(book => book.Id == id);
        if (bookIndex == -1)
        {
            return NotFound(new NotFoundResponseMessage()
            {
                Message = $"Not found book with id: {id}"
            });
        }

        books[bookIndex].QuantityInStock = request.QuantityInStock;
        books[bookIndex].Price = request.Price;
        books[bookIndex].Title = request.Title;

        return NoContent();
    }

    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(NotFoundResponseMessage), StatusCodes.Status404NotFound)]
    public IActionResult DeleteById([FromRoute] int id)
    {
        var bookIndex = books.FindIndex(book => book.Id == id);
        if (bookIndex == -1)
        {
            return NotFound(new NotFoundResponseMessage()
            {
                Message = $"Not found book with id: {id}"
            });
        }

        books.RemoveAt(bookIndex);

        return NoContent();
    }
}
