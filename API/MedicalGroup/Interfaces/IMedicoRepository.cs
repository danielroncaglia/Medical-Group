using MedicalGroup.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalGroup.Interfaces
{
    public interface IMedicoRepository
    {
        void cadastrarMedicos(Medicos medico);

        Medicos buscarMedicoPorIdUsuario(int Idusuario);

        List<Medicos> listarMedicos();

        void apagarMedico(int Id);
    }
}
