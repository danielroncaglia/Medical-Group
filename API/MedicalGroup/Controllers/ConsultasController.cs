using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
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
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultasController : ControllerBase
    {

        private IConsultaRepository ConsultaRepository { get; set; }
        private IPacienteRepository PacienteRepository { get; set; }
        private IMedicoRepository MedicoRepository { get; set; }

        public ConsultasController()
        {
            ConsultaRepository = new ConsultaRepository();
            PacienteRepository = new PacienteRepository();
            MedicoRepository = new MedicoRepository();

        }

        [HttpPost("cadastrar")]
        [Authorize(Roles = "Administrador")]
        public IActionResult cadastrarConsulta(Consultas consulta)
        {
            try
            {
                ConsultaRepository.cadastrarConsulta(consulta);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [HttpPost("apagar")]
        [Authorize(Roles = "Administrador")]
        public IActionResult apagarConsulta(int id)
        {
            try
            {
                ConsultaRepository.apagarConsulta(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [HttpGet("listar")]
        [Authorize(Roles = "Administrador")]
        public IActionResult listarConsultas()
        {
            try
            {
                return Ok(ConsultaRepository.todasConsultas());
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [HttpGet("paciente")]
        [Authorize(Roles = "Paciente")]
        public IActionResult consultasporPaciente()
        {
            try
            {
                int IdUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                Pacientes pacienteProcurado = PacienteRepository.buscarPacientePorIdUsuario(IdUsuario);

                if (pacienteProcurado == null)
                {
                    return NotFound(new
                    {
                        mensagem = "Paciente não encontrado."
                    });
                }

                var listaconsultapaciente = ConsultaRepository.consultaporPaciente(pacienteProcurado.IdPaciente);

                foreach (var item in listaconsultapaciente)
                {
                    item.IdPacienteNavigation.Consultas = null;
                    item.SituacaoConsulta = item.SituacaoConsulta.Trim();
                }

                return Ok(listaconsultapaciente);

            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [HttpGet("medico")]
        [Authorize(Roles = "Medico")]
        public IActionResult consultasporMedico()
        {
            try
            {
                int IdUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                Medicos medicoProcurado = MedicoRepository.buscarMedicoPorIdUsuario(IdUsuario);

                if (medicoProcurado == null)
                {
                    return NotFound(new
                    {
                        mensagem = "Médico não encontrado."
                    });
                }

                return Ok(ConsultaRepository.consultaporMedico(medicoProcurado.IdMedico));

            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [HttpPut("atualizar")]
        [Authorize(Roles = "Administrador, Medico")]
        public IActionResult atualizarConsulta(Consultas novaConsulta)
        {
            try
            {
                Consultas consultaCadastrada = ConsultaRepository.consultasporId(novaConsulta.IdConsulta);

                if (consultaCadastrada == null)
                {
                    return NotFound(new
                    {
                        mensagem = "Não encontrada"
                    });
                }

                ConsultaRepository.atualizarConsulta(novaConsulta, consultaCadastrada);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }


    }
}