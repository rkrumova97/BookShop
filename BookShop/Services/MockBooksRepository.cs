using BookShop.Models;
using BookShop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LittlePacktBookstore.Services
{
    public class MockBooksRepository : IRepository<Book>
    {
        List<Book> _books;
        public MockBooksRepository()
        {
            _books = new List<Book>() {
                new Book()
                {
                    Id = 0,
                    Title = "JavaScript and JSON Essentials",
                    Description = "Use JSON for building web applications with technologies like HTML, JavaScript, Angular, Node.js, Hapi.js, Kafka, socket.io, MongoDB, Gulp.js, and handlebar.js, and others formats like GEOJSON, JSON-LD, MessagePack, and BSON.",
                    Author = "Bruno Joseph D'mello, Sai Srinivas Sriparasa",
                    PublishDate = "April 2018",
                    Price = 30,
                    Image = "images (1).jpg"
                },
                new Book()
                {
                    Id = 1,
                    Title = "C# and .NET Core Test Driven Development",
                    Description = "Learn how to apply a test-driven development process by building ready C# 7 and .NET Core applications.",
                    Author = "Ayobami Adewole",
                    PublishDate = "May 2018",
                    Price = 25,
                    Image = "images (3).jpg"
                },
                new Book()
                {
                    Id = 2,
                    Title = "ASP.NET Core 2 and Angular 5",
                    Description = "Develop a simple, yet fully-functional modern web application using ASP.NET Core MVC, Entity Framework and Angular 5.",
                    Author = "Valerio De Sanctis",
                    PublishDate = "November 2017",
                    Price = 20,
                    Image = "images.jpg"
                }

            };
           
        }
        public bool Add(Book item)
        {
            try
            {
                Book book = item;
                book.Id = _books.Max(x => x.Id) + 1;
                _books.Add(book);
                return true;
            }
            catch (Exception)
            {
                //Log it here
                return false;
            }
        }

        public bool Delete(Book Item)
        {
            throw new NotImplementedException();
        }

        public bool Edit(Book item)
        {
            throw new NotImplementedException();
        }

        public Book Get(int id)
        {
            return _books.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Book> GetAll()
        {
            return _books.ToList();
        }

        public List<Book> GetAllByCarousel(int id)
        {
            throw new NotImplementedException();
        }
    }
}
