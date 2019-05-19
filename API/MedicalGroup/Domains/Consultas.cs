using System;
using System.Collections.Generic;

namespace MedicalGroup.Domains
{
    public partial class Consultas
    {
        public int IdConsulta { get; set; }
        public int? IdPaciente { get; set; }
        public int? IdMedico { get; set; }
        public DateTime DataHorario { get; set; }
        public string DescricaoConsulta { get; set; }
        public string SituacaoConsulta { get; set; }

        public virtual Medicos IdMedicoNavigation { get; set; }
        public virtual Pacientes IdPacienteNavigation { get; set; }
    }
}
