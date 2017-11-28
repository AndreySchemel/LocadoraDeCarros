using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LocadoraDeCarros.Models
{
    public class Cliente
    {

        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Nome { get; set; }

        [Required]
        [StringLength(255)]
        public string CPF { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string RG { get; set; }

        public long Telefone { get; set; }

        [Required]
        [CarteiraMotorista]
        public string NumeroCNH { get; set; }

        //propriedade de navegação
        public Carro Carro { get; set; }

        //chave estrangeira
        public int CarroId { get; set; }

    }
}