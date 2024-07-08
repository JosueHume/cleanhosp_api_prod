using System;
using System.ComponentModel.DataAnnotations;

namespace CleanHospAPI.Models
{
    public class LimpezaAndamento
    {
        [Key]
        public int LimpezaAndamentoId { get; set; }

        public int LocalId { get; set; }  

        public int PessoaId { get; set; }

        public int LimpezaId { get; set; }

        public int EquipamentoId { get; set; }

        public int ProdutoId { get; set; }

        public DateTime? DataInicio { get; set; }

        public DateTime? DataFim { get; set; }

        [Required]
        [StringLength(100)]
        public string Descricao { get; set; }

        public bool Finalizado { get; set; }
    }
}
