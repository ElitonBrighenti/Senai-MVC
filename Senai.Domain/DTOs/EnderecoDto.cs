using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Senai.Domain.DTOs
{
    public  class EnderecoDto
    {
        [Required(ErrorMessage = "O campo rua é obrigatorio")]
        public long Id { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public int Numero { get; set; }

    }
}
