using Microsoft.AspNetCore.Mvc;
using Senai.Domain.DTOs;
using Senai.Service.Interfaces;

namespace Senai.App.Controllers
{
    public class EscolaController : Controller
    {
        private readonly IEstadoService _estadoService;
        private readonly IEscolaService _escolaService;

        public EscolaController(IEstadoService estadoService, IEscolaService escolaService)
        {
            _estadoService = estadoService;
            _escolaService = escolaService;
        }

        public IActionResult Index()
        {
            ViewBag.Escolas = _escolaService.BuscarTodos();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Form()
        {
            var model = new EscolaDto();
            ViewBag.Estados = await _estadoService.BuscarEstados();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Form(EscolaDto model)
        {
            if (ModelState.IsValid)
            {
                var retorno = _escolaService.Salvar(model);
                return RedirectToAction("Index");
            }
            ViewBag.Estados = await _estadoService.BuscarEstados();
            return View(model);
        }

        [HttpGet]
        public  async Task<IActionResult> PegarCidades(int estadoId)
        {
            var cidades = await _estadoService.BuscarCidades(estadoId);
            return Json(cidades);
        }

        [HttpGet]
        public IActionResult Remover(long id)
        {
            var remocao = _escolaService.Remover(id);
            return RedirectToAction("Index");
        }

    }
}
