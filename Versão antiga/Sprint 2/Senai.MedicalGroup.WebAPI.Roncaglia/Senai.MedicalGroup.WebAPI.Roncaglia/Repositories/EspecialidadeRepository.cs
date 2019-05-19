using Senai.MedicalGroup.WebAPI.Roncaglia.Domains;
using Senai.MedicalGroup.WebAPI.Roncaglia.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.MedicalGroup.WebAPI.Roncaglia.Repositories
{
    public class EspecialidadeRepository : IEspecialidadeRepository
    {

        //Cadastrar nova especialidade
        public void cadastrarEspecialidade(Especialidades especialidade)
        {
            using (MedGroupContext ctx = new MedGroupContext())
            {
                ctx.Especialidades.Add(especialidade);
                ctx.SaveChanges();
            }
        }

        //Lista todas as especialidades
        public List<Especialidades> listarEspecialidade()
        {
            using (MedGroupContext ctx = new MedGroupContext())
            {
                return ctx.Especialidades.ToList();
            }
        }

        //Apagar especialidade
        public void apagarEspecialidade(int Id)
        {
            using (MedGroupContext ctx = new MedGroupContext())
            {
                Especialidades especialidadeProcurada = ctx.Especialidades.Find(Id);
                ctx.Especialidades.Remove(especialidadeProcurada);
                ctx.SaveChanges();
            }
        }

    }
}