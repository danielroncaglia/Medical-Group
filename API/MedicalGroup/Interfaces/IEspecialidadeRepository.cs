using MedicalGroup.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalGroup.Interfaces
{
    interface IEspecialidadeRepository
    {
        void cadastrarEspecialidade(Especialidades especialidade);

        List<Especialidades> listarEspecialidade();

        void apagarEspecialidade(int Id);

    }
}

