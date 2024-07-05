using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanHospAPI.Models
{
    public class ProdutosUtilizados
    {
        [Key]
        public int ProdutosUtilizadosId { get; set; }

        public int Quantidade { get; set; }

        [ForeignKey("Produto")]
        public int ProdutoId { get; set; }

        public Produto Produto { get; set; }

        [ForeignKey("LimpezaAndamento")]  // Chave estrangeira para LimpezaAndamento
        public int LimpezaAndamentoId { get; set; }

        public LimpezaAndamento LimpezaAndamento { get; set; }
    }
}
