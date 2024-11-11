using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entityes
{
    public class Preparation
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
        public decimal Price { get; set; }

        public int ProviderId { get; set; }
        public Provider Provider { get; set; }

        public int NameTradeId { get; set; }
        public NameTrade NameTrade { get; set; }
    }

}
