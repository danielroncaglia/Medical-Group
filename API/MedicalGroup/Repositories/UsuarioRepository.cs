using Microsoft.EntityFrameworkCore;
using MedicalGroup.Domains;
using MedicalGroup.Interfaces;
using MedicalGroup.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalGroup.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public Usuarios BuscarPorEmailESenha(LoginViewModel login)
        {
            using (MedicalGroupContext ctx = new MedicalGroupContext())
            {
                return ctx.Usuarios.Include(x => x.IdTipoUsuarioNavigation).FirstOrDefault(x => x.EmailUsuario == login.Email && x.SenhaUsuario == login.Senha);

            }
        }

        public void CadastrarAdministrador(Usuarios usuario)
        {
            using (MedicalGroupContext ctx = new MedicalGroupContext())
            {
                ctx.Usuarios.Add(usuario);
                ctx.SaveChanges();
            }
        }

        public void CadastrarMedico(MedicoViewModel medicoModel)
        {
            using (MedicalGroupContext ctx = new MedicalGroupContext())
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
            using (MedicalGroupContext ctx = new MedicalGroupContext())
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