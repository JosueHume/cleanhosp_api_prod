using System.ComponentModel.DataAnnotations;

namespace CleanHospAPI.Models
{
    public class Ala
    {
        [Key]
        public int AlaId { get; set; }

        [Required]
        [StringLength(100)]
        public string Descricao { get; set; }
    }
}
