using Senai.MedicalGroup.WebAPI.Roncaglia.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.MedicalGroup.WebAPI.Roncaglia.Interfaces
{
    interface IEspecialidadeRepository
    {
        //Cadastrar nova especialidade
        void cadastrarEspecialidade(Especialidades especialidade);


        //Listar todas as especialidades
        List<Especialidades> listarEspecialidade();

        //Apagar especialidade
        void apagarEspecialidade(int Id);

    }
}
