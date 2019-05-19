using MedicalGroup.Domains;
using MedicalGroup.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalGroup.Repositories
{
    public class EspecialidadeRepository : IEspecialidadeRepository
    {

        public void cadastrarEspecialidade(Especialidades especialidade)
        {
            using (MedicalGroupContext ctx = new MedicalGroupContext())
            {
                ctx.Especialidades.Add(especialidade);
                ctx.SaveChanges();
            }
        }

        public List<Especialidades> listarEspecialidade()
        {
            using (MedicalGroupContext ctx = new MedicalGroupContext())
            {
                return ctx.Especialidades.ToList();
            }
        }

        public void apagarEspecialidade(int Id)
        {
            using (MedicalGroupContext ctx = new MedicalGroupContext())
            {
                Especialidades especialidadeProcurada = ctx.Especialidades.Find(Id);
                ctx.Especialidades.Remove(especialidadeProcurada);
                ctx.SaveChanges();
            }
        }

    }
}