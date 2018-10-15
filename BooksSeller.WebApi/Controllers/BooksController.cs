using BooksSeller.WebApi.Models;
using BooksSeller.WebApi.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace BooksSeller.WebApi.Controllers
{
    public class BooksController : ApiController
    {
        IBooksProvider _booksProvider = new BooksProvider();

        // GET: api/Books
        public async Task<IEnumerable<Book>> Get()
        {
            return await _booksProvider.GetBooks();
        }

        // GET: api/Books/5
        public async Task<Book> Get(int id)
        {
            return await _booksProvider.GetBook(id);
        }

        // POST: api/Books
        public async Task<IHttpActionResult> Post([FromBody]Book value)
        {
            if(await _booksProvider.SaveBook(value)) {
                return Ok();
            }
            return BadRequest();

        }

        // PUT: api/Books/5
        public async Task<IHttpActionResult> Put(int id, [FromBody]Book value)
        {
            if (await _booksProvider.SaveBook(id, value)) {
                return Ok();
            }
            return BadRequest();
        }

        // DELETE: api/Books/5
        public async Task<IHttpActionResult> Delete(int id)
        {
            if(await _booksProvider.DeleteBook(id)) {
                return Ok();
            }
            return BadRequest();
            
        }
    }
}
