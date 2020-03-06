using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ModelLib;
using static ModelLib.Book;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestAssignment4.Controllers
{
    [Route("api/[controller]")]
    public class BooksController : Controller
    {
        public static List<Book> list = new List<Book>()
        {
            new Book("book1", "author1", 100, "1234567890abc"),
            new Book("book2", "author2", 200, "1234567890def"),
            new Book("book3", "author3", 300, "1234567890ghi"),
            new Book("book4", "author4", 400, "1234567890jkl")
        };

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return list;
        }

        // GET api/<controller>/5
        [HttpGet("{isbn}")]
        public Book Get(string isbn)
        {
            return list.Find(i => i.ISBN13 == isbn);
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]Book value)
        {
            list.Add(value);
        }

        // PUT api/<controller>/5
        [HttpPut("{isbn}")]
        public void Put(string isbn, [FromBody]Book value)
        {
            Book b = Get(isbn);
            if (b != null)
            {
                b.Forfatter = value.Forfatter;
                b.Title = value.Title;
                b.Sidetal = value.Sidetal;
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete("{isbn}")]
        public void Delete(string isbn)
        {
            list.Remove(Get(isbn));
        }
    }
}
