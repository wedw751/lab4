using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.TradeNameEntities
{
    public class TradeNameVm
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }

}
