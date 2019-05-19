using MedicalGroup.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalGroup.Interfaces
{
    public interface IConsultaRepository
    {
        void cadastrarConsulta(Consultas consulta);

        List<Consultas> consultaporMedico(int Id);

        List<Consultas> consultaporPaciente(int Id);

        List<Consultas> todasConsultas();

        void apagarConsulta(int Id);

        Consultas consultasporId(int Id);

        void atualizarConsulta(Consultas novaConsulta, Consultas consultaCadastrada);
    }
}
