using BOOK_API_APP.Configuration;
using BOOK_API_APP.Model;
using BOOK_API_APP.services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.Net;
using System.Runtime.InteropServices;

namespace BOOK_API_APP.Controllers
{
    [Route("Book")]
    [ApiController]
    public class BookController : ControllerBase
    {


        private readonly IBookServices bookservice;
        public BookController(IBookServices bookService) =>
            this.bookservice = bookService;
        [HttpGet]
        public async Task<List<BookDetails>> Get()
        {
            return await bookservice.BookListAsync();
        }


        [HttpGet]
        [Route("GetByID")]
        public async Task<ActionResult<BookDetails>> Get(string BookId)
        {
            var bookDetails = await bookservice.GetBookDetailsByIdAsync(BookId);
            if (bookDetails is null)
            {
                return NotFound();
            }
            return bookDetails;
        }


        [HttpPost]
        public async Task<IActionResult> Post(BookDetails bookDetails)
        {
            await bookservice.AddBookAsync(bookDetails);
            return CreatedAtAction(nameof(Get), new { id = bookDetails.Id }, bookDetails);
        }

        [HttpPut]
        public async Task<IActionResult> Update(string BookId, BookDetails bookDetails)
        {
            var productDetail = await bookservice.GetBookDetailsByIdAsync(BookId);
            if (productDetail is null)
            {
                return NotFound();
            }
            bookDetails.Id = productDetail.Id;
            await bookservice.UpdateBookAsync(BookId, bookDetails);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string BookId)
        {
            var productDetails = await bookservice.GetBookDetailsByIdAsync(BookId);
            if (productDetails is null)
            {
                return NotFound();
            }
            await bookservice.DeleteBookAsync(BookId);
            return Ok();
        }
    }
}
