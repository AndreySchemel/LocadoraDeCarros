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
        public string Cnpj { get; set; }

        [Required]
        [StringLength(255)]
        public string NomeEmpresa { get; set; }

        [Required]
        public long NumeroTelefone { get; set; }

        public string Endereco { get; set; }

        [Required]
        public double CapitalSocial { get; set; }

        public bool TipoEmpresa { get; set; }

    }
}