using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.PreparationEnitities
{
    public class PreparationVm
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int? OrderId { get; set; }

        [Required]
        [Display(Name = "Provider")]
        public int ProviderId { get; set; }

        [Required]
        [Display(Name = "Trade Name")]
        public int TradeNameId { get; set; }

        public string TradeNameDisp { get; set; }
        public string ProviderDisp { get; set; }
    }

}
