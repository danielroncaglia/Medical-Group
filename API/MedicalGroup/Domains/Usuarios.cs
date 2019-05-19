using System;
using System.Collections.Generic;

namespace MedicalGroup.Domains
{
    public partial class Usuarios
    {
        public Usuarios()
        {
            Medicos = new HashSet<Medicos>();
            Pacientes = new HashSet<Pacientes>();
        }

        public int IdUsuario { get; set; }
        public int? IdTipoUsuario { get; set; }
        public string EmailUsuario { get; set; }
        public string SenhaUsuario { get; set; }

        public virtual TipoUsuarios IdTipoUsuarioNavigation { get; set; }
        public virtual ICollection<Medicos> Medicos { get; set; }
        public virtual ICollection<Pacientes> Pacientes { get; set; }
    }
}
