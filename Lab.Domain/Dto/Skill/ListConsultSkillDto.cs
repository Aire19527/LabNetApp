using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Domain.Dto.Skill
{
    public class ListConsultSkillDto
    {
        [Required]
        public IEnumerable<ConsultSkllDto> Skills { get; set; }
    }
}
