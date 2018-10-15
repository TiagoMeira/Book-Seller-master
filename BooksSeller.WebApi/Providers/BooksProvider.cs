using BooksSeller.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace BooksSeller.WebApi.Providers
{
    public class BooksProvider : IBooksProvider
    {
        public static string ConnectionDB = ConfigurationManager.ConnectionStrings["BancoLocal"].ToString();

        Book IBooksProvider.Create() {
            Book newBook = new Book();

            return newBook;
        }
        public async Task<Book> GetBook(int id) {
            Book currentBook = new Book();

            try {
                using (SqlConnection conn = new SqlConnection(ConnectionDB)) {
                    using (SqlCommand query = new SqlCommand("SELECT * FROM book WHERE Id = @id", conn)) {
                        await conn.OpenAsync();

                        query.CommandType = CommandType.Text;
                        query.Parameters.AddWithValue("@id", id);

                        using (SqlDataReader dr = await query.ExecuteReaderAsync()) {
                            while (await dr.ReadAsync()) {
                                double Price = 0.0;
                                int Id = 0;

                                Double.TryParse(dr["Price"].ToString(), out Price);
                                int.TryParse(dr["Id"].ToString(), out Id);

                                currentBook.Id          = Id;
                                currentBook.Code        = dr["Code"].ToString();
                                currentBook.Title       = dr["Title"].ToString();
                                currentBook.ReleaseDate = dr["ReleaseDate"].ToString();
                                currentBook.Price = Price;
                            }
                        }
                    }
                }
            }
            catch (Exception ex) {

            }
            return currentBook;
        }
        async Task<List<Book>> IBooksProvider.GetBooks() {
            List<Book> allBooks = new List<Book>();

            try {
                using (SqlConnection conn = new SqlConnection(ConnectionDB)) {
                    using (SqlCommand query = new SqlCommand("SELECT * FROM book", conn)) {
                        await conn.OpenAsync();

                        query.CommandType = CommandType.Text;
                        
                        using (SqlDataReader dr = await query.ExecuteReaderAsync()) {
                            while(await dr.ReadAsync()) {
                                double Price = 0.0;
                                int Id = 0;

                                Double.TryParse(dr["Price"].ToString(), out Price);
                                int.TryParse(dr["Id"].ToString(), out Id);

                                allBooks.Add(new Book {
                                    Id          = Id,
                                    Code        = dr["Code"].ToString(),
                                    Title       = dr["Title"].ToString(),
                                    ReleaseDate = dr["ReleaseDate"].ToString(),
                                    Price       = Price

                                });
                            }
                        }
                    }
                }
            }
            catch (Exception) {
                allBooks = null;

                return allBooks;
            }
            return allBooks;
        }
        async Task<bool> IBooksProvider.SaveBook(Book book) {
            try {
                using (SqlConnection conn = new SqlConnection(ConnectionDB)) {
                    using (SqlCommand query = new SqlCommand("INSERT INTO book(Code, Title, ReleaseDate, Price)" +
                                                             "VALUES(@code, @title, @date, @price)", conn)) {
                        await conn.OpenAsync();

                        query.CommandType = CommandType.Text;
                        query.Parameters.AddWithValue("@code", book.Code);
                        query.Parameters.AddWithValue("@title", book.Title);
                        query.Parameters.AddWithValue("@date", book.ReleaseDate);
                        query.Parameters.AddWithValue("@price", book.Price);

                        using (SqlDataReader dr = await query.ExecuteReaderAsync()) { }
                    }
                }
            }
            catch(Exception) { return false; }

            return true;
        }
        async Task<bool> IBooksProvider.SaveBook(int id, Book book) {
            try {
                using (SqlConnection conn = new SqlConnection(ConnectionDB)) {
                    using (SqlCommand query = new SqlCommand("UPDATE book SET Code = @code, Title = @title, ReleaseDate = @date, Price = @price " +
                                                             "WHERE Id = @id", conn)) {
                        await conn.OpenAsync();

                        query.CommandType = CommandType.Text;
                        query.Parameters.AddWithValue("@code", book.Code);
                        query.Parameters.AddWithValue("@title", book.Title);
                        query.Parameters.AddWithValue("@date",  book.ReleaseDate);
                        query.Parameters.AddWithValue("@price", book.Price);
                        query.Parameters.AddWithValue("@Id", id);

                        using (SqlDataReader dr = await query.ExecuteReaderAsync()) { }
                    }
                }
            }
            catch (Exception) { return false; }

            return true;
        }
        async Task<bool> IBooksProvider.DeleteBook(int id) {
            try {
                using (SqlConnection conn = new SqlConnection(ConnectionDB)) {
                    using (SqlCommand query = new SqlCommand("DELETE FROM book WHERE Id = @id", conn)) {
                        await conn.OpenAsync();

                        query.CommandType = CommandType.Text;
                        query.Parameters.AddWithValue("@Id", id);

                        using (SqlDataReader dr = await query.ExecuteReaderAsync()) { }
                    }
                }
            }
            catch (Exception) { return false;  }

            return true;
        }
    }
}