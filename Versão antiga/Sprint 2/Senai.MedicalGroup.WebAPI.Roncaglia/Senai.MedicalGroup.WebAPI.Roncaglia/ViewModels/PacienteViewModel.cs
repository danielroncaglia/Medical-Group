using Senai.MedicalGroup.WebAPI.Roncaglia.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.MedicalGroup.WebAPI.Roncaglia.ViewModels
{
    public class PacienteViewModel
    {
        public Usuarios Usuario { get; set; }
        public Pacientes Paciente { get; set; }
    }
}
