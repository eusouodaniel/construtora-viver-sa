using System.Collections.Generic;
using System.Linq;
using ConstrutoraViverSA.Domain;
using ConstrutoraViverSA.Infrastructure;
using ConstrutoraViverSA.Repository.Interfaces;

namespace ConstrutoraViverSA.Repository.Repositories
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private readonly ApplicationContext _database;

        public FuncionarioRepository(ApplicationContext applicationContext)
        {
            _database = applicationContext;
        }
        
        public List<Funcionario> BuscarTodos()
        {
            return _database.Funcionario
                .Where(p => p.Id > 0)
                .OrderBy(p => p.Id)
                .ToList();
        }
        
        public Funcionario BuscarPorId(long buscaId)
        {
            return _database.Funcionario
                .FirstOrDefault(p => p.Id == buscaId);
        }
        
        public void Adicionar(Funcionario obj)
        {
            _database.Funcionario.Add(obj);
            _database.SaveChanges();
        }
        public void Excluir(Funcionario obj)
        {
            _database.Funcionario.Remove(obj);
            _database.SaveChanges();
        }
        
        public void Editar(Funcionario obj)
        {
            _database.Funcionario.Update(obj);
            _database.SaveChanges();
        }
    }
}