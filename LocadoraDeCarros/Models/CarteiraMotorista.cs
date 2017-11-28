using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LocadoraDeCarros.Models
{
    public class CarteiraMotorista : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var cliente = (Cliente)validationContext.ObjectInstance;

            return (cliente.NumeroCNH != null && cliente.NumeroCNH.Length == 8) ? ValidationResult.Success
             : new ValidationResult("O cliente deve ter o numero do CNH registrado");

        }

    }
}