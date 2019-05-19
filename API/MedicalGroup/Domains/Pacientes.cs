using System;
using System.Collections.Generic;

namespace MedicalGroup.Domains
{
    public partial class Pacientes
    {
        public Pacientes()
        {
            Consultas = new HashSet<Consultas>();
        }

        public int IdPaciente { get; set; }
        public int? IdUsuario { get; set; }
        public string NomePaciente { get; set; }
        public DateTime NascimentoPaciente { get; set; }
        public string RgPaciente { get; set; }
        public string CpfPaciente { get; set; }
        public string TelefonePaciente { get; set; }
        public string EnderecoPaciente { get; set; }
        public string InformacoesPaciente { get; set; }

        public virtual Usuarios IdUsuarioNavigation { get; set; }
        public virtual ICollection<Consultas> Consultas { get; set; }
    }
}
