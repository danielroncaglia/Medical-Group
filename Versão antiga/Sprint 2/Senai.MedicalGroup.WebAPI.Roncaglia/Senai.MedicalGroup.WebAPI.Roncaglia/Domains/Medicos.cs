using System;
using System.Collections.Generic;

namespace Senai.MedicalGroup.WebAPI.Roncaglia.Domains
{
    public partial class Medicos
    {
        public Medicos()
        {
            Consultas = new HashSet<Consultas>();
        }

        public int IdMedico { get; set; }
        public int? IdUsuario { get; set; }
        public string NomeMedico { get; set; }
        public string CrmMedico { get; set; }
        public int? IdEspecialidade { get; set; }
        public int? IdClinica { get; set; }

        public Clinica IdClinicaNavigation { get; set; }
        public Especialidades IdEspecialidadeNavigation { get; set; }
        public Usuarios IdUsuarioNavigation { get; set; }
        public ICollection<Consultas> Consultas { get; set; }
    }
}
