using Senai.MedicalGroup.WebAPI.Roncaglia.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.MedicalGroup.WebAPI.Roncaglia.Interfaces
{
    public interface IConsultaRepository
    {
        //Cadastrar nova consulta
        void cadastrarConsulta(Consultas consulta);

        //Listar consultas de somente um médico
        List<Consultas> consultaporMedico(int Id);

        //Listar consultas de somente um paciente
        List<Consultas> consultaporPaciente(int Id);

        //Listar todas as consultas
        List<Consultas> todasConsultas();

        //Apagar consulta
        void apagarConsulta(int Id);

        //Buscar consulta por id
        Consultas consultasporId(int Id);

        //Alterar consulta
        void atualizarConsulta(Consultas novaConsulta, Consultas consultaCadastrada);
    }
}
