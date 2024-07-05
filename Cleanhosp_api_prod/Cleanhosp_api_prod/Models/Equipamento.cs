using System;
using System.ComponentModel.DataAnnotations;

namespace CleanHospAPI.Models
{
    public class Equipamento
    {
        [Key]
        public int EquipamentoId { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required]
        [StringLength(100)]
        public string Marca { get; set; }

        [Required]
        [StringLength(100)]
        public string Modelo { get; set; }

        private DateTime _dataAquisicao;

        public DateTime DataAquisicao
        {
            get => _dataAquisicao;
            set => _dataAquisicao = DateTime.SpecifyKind(value, DateTimeKind.Utc);
        }

        [Required]
        [StringLength(100)]
        public string Descricao { get; set; }

        [Required]
        public decimal ValorAquisicao { get; set; }

        public bool Ativo { get; set; }
    }
}
