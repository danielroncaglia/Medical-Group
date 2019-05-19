using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.MedicalGroup.WebAPI.Roncaglia.Interfaces;
using Senai.MedicalGroup.WebAPI.Roncaglia.Repositories;

namespace Senai.MedicalGroup.WebAPI.Roncaglia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacientesController : ControllerBase
    {
        private IPacienteRepository PacientesRepository { get; set; }


        public PacientesController()
        {
            PacientesRepository = new PacienteRepository();
        }
        [HttpGet]
        [Authorize(Roles = "Administrador")]
        public IActionResult get()
        {
            try
            {
                return Ok(PacientesRepository.listarPacientes());
            }
            catch
            {

                return BadRequest();
            }
        }
    }
}