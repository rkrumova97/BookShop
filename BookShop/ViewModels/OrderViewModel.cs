using BookShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.ViewModels
{
    public class OrderViewModel
    {
        public Book BookToOrder { get; set; }
        public Order OrderDetails { get; set; }
    }
}
