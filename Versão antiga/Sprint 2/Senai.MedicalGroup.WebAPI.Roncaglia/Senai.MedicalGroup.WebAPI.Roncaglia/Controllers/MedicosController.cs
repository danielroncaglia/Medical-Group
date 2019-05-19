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
    [Authorize(Roles = "Administrador, Médico")]
    public class MedicosController : ControllerBase
    {
        private IMedicoRepository MedicosRepository { get; set; }


        public MedicosController()
        {
            MedicosRepository = new MedicoRepository();
        }
        [HttpGet]
        public IActionResult get()
        {
            try
            {
                return Ok(MedicosRepository.listarMedicos());
            }
            catch
            {

                return BadRequest();
            }
        }
    }
}