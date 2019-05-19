using MedicalGroup.Domains;
using MedicalGroup.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalGroup.Repositories
{
    public class MedicoRepository : IMedicoRepository
    {

        public Medicos buscarMedicoPorIdUsuario(int Idusuario)
        {
            using (MedicalGroupContext ctx = new MedicalGroupContext())
            {
                return ctx.Medicos.FirstOrDefault(x => x.IdUsuario == Idusuario);
            }
        }

        public void cadastrarMedicos(Medicos medico)
        {
            using (MedicalGroupContext ctx = new MedicalGroupContext())
            {
                ctx.Medicos.Add(medico);
                ctx.SaveChanges();
            }
        }

        public List<Medicos> listarMedicos()
        {
            using (MedicalGroupContext ctx = new MedicalGroupContext())
            {
                return ctx.Medicos.ToList();
            }
        }

        public void apagarMedico(int Id)
        {
            using (MedicalGroupContext ctx = new MedicalGroupContext())
            {
                Medicos medicoProcurado = ctx.Medicos.Find(Id);
                ctx.Medicos.Remove(medicoProcurado);
                ctx.SaveChanges();
            }
        }

    }
}
