using MedicalGroup.Domains;
using MedicalGroup.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalGroup.Repositories
{
    public class ClinicaRepository : IClinicaRepository
    {
        public void cadastrarClinica(Clinica clinica)
        {
            using (MedicalGroupContext ctx = new MedicalGroupContext())
            {
                ctx.Clinica.Add(clinica);
                ctx.SaveChanges();
            }
        }

        public List<Clinica> listarClinica()
        {
            using (MedicalGroupContext ctx = new MedicalGroupContext())
            {
                return ctx.Clinica.ToList();
            }
        }

        public void apagarClinica(int Id)
        {
            using (MedicalGroupContext ctx = new MedicalGroupContext())
            {
                Clinica clinicaProcurada = ctx.Clinica.Find(Id);
                ctx.Clinica.Remove(clinicaProcurada);
                ctx.SaveChanges();
            }
        }

    }
}
