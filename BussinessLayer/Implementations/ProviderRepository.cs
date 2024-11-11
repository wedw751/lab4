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
    public class ProviderRepository : IBaseRepository<Provider>
    {
        _ApplicationContext _context;
        public ProviderRepository(_ApplicationContext applicationContext)
        {
            _context = applicationContext;
        }

        public void Create(Provider item)
        {
            _context.Providers.Add(item);
            _context.SaveChanges();
        }

        public void Delete(int Id)
        {
            Provider provider = _context.Providers.Find(Id);
            if (provider != null)
                _context.Providers.Remove(provider);
            _context.SaveChanges();
        }

        public IEnumerable<Provider> GetAll()
        {
            return _context.Providers.Include(r => r.Preparations).ThenInclude(r => r.NameTrade);
            //return _context.Providers;
        }

        public IQueryable<Provider> GetAll(string name)
        {
            return _context.Providers.Where(x => x.Name == name);
        }

        public Provider GetById(int Id)
        {
            return _context.Providers.FirstOrDefault(x => x.Id == Id);
        }

        public void Update(Provider item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
