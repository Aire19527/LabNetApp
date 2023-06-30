using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Entity.Models
{
    [Table("RequirementQuestion")]
    public class RequirementQuestionEntity
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Request")]
        public int IdRequest { get; set; }
        public RequestEntity RequestEntity { get; set; }

        [ForeignKey("Question")]
        public int IdQuestion { get; set; }
        public QuestionEntity QuestionEntity { get; set; }
    }
}
