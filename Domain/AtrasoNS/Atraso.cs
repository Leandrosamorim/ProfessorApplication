using Domain.Models.JustificativaNS;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.AtrasoNS
{
    public class Atraso
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int AlunoId { get; set; }
        public DateTime Data { get; set; }
        public Justificativa? Justificativa { get; set; }
    }
}
