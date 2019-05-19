using System;
using System.Collections.Generic;

namespace Senai.MedicalGroup.WebAPI.Roncaglia.Domains
{
    public partial class Clinica
    {
        public Clinica()
        {
            Medicos = new HashSet<Medicos>();
        }

        public int IdClinica { get; set; }
        public string NomeClinica { get; set; }
        public string Cnpj { get; set; }
        public string Razao { get; set; }
        public string Endereco { get; set; }

        public ICollection<Medicos> Medicos { get; set; }
    }
}
