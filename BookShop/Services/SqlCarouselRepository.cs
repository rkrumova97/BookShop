﻿using BookShop.Data;
using BookShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Services
{
    public class SqlCarouselRepository:IRepository<Carousel>
    {
        private BookShopDbContext _context;

        public SqlCarouselRepository(BookShopDbContext context)
        {
            _context = context;
        }
        public bool Add(Carousel item)
        {
            try
            {
                _context.Add(item);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(Carousel Item)
        {
            try
            {
                Carousel book = Get(Item.Id);
                if (book != null)
                {
                    _context.Remove(Item);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Edit(Carousel item)
        {
            throw new NotImplementedException();
        }

        public Carousel Get(int id)
        {
            if (_context.Carousels.Count(x => x.Id == id) > 0)
            {
                return _context.Carousels.FirstOrDefault(x => x.Id == id);
            }
            return null;
        }

        public IEnumerable<Carousel> GetAll()
        {
            return _context.Carousels;
        }

        public List<Carousel> GetAllByCarousel(int id)
        {
            throw new NotImplementedException();
        }
    }
}