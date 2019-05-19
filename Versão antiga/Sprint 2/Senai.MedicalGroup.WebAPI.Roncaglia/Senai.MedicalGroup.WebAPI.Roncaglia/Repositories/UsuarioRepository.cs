using Microsoft.EntityFrameworkCore;
using Senai.MedicalGroup.WebAPI.Roncaglia.Domains;
using Senai.MedicalGroup.WebAPI.Roncaglia.Interfaces;
using Senai.MedicalGroup.WebAPI.Roncaglia.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.MedicalGroup.WebAPI.Roncaglia.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public Usuarios BuscarPorEmailESenha(LoginViewModel login)
        {
            using (MedGroupContext ctx = new MedGroupContext())
            {
                return ctx.Usuarios.Include(x => x.IdTipoNavigation).FirstOrDefault(x => x.EmailUsuario == login.Email && x.SenhaUsuario == login.Senha);

            }
        }

        public void CadastrarAdministrador(Usuarios usuario)
        {
            using (MedGroupContext ctx = new MedGroupContext())
            {
                ctx.Usuarios.Add(usuario);
                ctx.SaveChanges();
            }
        }

        public void CadastrarMedico(MedicoViewModel medicoModel)
        {
            using (MedGroupContext ctx = new MedGroupContext())
            {
                ctx.Usuarios.Add(medicoModel.Usuario);
                ctx.SaveChanges();
                Usuarios usuario = ctx.Usuarios.Last();
                medicoModel.Medico.IdUsuario = usuario.IdUsuario;
                ctx.Medicos.Add(medicoModel.Medico);
                ctx.SaveChanges();
            }
        }

        public void CadastrarPaciente(PacienteViewModel pacienteModel)
        {
            using (MedGroupContext ctx = new MedGroupContext())
            {
                ctx.Usuarios.Add(pacienteModel.Usuario);
                ctx.SaveChanges();
                Usuarios usuario = ctx.Usuarios.Last();
                pacienteModel.Paciente.IdUsuario = usuario.IdUsuario;
                ctx.Pacientes.Add(pacienteModel.Paciente);
                ctx.SaveChanges();
            }
        }
    }
}