using MedicalGroup.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalGroup.ViewModels
{
    public class PacienteViewModel
    {
        public Usuarios Usuario { get; set; }
        public Pacientes Paciente { get; set; }
    }
}
