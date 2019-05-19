using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MedicalGroup.Domains;
using MedicalGroup.Interfaces;
using MedicalGroup.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using MedicalGroup.ViewModels;

namespace MedicalGroup.Controllers
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
                    new Claim(ClaimTypes.Role, usuarioProcurado.IdTipoUsuarioNavigation.TipoUsuario),
                    new Claim("Role", usuarioProcurado.IdTipoUsuarioNavigation.TipoUsuario)
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("MedicalGroup.Api"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "MedicalGroup",
                    audience: "MedicalGroup",
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