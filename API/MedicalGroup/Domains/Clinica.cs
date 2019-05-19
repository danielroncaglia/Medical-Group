using System;
using System.Collections.Generic;

namespace MedicalGroup.Domains
{
    public partial class Clinica
    {
        public Clinica()
        {
            Medicos = new HashSet<Medicos>();
        }

        public int IdClinica { get; set; }
        public string NomeClinica { get; set; }
        public string CnpjClinica { get; set; }
        public string RazaoSocial { get; set; }
        public string EnderecoClinica { get; set; }

        public virtual ICollection<Medicos> Medicos { get; set; }
    }
}
