using BooksSeller.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace BooksSeller.WebApi.Providers
{
    public interface IBooksProvider
    {
        Book Create();

        Task<Book> GetBook(int id);

        Task<List<Book>> GetBooks();

        Task<bool> SaveBook(Book book);

        Task<bool> SaveBook(int id, Book book);

        Task<bool> DeleteBook(int id);
    }
}