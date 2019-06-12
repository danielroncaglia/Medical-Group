using System.Collections.Generic;
using MongoDB.Driver;
using MedicalGroup.Domains;
using MedicalGroup.Interfaces;

namespace MedicalGroup.Repositories
{
    public class LocalizacaoRepository : ILocalizacaoRepository
    {
        private readonly IMongoCollection<LocalizacaoDomain> _localizacoes;

        public LocalizacaoRepository()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("medicalgroup");
            _localizacoes = database.GetCollection<LocalizacaoDomain>("mapas");
        }

        public void Cadastrar(LocalizacaoDomain localizacao)
        {
            _localizacoes.InsertOne(localizacao);
        }

        public List<LocalizacaoDomain> ListarTodos()
        {
            return _localizacoes.Find(_ => true).ToList();
        }
    }
}