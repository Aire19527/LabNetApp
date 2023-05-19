using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Exceptions
{
    public class DuplicatedSkillException : Exception
    {
        public DuplicatedSkillException() : base("No se puede insertar un registro duplicado")
        {
        }
    }
}
