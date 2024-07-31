using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Senai.Domain.Entidades
{
    public class Escola : BaseEntity
    {
        [MaxLength(60)]
        [Required(ErrorMessage = "O campo é obrigatótio")]
        public string Nome { get; set; }
        public Endereco Endereco { get; set; }

    }
}
