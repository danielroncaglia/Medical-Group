using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MedicalGroup.Interfaces;
using MedicalGroup.Repositories;

namespace MedicalGroup.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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