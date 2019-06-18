using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShop.Models;
using BookShop.Services;
using BookShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Controllers
{
    public class HomeController : Controller
    {
        //List<Book> _book;
        IRepository<Order> _orderRepo;
        IRepository<Book> _bookRepo;
        IRepository<Carousel> _CarouselRepo;

        public HomeController(IRepository<Book> book, IRepository<Carousel> carousel, IRepository<Order> order)
        {
            //_book = new List<Book>();
            _bookRepo = book;
            _CarouselRepo = carousel;
            _orderRepo = order;
        }

        //The home page
        public IActionResult Index()
        {
            HomeIndexViewModel model = new HomeIndexViewModel()
            {
                Books = _bookRepo.GetAll(),
                Carousels = _CarouselRepo.GetAll()
            };
            return View(model);
        }

        [HttpGet]
        public IActionResult AddBook()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddBook(Book book)
        {
            if (ModelState.IsValid)
            {
                Book item = new Book()
                {
                    Id = _bookRepo.GetAll().Max(m => m.Id) + 1,
                    Title = book.Title,
                    Description = book.Description,
                    Author = book.Author,
                    PublishDate = book.PublishDate,
                    Price = book.Price,
                    Image = book.Image
                };
                _bookRepo.Add(item);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        //The about page
        public IActionResult About()
        {
            return View();
        }

        //The contact us page
        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            Book book = _bookRepo.Get(id);
            return View(book);
        }

        [HttpGet]
        public IActionResult Order(int? id)
        {
            if (id != null && id >= 0)
            {
                OrderViewModel model = new OrderViewModel()
                {
                    BookToOrder = _bookRepo.Get((int)id),
                    OrderDetails = new Order
                    {
                        BookId = (int)id
                    }
                };

                return View(model);
            }
            return View();
        }

        [HttpPost]
        public IActionResult Order(int id, Order orderDetails)
        {
            if (ModelState.IsValid)
            {
                if(_bookRepo.GetAll().Count(x => x.Id == orderDetails.BookId) >= 0)
                {
                    orderDetails.BookId = id;
                    _orderRepo.Add(orderDetails);
                    return RedirectToAction("ThankYou");
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return View(new OrderViewModel()
                {
                   OrderDetails = orderDetails,
                   BookToOrder = _bookRepo.Get(id)
                });
            }
        }

        public IActionResult ThankYou()
        {
            return View();
        }

        public IActionResult OrderList()
        {
            return View(_orderRepo.GetAll());
        }
        public IActionResult BookList(int id)
        {
            return View(_bookRepo.GetAllByCarousel(id));
        }

        public IActionResult Login()
        {
            return View();
        }
    }
}