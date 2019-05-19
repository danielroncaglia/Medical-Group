using Senai.MedicalGroup.WebAPI.Roncaglia.Domains;
using Senai.MedicalGroup.WebAPI.Roncaglia.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.MedicalGroup.WebAPI.Roncaglia.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {

        //Buscar por Id do paciente
        public Pacientes buscarPacientePorIdUsuario(int Idusuario)
        {
            using (MedGroupContext ctx = new MedGroupContext())
            {
                return ctx.Pacientes.FirstOrDefault(x => x.IdUsuario == Idusuario);
            }
        }

        //Cadastra nova consulta
        public void cadastrarPaciente(Pacientes paciente)
        {
            using (MedGroupContext ctx = new MedGroupContext())
            {
                ctx.Pacientes.Add(paciente);
                ctx.SaveChanges();
            }
        }

        //Listar os pacientes
        public List<Pacientes> listarPacientes()
        {
            using (MedGroupContext ctx = new MedGroupContext())
            {
                return ctx.Pacientes.ToList();
            }
        }

        //Apagar paciente
        public void apagarPaciente(int Id)
        {
            using (MedGroupContext ctx = new MedGroupContext())
            {
                Pacientes pacienteProcurado = ctx.Pacientes.Find(Id);
                ctx.Pacientes.Remove(pacienteProcurado);
                ctx.SaveChanges();
            }
        }

    }
}
