using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Common.Helpers
{
    public class ValidPasswordAttribute:ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string password = (string)value;

            if (string.IsNullOrEmpty(password))
            {
                return false;
            }

            // Validar longitud mínima de 8 caracteres
            if (password.Length < 8)
            {
                return false;
            }

            // Validar al menos una mayúscula, una minúscula, un número y un carácter especial
            var regex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$");

            return regex.IsMatch(password);
        }

    }
}
