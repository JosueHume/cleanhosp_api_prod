using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanHospAPI.Models
{
    public class LimpezaAndamento
    {
        [Key]
        public int LimpezaAndamentoId { get; set; }

        [Required]
        [ForeignKey("Local")]
        public int LocalId { get; set; }

        public Local Local { get; set; }

        [Required]
        [ForeignKey("Pessoa")]
        public int PessoaId { get; set; }

        public Pessoa Pessoa { get; set; }

        public DateTime? DataInicio { get; set; }

        public DateTime? DataFim { get; set; }

        [Required]
        [ForeignKey("Limpeza")]
        public int LimpezaId { get; set; }

        public Limpeza Limpeza { get; set; }

        public List<ProdutosUtilizados> ProdutosUtilizados { get; set; }
        public List<EquipamentosUtilizados> EquipamentosUtilizados { get; set; }

        [Required]
        [StringLength(100)]
        public string Descricao { get; set; }

        public bool Finalizado { get; set; }
    }

}
