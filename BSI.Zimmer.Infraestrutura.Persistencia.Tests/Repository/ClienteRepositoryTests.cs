using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BSI.Zimmer.Infraestrutura.Persistencia.UnitOfWork;
using BSI.Zimmer.Infraestrutura.Persistencia.Repository;
using System.Linq;
using BSI.Zimmer.Dominio.Entity;
using System.Data.Entity.Validation;

namespace BSI.Zimmer.Infraestrutura.Persistencia.Repository.Tests
{
    [TestClass]
    public class ClienteRepositoryTests
    {
        [TestMethod]
        public void VerificaSeDadosForamMigradosDoEAParaOZimmer()
        {
            var unit = new MainUnitOfWork();
            var clienteRepository = new ClienteRepository(unit);

            var all = clienteRepository.GetAll();

            Assert.IsNotNull(all);
            Assert.IsTrue(all.Count() > 0, "Não foi encontrado dados na tabela cliente do zimmer, talvez o método Seed não esteja funcional");

        }

        [TestMethod]
        public void IncluiExcluiUmClienteNoZimmer()
        {
            var unit = new MainUnitOfWork();
            var clienteRepository = new ClienteRepository(unit);

            var cliente = new Cliente();
            cliente.Nome = "Teste:IncluirUmClienteNoZimmer";
            cliente.PackageId = 10;
            cliente.GenerateNewIdentity();

            clienteRepository.Add(cliente);

            unit.Commit();

            var clienteIncluido = clienteRepository.GetFiltered(s => s.Id == cliente.Id).FirstOrDefault();
            bool equals = clienteIncluido.Equals(cliente);

            clienteRepository.Remove(clienteIncluido);

            unit.Commit();

            var clienteExcluido = clienteRepository.GetFiltered(s => s.Id == cliente.Id).FirstOrDefault();

            Assert.IsTrue(equals, "Não foi encontrado dados na tabela cliente do zimmer, talvez o método Seed não esteja funcional");
            Assert.IsNull(clienteExcluido, "Mesmo após ter excluido um cliente foi possível encontra-lo no banco de dados");
        }

        [TestMethod]
        [ExpectedException(typeof(DbEntityValidationException))]
        public void IncluirClienteSemNomeNoZimmer()
        {
            var unit = new MainUnitOfWork();
            var clienteRepository = new ClienteRepository(unit);

            var cliente = new Cliente();
            cliente.Nome = null;
            cliente.PackageId = 10;
            cliente.GenerateNewIdentity();

            clienteRepository.Add(cliente);

            unit.Commit();

            Assert.IsTrue(false, "O Cliente foi cadastrado com o campo Nome Nulo!");

        }

        [TestMethod]
        public void IncluirClienteSemProjetoNoZimmer()
        {
            var unit = new MainUnitOfWork();
            var clienteRepository = new ClienteRepository(unit);

            var cliente = new Cliente();
            cliente.Nome = "Cadastrar Cliente sem Projeto";
            cliente.PackageId = 0;
            cliente.GenerateNewIdentity();

            clienteRepository.Add(cliente);

            unit.Commit();

            var clienteIncluido = clienteRepository.GetFiltered(s => s.Id == cliente.Id).FirstOrDefault();
            bool equals = clienteIncluido.Equals(cliente);

            Assert.IsTrue(false, "Cliente Cadastrado com PackageID 0.");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void IncluirClienteMesmoPackegNoZimmer()
        {
            var unit = new MainUnitOfWork();
            var clienteRepository = new ClienteRepository(unit);

            var cliente = new Cliente();
            cliente.Nome = "Cadastrando primeiro Cliente";
            cliente.PackageId = 10;
            cliente.GenerateNewIdentity();

            clienteRepository.Add(cliente);

            cliente.Nome = "Cadastrando segundo cliente";
            cliente.PackageId = 10;
            cliente.GenerateNewIdentity();

            clienteRepository.Add(cliente);

            unit.Commit();
            
            Assert.IsTrue(false,"Cliente cadastrado duplicado");
        }


        [TestMethod]
        public void IncluirAlterarExcluirUmClienteNoZimmer()
        {
            var unit = new MainUnitOfWork();
            var clienteRepository = new ClienteRepository(unit);

            var cliente = new Cliente();
            cliente.Nome = "Teste:IncluirUmClienteNoZimmer";
            cliente.PackageId = 10;
            cliente.GenerateNewIdentity();

            clienteRepository.Add(cliente);
            unit.Commit();

            Cliente clienteIncluido = clienteRepository.GetFiltered(s => s.Id == cliente.Id).FirstOrDefault();
            bool equals = clienteIncluido.Equals(cliente);
            clienteIncluido.Nome = "Teste:EditarUmClienteNoZimmer";

            clienteRepository.Modify(clienteIncluido);
            unit.Commit();

            clienteRepository.Remove(clienteIncluido);
            unit.Commit();

            var clienteExcluido = clienteRepository.GetFiltered(s => s.Id == cliente.Id).FirstOrDefault();
            Assert.IsTrue(equals, "Não foi encontrado dados na tabela cliente do zimmer, talvez o método Seed não esteja funcional");
            Assert.IsNull(clienteExcluido, "Mesmo após ter excluido um cliente foi possível encontra-lo no banco de dados");
        }

        [TestMethod]
        public void ObterClienteComGuidEmpty()
        {
            var unit = new MainUnitOfWork();
            var clienteRepository = new ClienteRepository(unit);

            var cliente = clienteRepository.Get(Guid.Empty);

            Assert.IsNull(cliente, "Não pode retornar nenhum cliente quando o id é vazio");
        }


    }
}
