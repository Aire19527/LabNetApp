using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Entity.Models
{
    [Table("File")]
    public class FileEntity 
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FileName { get; set; }

        [Required]
        public string Url { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        public QuestionEntity QuestionEntity { get; set; }
        public AnswerEntity AnswerEntity { get; set; }
    }
}
