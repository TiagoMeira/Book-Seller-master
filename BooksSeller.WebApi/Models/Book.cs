using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BooksSeller.WebApi.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public string ReleaseDate { get; set; }
        public double Price { get; set; }
    }
}