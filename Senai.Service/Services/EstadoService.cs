using Senai.Domain.DTOs;
using Senai.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Senai.Service.Services
{
    public  class EstadoService : IEstadoService
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        public EstadoService() { }

        public async Task<List<EstadoDto>> BuscarEstados()
        {
            var url = "https://servicodados.ibge.gov.br/api/v1/localidades/estados";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Erro ao buscar os estados no IBGE.");
            }

            var content = await response.Content.ReadAsStringAsync();
            var estados = JsonSerializer.Deserialize<List<EstadoDto>>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            return estados;

        }
        public async Task<List<CidadeDto>> BuscarCidades(int estadoId)
        {
            var url = $"https://servicodados.ibge.gov.br/api/v1/localidades/estados/{estadoId}/municipios";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Erro ao buscar os estados no IBGE.");
            }

            var content = await response.Content.ReadAsStringAsync();
            var cidades = JsonSerializer.Deserialize<List<CidadeDto>>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            return cidades;
        }
    }
}
