using MedicalGroup.Domains;
using MedicalGroup.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalGroup.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {

        public Pacientes buscarPacientePorIdUsuario(int Idusuario)
        {
            using (MedicalGroupContext ctx = new MedicalGroupContext())
            {
                return ctx.Pacientes.FirstOrDefault(x => x.IdUsuario == Idusuario);
            }
        }

        public void cadastrarPaciente(Pacientes paciente)
        {
            using (MedicalGroupContext ctx = new MedicalGroupContext())
            {
                ctx.Pacientes.Add(paciente);
                ctx.SaveChanges();
            }
        }
        public List<Pacientes> listarPacientes()
        {
            using (MedicalGroupContext ctx = new MedicalGroupContext())
            {
                return ctx.Pacientes.ToList();
            }
        }

        public void apagarPaciente(int Id)
        {
            using (MedicalGroupContext ctx = new MedicalGroupContext())
            {
                Pacientes pacienteProcurado = ctx.Pacientes.Find(Id);
                ctx.Pacientes.Remove(pacienteProcurado);
                ctx.SaveChanges();
            }
        }

    }
}