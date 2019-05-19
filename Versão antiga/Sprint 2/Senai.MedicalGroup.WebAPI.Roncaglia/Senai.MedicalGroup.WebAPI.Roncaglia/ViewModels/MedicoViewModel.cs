using Senai.MedicalGroup.WebAPI.Roncaglia.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.MedicalGroup.WebAPI.Roncaglia.ViewModels
{
    public class MedicoViewModel
    {
        public Usuarios Usuario { get; set; }
        public Medicos Medico { get; set; }
    }
}
