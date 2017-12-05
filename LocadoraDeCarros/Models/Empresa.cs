using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LocadoraDeCarros.Models
{
    public class Empresa
    {

        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "CNPJ")]
        public string Cnpj { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Nome da Empresa")]
        public string NomeEmpresa { get; set; }

        [Required]
        [Display(Name = "Número de Telefone")]
        public long? NumeroTelefone { get; set; }

        [Display(Name = "Endereço")]
        public string Endereco { get; set; }

        [Required]
        [Display(Name = "Capital Social")]
        public double? CapitalSocial { get; set; }


    }
}