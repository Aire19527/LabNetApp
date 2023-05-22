using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Domain.Dto.Profile
{
    public class ProfilesDto
    {
        public ProfileDto Profile { get; set; }

        public int? Key { get; set; }

        public int Count { get; set; }
    }
}
