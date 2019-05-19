using MedicalGroup.Domains;
using MedicalGroup.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalGroup.Interfaces
{
    interface IUsuarioRepository
    {
        Usuarios BuscarPorEmailESenha(LoginViewModel login);

        void CadastrarAdministrador(Usuarios usuario);

        void CadastrarPaciente(PacienteViewModel pacienteModel);

        void CadastrarMedico(MedicoViewModel medicoModel);
    }
}
