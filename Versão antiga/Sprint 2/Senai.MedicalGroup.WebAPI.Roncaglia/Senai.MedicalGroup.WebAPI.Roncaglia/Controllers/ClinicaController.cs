using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.MedicalGroup.WebAPI.Roncaglia.Domains;
using Senai.MedicalGroup.WebAPI.Roncaglia.Interfaces;
using Senai.MedicalGroup.WebAPI.Roncaglia.Repositories;

namespace Senai.MedicalGroup.WebAPI.Roncaglia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ClinicaController : ControllerBase
    {

        private IClinicaRepository ClinicaRepository { get; set; }

        public ClinicaController()
        {
            ClinicaRepository = new ClinicaRepository();
        }

        //Cadastrar nova clinica
        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public IActionResult cadastrarClinica(Clinica clinica)
        {
            try
            {
                ClinicaRepository.cadastrarClinica(clinica);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }
    }
}