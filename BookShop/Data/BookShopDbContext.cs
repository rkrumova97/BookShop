using BookShop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Data
{
    public class BookShopDbContext:DbContext
    {
        public BookShopDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Carousel> Carousels { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }

        

  
    }
}
