using System.ComponentModel.DataAnnotations;

namespace CleanHospAPI.Models
{
    public class Limpeza
    {
        [Key]
        public int LimpezaId { get; set; }

        [Required]
        [StringLength(100)]
        public string Descricao { get; set; }
    }
}
