using System;
using System.Collections.Generic;

namespace Senai.MedicalGroup.WebAPI.Roncaglia.Domains
{
    public partial class Usuarios
    {
        public Usuarios()
        {
            Medicos = new HashSet<Medicos>();
            Pacientes = new HashSet<Pacientes>();
        }

        public int IdUsuario { get; set; }
        public int IdTipo { get; set; }
        public string EmailUsuario { get; set; }
        public string SenhaUsuario { get; set; }

        public Tipo IdTipoNavigation { get; set; }
        public ICollection<Medicos> Medicos { get; set; }
        public ICollection<Pacientes> Pacientes { get; set; }
    }
}
