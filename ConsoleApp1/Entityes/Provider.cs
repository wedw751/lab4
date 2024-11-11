using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entityes
{
    public class Provider
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Telephone { get; set; }

        public List<Preparation> Preparations { get; set; }

        public Provider()
        {
            Preparations = new List<Preparation>();
        }
    }

}
