using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Senai.Domain.Entidades
{
    public class Endereco : BaseEntity
    {
        [MaxLength(80)]
        [Required(ErrorMessage = "O campo é obrigatótio")]
        public string Rua { get; set; }
        [MaxLength(50)]
        [Required]
        public string Bairro { get; set; }
        [MaxLength(60)]
        [Required]
        public string Cidade { get; set; }
        [MaxLength(2)]
        [Required]
        public string Estado { get; set; }
        public int Numero { get; set; }
    }
}
