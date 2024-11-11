using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.DoctorEntities
{
    public class DoctorVm
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }

}
