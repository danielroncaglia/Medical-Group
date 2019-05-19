using Senai.MedicalGroup.WebAPI.Roncaglia.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.MedicalGroup.WebAPI.Roncaglia.Interfaces
{
    public interface IMedicoRepository
    {
        //Cadastrar médicos
        void cadastrarMedicos(Medicos medico);

        //Buscar por Id do médico
       Medicos buscarMedicoPorIdUsuario(int Idusuario);

        //Listar médicos
        List<Medicos> listarMedicos();

        //Apagar médico
        void apagarMedico(int Id);

    }
}
