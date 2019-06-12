using System;
using MedicalGroup.Domains;
using MedicalGroup.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MedicalGroup.Repositories;

namespace MedicalGroup.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LocalizacaoController : ControllerBase
    {
        private ILocalizacaoRepository LocalizacaoRepository { get; set; }

        public LocalizacaoController()
        {
            LocalizacaoRepository = new LocalizacaoRepository();
        }

        [HttpPost]
        public IActionResult Cadastrar(LocalizacaoDomain localizacao)
        {
            try
            {
                LocalizacaoRepository.Cadastrar(localizacao);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public IActionResult ListarTodos()
        {
            try
            {
                return Ok(LocalizacaoRepository.ListarTodos());
            }
            catch (Exception ex)
            {
                return BadRequest( ex.Message);
            }
        }
    }
}