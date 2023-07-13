using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Entity.Models
{
    [Table("AssessmentUser")]
    public class AssessmentUserEntity
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("UserEntity")]
        public int IdUser { get; set; }
        public UserEntity UserEntity { get; set; }

        [ForeignKey("RequestEntity")]
        public int IdRequest { get; set; }
        public RequestEntity RequestEntity { get; set; }
        public DateTime CreationDate { get; set; }
        public decimal PointsObtained { get; set; }
        public int PointsMaximum { get; set; }
        public decimal PercentageObtained { get; set; }
        public bool Approved { get; set; }

        public IEnumerable<AssessmentQuestionEntity> AssessmentQuestionEntities { get; set; }
    }
}