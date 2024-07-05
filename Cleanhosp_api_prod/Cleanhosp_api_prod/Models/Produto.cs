using System.ComponentModel.DataAnnotations;

namespace CleanHospAPI.Models
{
    public class Produto
    {
        [Key]
        public int ProdutoId { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required]
        [StringLength(100)]
        public string Marca { get; set; }

        [Required]
        [StringLength(100)]
        public string Descricao { get; set; }

        public int QtdeEstoque { get; set; }

        [Required]
        public decimal ValorUnitario { get; set; }
    }
}
