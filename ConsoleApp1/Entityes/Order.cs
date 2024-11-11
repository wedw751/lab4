using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entityes
{
    public class Order
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int UserId { get; set; }

        public List<OrderPreparation> OrderPreparation { get; set; }

        public Order()
        {
            OrderPreparation = new List<OrderPreparation>();
        }
    }

}
