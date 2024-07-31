using Senai.Domain.DTOs;
using Senai.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Senai.Service.Interfaces
{
    public interface IEscolaService
    {
        bool Salvar(EscolaDto model);
        List<Escola> BuscarTodos();
        bool Remover(long id);
        //Escola? BuscarPorId(long id);
        //List<Escola> BuscarTodos();
    }
}
