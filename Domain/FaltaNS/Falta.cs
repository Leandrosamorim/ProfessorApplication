using Domain.Models.JustificativaNS;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.FaltaNS
{
    public class Falta
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int AlunoId { get; set; }
        public DateTime Data { get; set; }
        public Justificativa? Justificativa {get;set;}
    }
}
