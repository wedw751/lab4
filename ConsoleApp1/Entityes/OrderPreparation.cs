using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entityes
{
    public class OrderPreparation
    {
        public int OrderId { get; set; }
        public Order Order { get; set; }

        public int PreparationId { get; set; }
        public Preparation Preparation { get; set; }
    }

}
