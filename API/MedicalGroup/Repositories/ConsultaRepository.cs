using MedicalGroup.Domains;
using MedicalGroup.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalGroup.Repositories
{
    public class ConsultaRepository : IConsultaRepository
    {
        public void cadastrarConsulta(Consultas consulta)
        {
            using (MedicalGroupContext ctx = new MedicalGroupContext())
            {
                ctx.Consultas.Add(consulta);
                ctx.SaveChanges();
            }
        }

        public List<Consultas> consultaporMedico(int IdMedico)
        {
            using (MedicalGroupContext ctx = new MedicalGroupContext())
            {
                return ctx.Consultas.Where(x => x.IdMedico == IdMedico).ToList();
            }
        }

        public List<Consultas> consultaporPaciente(int IdPaciente)
        {
            using (MedicalGroupContext ctx = new MedicalGroupContext())
            {
                return ctx.Consultas.Where(x => x.IdPaciente == IdPaciente).Include(x => x.IdPacienteNavigation).ToList();
            }
        }

        public List<Consultas> todasConsultas()
        {
            using (MedicalGroupContext ctx = new MedicalGroupContext())
            {
                return ctx.Consultas.ToList();
            }
        }

        public void apagarConsulta(int Id)
        {
            using (MedicalGroupContext ctx = new MedicalGroupContext())
            {
                Consultas consultaProcurada = ctx.Consultas.Find(Id);
                ctx.Consultas.Remove(consultaProcurada);
                ctx.SaveChanges();
            }
        }

        public Consultas consultasporId(int Id)
        {
            using (MedicalGroupContext ctx = new MedicalGroupContext())
            {
                return ctx.Consultas.Find(Id);
            }
        }

        public void atualizarConsulta(Consultas novaConsulta, Consultas consultaCadastrada)
        {

            if (novaConsulta.SituacaoConsulta != null)
            {
                consultaCadastrada.SituacaoConsulta = novaConsulta.SituacaoConsulta;
            }

            using (MedicalGroupContext ctx = new MedicalGroupContext())
            {
                ctx.Consultas.Update(consultaCadastrada);
                ctx.SaveChanges();
            }
        }

    }
}
