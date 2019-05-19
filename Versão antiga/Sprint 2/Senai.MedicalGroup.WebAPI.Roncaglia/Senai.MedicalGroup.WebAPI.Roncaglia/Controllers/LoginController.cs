using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Senai.MedicalGroup.WebAPI.Roncaglia.Domains;
using Senai.MedicalGroup.WebAPI.Roncaglia.Interfaces;
using Senai.MedicalGroup.WebAPI.Roncaglia.Repositories;
using Senai.MedicalGroup.WebAPI.Roncaglia.ViewModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Senai.MedicalGroup.WebAPI.Roncaglia.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class LoginController : ControllerBase
    {
        private IUsuarioRepository UsuarioRepository { get; set; }

        public LoginController()
        {
            UsuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Logar(LoginViewModel login)
        {
            try
            {
                Usuarios usuarioProcurado = UsuarioRepository.BuscarPorEmailESenha(login);

                if (usuarioProcurado == null)
                {
                    return NotFound(new
                    {
                        mensagem = "Erro."
                    });
                }

                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, usuarioProcurado.EmailUsuario),
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioProcurado.IdUsuario.ToString()),
                    new Claim(ClaimTypes.Role, usuarioProcurado.IdTipoNavigation.TipoUsuario),
                    new Claim("Role", usuarioProcurado.IdTipoNavigation.TipoUsuario)
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("Senai.MedicalGroup.WebAPI.Roncaglia"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "Senai.MedicalGroup.WebAPI.Roncaglia",
                    audience: "Senai.MedicalGroup.WebAPI.Roncaglia",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds
                );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
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