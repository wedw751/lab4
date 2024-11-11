using BusinessLayer.Interfaces.BusinessLayer.interfaces;
using DataLayer;
using DataLayer.Entityes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLayer.Implementations
{
    public class NameTradesRepository : IBaseRepository<NameTrade>
    {
        _ApplicationContext _context;
        public NameTradesRepository(_ApplicationContext applicationContext)
        {
            _context = applicationContext;
        }
        public void Create(NameTrade item)
        {
            _context.NameTrades.Add(item);
            _context.SaveChanges();
        }

        public void Delete(int Id)
        {
            NameTrade NameTrades = _context.NameTrades.Find(Id);
            if (NameTrades != null)
                _context.NameTrades.Remove(NameTrades);
            _context.SaveChanges();
        }

        public IEnumerable<NameTrade> GetAll()
        {
            //return _context.NameTrades;
            return _context.NameTrades.Include(r => r.Preparations).ThenInclude(r => r.Provider);
        }

        public IQueryable<NameTrade> GetAll(string name)
        {
            return _context.NameTrades.Where(x => x.Name == name);
        }

        public NameTrade GetById(int Id)
        {
            return _context.NameTrades.FirstOrDefault(x => x.Id == Id);
        }

        public void Update(NameTrade item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
