using MedicalGroup.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalGroup.Interfaces
{
    public interface IClinicaRepository
    {
        void cadastrarClinica(Clinica clinica);

        List<Clinica> listarClinica();

        void apagarClinica(int Id);
    }
}
