using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LocadoraDeCarros.Models
{
    public class Carro
    {

        public int Id { get; set; }

        public string Cor { get; set; }

        [Required]
        public string Placa { get; set; }

        [Required]
        [StringLength(255)]
        public string Marca { get; set; }

        [Required]
        [StringLength(255)]
        public string Modelo { get; set; }

        [Required]
        [Display(Name = "Valor de Locação")]
        public double? ValorLocacao { get; set; }

    }
}