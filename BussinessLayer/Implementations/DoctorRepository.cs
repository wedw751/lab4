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
    public class DoctorRepository : IBaseRepository<Doctor>
    {
        _ApplicationContext _context;
        public DoctorRepository(_ApplicationContext applicationContext)
        {
            _context = applicationContext;
        }
        public void Create(Doctor item)
        {
            _context.Doctors.Add(item);
            _context.SaveChanges();
        }

        public void Delete(int Id)
        {
            Doctor doctor = _context.Doctors.Find(Id);
            if (doctor != null)
                _context.Doctors.Remove(doctor);
            _context.SaveChanges();
        }

        public IEnumerable<Doctor> GetAll()
        {
            return _context.Doctors;
        }

        public IQueryable<Doctor> GetAll(string name)
        {
            return _context.Doctors.Where(x => x.Name == name);
        }

        public Doctor GetById(int Id)
        {
            return _context.Doctors.FirstOrDefault(x => x.Id == Id);
        }

        public void Update(Doctor item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
