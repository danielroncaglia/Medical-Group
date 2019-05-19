using System;
using System.Collections.Generic;

namespace Senai.MedicalGroup.WebAPI.Roncaglia.Domains
{
    public partial class Especialidades
    {
        public Especialidades()
        {
            Medicos = new HashSet<Medicos>();
        }

        public int IdEspecialidade { get; set; }
        public string EspecialidadeMedico { get; set; }

        public ICollection<Medicos> Medicos { get; set; }
    }
}
