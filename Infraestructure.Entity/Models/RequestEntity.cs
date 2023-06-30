﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Entity.Models
{
    [Table("Request")]
    public class RequestEntity
    {
        [Key]
        public int Id { get; set; }
        public int TimeInMinutes { get; set; }
        [Required]
        public string Degree { get; set; }
        public DateTime CreationDate { get; set; }
        public int PercentageMinimoRerequired { get; set; }
        public IEnumerable<DetailRequirementEntity> DetailRequirementEntity { get; set; }
    }
}