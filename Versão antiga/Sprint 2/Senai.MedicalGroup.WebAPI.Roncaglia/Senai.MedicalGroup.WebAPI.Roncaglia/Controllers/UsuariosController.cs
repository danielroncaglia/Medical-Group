using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Senai.MedicalGroup.WebAPI.Roncaglia.Domains;
using Senai.MedicalGroup.WebAPI.Roncaglia.Interfaces;
using Senai.MedicalGroup.WebAPI.Roncaglia.Repositories;

namespace Senai.SPMedicalGroup.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class UsuariosController : ControllerBase
    {
        private IUsuarioRepository UsuarioRepository { get; set; }

        public UsuariosController()
        {
            UsuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public IActionResult Cadastrar(Usuarios usuario)
        {
            try
            {
                UsuarioRepository.CadastrarAdministrador(usuario);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    mensagem = "Erro: " + ex
                });
            }
        }
    }
}