using MedicalGroup.Domains;
using System.Collections.Generic;

namespace MedicalGroup.Interfaces
{
    public interface ILocalizacaoRepository
    {
        void Cadastrar(LocalizacaoDomain localizacao);

        List<LocalizacaoDomain> ListarTodos();
    }
}