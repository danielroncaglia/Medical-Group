using System;
using System.Collections.Generic;

namespace Senai.MedicalGroup.WebAPI.Roncaglia.Domains
{
    public partial class Tipo
    {
        public Tipo()
        {
            Usuarios = new HashSet<Usuarios>();
        }

        public int IdTipo { get; set; }
        public string TipoUsuario { get; set; }

        public ICollection<Usuarios> Usuarios { get; set; }
    }
}
