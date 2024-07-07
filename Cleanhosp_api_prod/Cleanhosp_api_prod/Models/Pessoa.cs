﻿using System.ComponentModel.DataAnnotations;

namespace CleanHospAPI.Models
{
    public enum TipoUsuario
    {
        Administrador = 1,
        Usuario = 2
    }

    public class Pessoa
    {
        [Key]
        public int PessoaId { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required]
        [StringLength(100)]
        public string CPF { get; set; }

        [StringLength(20)]
        public string Telefone { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(100)]
        public string Login { get; set; }

        [Required]
        [StringLength(100)]
        public string Senha { get; set; }

        [Required]
        public TipoUsuario Tipo { get; set; }
    }
}
