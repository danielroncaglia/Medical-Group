using Senai.MedicalGroup.WebAPI.Roncaglia.Domains;
using Senai.MedicalGroup.WebAPI.Roncaglia.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.MedicalGroup.WebAPI.Roncaglia.Repositories
{
    public class ClinicaRepository : IClinicaRepository
    {

        //Cadastrar nova clínica
        public void cadastrarClinica(Clinica clinica)
        {
            using (MedGroupContext ctx = new MedGroupContext())
            {
                ctx.Clinica.Add(clinica);
                ctx.SaveChanges();
            }
        }

        //Listar todas as clínicas
        public List<Clinica> listarClinica()
        {
            using (MedGroupContext ctx = new MedGroupContext())
            {
                return ctx.Clinica.ToList();
            }
        }

        //Apagar clínica
        public void apagarClinica(int Id)
        {
            using (MedGroupContext ctx = new MedGroupContext())
            {
                Clinica clinicaProcurada = ctx.Clinica.Find(Id);
                ctx.Clinica.Remove(clinicaProcurada);
                ctx.SaveChanges();
            }
        }

    }
}
