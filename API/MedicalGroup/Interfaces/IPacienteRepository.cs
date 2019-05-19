using MedicalGroup.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalGroup.Interfaces
{
    internal interface IPacienteRepository
    {

        Pacientes buscarPacientePorIdUsuario(int Idusuario);

        void cadastrarPaciente(Pacientes paciente);

        List<Pacientes> listarPacientes();

        void apagarPaciente(int Id);

    }
}