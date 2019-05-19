using Senai.MedicalGroup.WebAPI.Roncaglia.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.MedicalGroup.WebAPI.Roncaglia.Interfaces
{
    public interface IClinicaRepository
    {

        //Cadastra nova clínica
        void cadastrarClinica(Clinica clinica);

        //Lista todas as clínicas
        List<Clinica> listarClinica();

        //Apagar clínica
        void apagarClinica(int Id);
    }
}
