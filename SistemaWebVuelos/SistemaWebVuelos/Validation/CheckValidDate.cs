using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaWebVuelos.Validation
{
    public class CheckValidDate : ValidationAttribute
    {
        public CheckValidDate()
        {
            ErrorMessage = "La fecha debe ser actual o posterior";
        }

        // Si la fecha es menor a la fecha actual informar un mensaje de error. 
        public override bool IsValid(object value)
        {
            DateTime aux = (DateTime)value;

            if (aux < DateTime.Now)
            {
                return false;
            }

            return true;
        }
    }
}