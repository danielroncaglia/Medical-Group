using Senai.MedicalGroup.WebAPI.Roncaglia.Domains;
using Senai.MedicalGroup.WebAPI.Roncaglia.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.MedicalGroup.WebAPI.Roncaglia.Interfaces
{
    interface IUsuarioRepository
    {
        Usuarios BuscarPorEmailESenha(LoginViewModel login);

        void CadastrarAdministrador(Usuarios usuario);

        void CadastrarPaciente(PacienteViewModel pacienteModel);

        void CadastrarMedico(MedicoViewModel medicoModel);
    }
}
