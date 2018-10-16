using BooksSeller.WebApi.Models;
using BooksSeller.WebApi.Providers;
using System.Threading.Tasks;
using System.Web.Http;

namespace BooksSeller.WebApi.Controllers
{
    public class BooksController : ApiController
    {
        private readonly IBooksProvider _booksProvider = new BooksProvider();

        //private readonly IBooksProvider _booksProvider
        //private BooksProvider books;

        //public BooksController(IBooksProvider _books) {
            //_booksProvider = _books;
        //}
             
        // GET: api/Books
        public async Task<IHttpActionResult> Get()
        {
            var result =  await _booksProvider.GetBooks();

            if(result == null) {
                return NotFound();
            }
            return Ok(result);
        }

        // GET: api/Books/5
        public async Task<IHttpActionResult> Get(int id)
        {
            var result =  await _booksProvider.GetBook(id);

            if (result == null) {
                return NotFound();
            }
            return Ok(result);
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
