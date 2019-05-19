using System;
using System.Collections.Generic;

namespace MedicalGroup.Domains
{
    public partial class Especialidades
    {
        public Especialidades()
        {
            Medicos = new HashSet<Medicos>();
        }

        public int IdEspecialidade { get; set; }
        public string EspecialidadeMedico { get; set; }

        public virtual ICollection<Medicos> Medicos { get; set; }
    }
}
