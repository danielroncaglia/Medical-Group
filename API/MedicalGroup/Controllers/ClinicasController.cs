using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MedicalGroup.Domains;
using MedicalGroup.Interfaces;
using MedicalGroup.Repositories;

namespace MedicalGroup.Controllers
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