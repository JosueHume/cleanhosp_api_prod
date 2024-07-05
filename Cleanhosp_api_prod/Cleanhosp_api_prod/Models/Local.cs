using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanHospAPI.Models
{
    public class Local
    {
        [Key]
        public int LocalId { get; set; }

        [Required]
        [StringLength(100)]
        public string Descricao { get; set; }

        [ForeignKey("Ala")]
        public int AlaId { get; set; }
    }
}
