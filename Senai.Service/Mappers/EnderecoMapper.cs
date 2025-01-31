﻿using AutoMapper;
using Senai.Domain.DTOs;
using Senai.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Senai.Service.Mappers
{
    public class EnderecoMapper : Profile
    {
        public EnderecoMapper()
        {
            CreateMap<EnderecoDto, Endereco>()
                //.ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome));
                .ReverseMap();
        }

    }
}
