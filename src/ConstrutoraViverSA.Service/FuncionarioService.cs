using ConstrutoraViverSA.Domain;
using ConstrutoraViverSA.Infraestrutura;
using System.Collections.Generic;
using System.Linq;
using ConstrutoraViverSA.Domain.Dtos;

namespace ConstrutoraViverSA.Service
{
    public class FuncionarioService
    {
        private readonly ApplicationContext _database;

        public FuncionarioService(ApplicationContext applicationContext)
        {
            _database = applicationContext;
        }

        public List<Funcionario> BuscarFuncionarios()
        {
            return _database.Funcionarios
                .Where(p => p.Id > 0)
                .OrderBy(p => p.Id)
                .ToList();
        }

        public Funcionario BuscarFuncionarioPorId(long BuscaId)
        {
            return _database.Funcionarios
                .FirstOrDefault(p => p.Id == BuscaId);
        }

        public void AdicionarFuncionario(FuncionarioDto dto)
        {
            _database.Funcionarios.Add(dto.DtoParaDominio());
            _database.SaveChanges();
        }
        public void ExcluirFuncionario(long IdExcluir)
        {
            Funcionario funcionario = _database.Funcionarios.Find(IdExcluir);

            _database.Funcionarios.Remove(funcionario);
            _database.SaveChanges();
        }

        public void AlterarFuncionario(long id, FuncionarioDto funcionariolAtualizado)
        {
            Funcionario funcionario = _database.Funcionarios.Find(id);

            // TODO: ajustar para pegar somente se mudar ou existir
            funcionario.Nome = funcionariolAtualizado.Nome;
            funcionario.DataNascimento = funcionariolAtualizado.DataNascimento;
            funcionario.Genero = funcionariolAtualizado.Genero;
            funcionario.Cpf = funcionariolAtualizado.Cpf;
            funcionario.NumCtps = funcionariolAtualizado.NumCtps;
            funcionario.Endereco = funcionariolAtualizado.Endereco;
            funcionario.Email = funcionariolAtualizado.Email;
            funcionario.Telefone = funcionariolAtualizado.Telefone;
            funcionario.Cargo = funcionariolAtualizado.Cargo;

            _database.Funcionarios.Update(funcionario);
            _database.SaveChanges();
        }
    }
}