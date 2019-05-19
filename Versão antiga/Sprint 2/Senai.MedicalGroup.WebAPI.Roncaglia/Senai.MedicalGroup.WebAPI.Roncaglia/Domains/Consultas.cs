using System;
using System.Collections.Generic;

namespace Senai.MedicalGroup.WebAPI.Roncaglia.Domains
{
    public partial class Consultas
    {
        public int? IdPaciente { get; set; }
        public int? IdMedico { get; set; }
        public DateTime DataHorario { get; set; }
        public string DescricaoConsulta { get; set; }
        public string SituacaoConsulta { get; set; }
        public string Outros { get; set; }
        public int IdConsultas { get; set; }

        public Medicos IdMedicoNavigation { get; set; }
        public Pacientes IdPacienteNavigation { get; set; }
    }
}
