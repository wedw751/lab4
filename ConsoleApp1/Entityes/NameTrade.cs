using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entityes
{
    public class NameTrade
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Preparation> Preparations { get; set; }

        public NameTrade()
        {
            Preparations = new List<Preparation>();
        }
    }

}
