using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    using DataLayer.Entityes;
    using global::BusinessLayer.Interfaces.BusinessLayer.interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    namespace BusinessLayer.interfaces
    {
        public interface IBaseRepository<T> where T : class
        {
            IEnumerable<T> GetAll();
            T GetById(int Id);
            void Create(T item);
            void Update(T item);
            void Delete(int Id);
        }

        public interface IBaseExtraRepository<T> : IBaseRepository<T> where T : class
        {
            public void Create(T item, int Id);
        }
    }
}
