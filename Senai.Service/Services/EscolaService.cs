using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Senai.Domain.DTOs;
using Senai.Domain.Entidades;
using Senai.Domain.Interfaces;
using Senai.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Senai.Service.Services
{
    public class EscolaService : IEscolaService
    {
        private readonly IMapper _mapper;
        private readonly IEscolaRepository _escolaRepository;

        public EscolaService(IEscolaRepository escolaRepository, IMapper mapper)
        {
            _mapper = mapper;
            _escolaRepository = escolaRepository;
        }

        public bool Salvar(EscolaDto model)
        {
            var entidade = _mapper.Map<Escola>(model);
            return _escolaRepository.Salvar(entidade);
        }
        public List<Escola> BuscarTodos()
        {
            return _escolaRepository.BuscarTodos();
        }

        public bool Remover(long id)
        {
            return _escolaRepository.Remover(id);
        }

        //public Escola? BuscarPorId(long id)
        //{
        //    return _escolaRepository.BuscarPorId(id);
        //}
        //public List<Escola> BuscarTodos()
        //{
        //    return _escolaRepository.BuscarTodos().ToList();
        //}

    }
}
