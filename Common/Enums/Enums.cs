using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Enums
{
    public class Enums
    {
        public enum Country
        {
            //Country
            Argentina = 1,

            Colombia = 2,
        }
        public enum Province
        {
            //Province
            BuenosAires = 1,
            Tucuman = 2,
            Cordoba = 3,
            SantaFe = 4,
            EntreRios = 5,
            Bogota = 6,
            Medellin = 7,
        }
        public enum City
        {
            //Province
            Quilmes = 1,
            Ezpeleta = 2,
            Ciudad3 = 3,
            Ciudad4 = 4,
            Ciudad5 = 5,
            Ciudad6 = 6,
            Ciudad7 = 7,
        }
        public enum Role
        {
            //Role
            Admin = 1,
            Recruiter = 2,
            User = 3
        }
    }
}
