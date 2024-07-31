using Senai.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Senai.Service.Interfaces
{
    public interface IEstadoService
    {
        Task<List<EstadoDto>> BuscarEstados();
        Task<List<CidadeDto>> BuscarCidades(int estadoId);

    }

}
