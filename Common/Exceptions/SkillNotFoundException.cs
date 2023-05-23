using Common.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Exceptions
{
    public class SkillNotFoundException : Exception
    {
        public SkillNotFoundException() : base(GeneralMessages.ItemNoFound){ }

        public SkillNotFoundException(string message) : base(message) { }
    }
}
