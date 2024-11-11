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
    public class PreparationRepositoty : IBaseExtraRepository<Preparation>
    {
        _ApplicationContext _context;
        public PreparationRepositoty(_ApplicationContext applicationContext)
        {
            _context = applicationContext;
        }

        public void Create(Preparation item)
        {
            _context.Preparations.Add(item);
            _context.SaveChanges();
        }

        public void Create(Preparation item, int providerId)
        {
            _context.Preparations.Add(item);
            _context.SaveChanges();
        }

        public void Delete(int Id)
        {
            Preparation doctor = _context.Preparations.Find(Id);
            if (doctor != null)
                _context.Preparations.Remove(doctor);
            _context.SaveChanges();
        }

        public IEnumerable<Preparation> GetAll()
        {
            //return _context.Preparations;
            return _context.Preparations.Include(r => r.Provider).Include(r => r.NameTrade);
        }

        public IQueryable<Preparation> GetAll(string name)
        {
            return _context.Preparations.Where(x => x.Name == name);
        }

        public Preparation GetById(int Id)
        {
            return _context.Preparations.FirstOrDefault(x => x.Id == Id);
        }

        public void Update(Preparation item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
