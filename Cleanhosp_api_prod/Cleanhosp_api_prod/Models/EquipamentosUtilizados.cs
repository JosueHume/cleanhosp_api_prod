using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanHospAPI.Models
{
    public class EquipamentosUtilizados
    {
        [Key]
        public int EquipamentosUtilizadosId { get; set; }

        public int TempoUsoEmMinutos { get; set; }

        [ForeignKey("Equipamento")]
        public int EquipamentoId { get; set; }

        public Equipamento Equipamento { get; set; }

        [ForeignKey("LimpezaAndamento")]  // Chave estrangeira para LimpezaAndamento
        public int LimpezaAndamentoId { get; set; }

        public LimpezaAndamento LimpezaAndamento { get; set; }
    }
}
