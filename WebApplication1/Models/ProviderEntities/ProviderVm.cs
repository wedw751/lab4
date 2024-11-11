using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.ProviderEntities
{
    public class ProviderVm
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        public string Telephone { get; set; }
    }

}
