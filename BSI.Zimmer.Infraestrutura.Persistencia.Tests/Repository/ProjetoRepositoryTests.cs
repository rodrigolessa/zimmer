using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BSI.Zimmer.Infraestrutura.Persistencia.UnitOfWork;
using BSI.Zimmer.Infraestrutura.Persistencia.Repository;
using System.Linq;
using BSI.Zimmer.Dominio.Entity;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Data.Entity.Infrastructure;

namespace BSI.Zimmer.Infraestrutura.Persistencia.Repository.Tests
{
    [TestClass]
    public class ProjetoRepositoryTests
    {
        [TestMethod]
        public void VerificaSeDadosForamMigradosDoEAParaOZimmer()
        {
            var unit = new MainUnitOfWork();
            var projetoRepository = new ProjetoRepository(unit);

            var all = projetoRepository.GetAll();

            Assert.IsNotNull(all);
            Assert.IsTrue(all.Count() > 0, "Não foi encontrado dados na tabela projeto do zimmer, talvez o método Seed não esteja funcional");

        }

        [TestMethod]
        public void IncluirExcluirProjeto()
        {
            var unit = new MainUnitOfWork();
            var projetoRepository = new ProjetoRepository(unit);
            var clienteRepository = new ClienteRepository(unit);


            Projeto projeto = new Projeto();
            projeto.Nome = "Teste Inclusão de Projeto";
            projeto.PackageId = 13;
            projeto.GenerateNewIdentity();

            Cliente cliente = new Cliente();
            cliente.Nome = "Teste de inclusão de projeto";
            cliente.PackageId = 10;
            cliente.GenerateNewIdentity();
            cliente.Projetos = new List<Projeto>();
            cliente.Projetos.Add(projeto);

            clienteRepository.Add(cliente);

            unit.Commit();

            var projetoIncluido = projetoRepository.GetFiltered(s => s.Id == projeto.Id).FirstOrDefault();
            bool equals = projetoIncluido.Equals(projeto);

            projetoRepository.Remove(projetoIncluido);

            unit.Commit();

            var clienteExcluido = projetoRepository.GetFiltered(s => s.Id == projeto.Id).FirstOrDefault();

            Assert.IsTrue(equals, "Não foi encontrado dados na tabela Projeto do zimmer, talvez o método Seed não esteja funcional");
            Assert.IsNull(clienteExcluido, "Mesmo após ter excluido um projeto foi possível encontra-lo no banco de dados");
        }

        [TestMethod]
        [ExpectedException(typeof(DbEntityValidationException))]
        public void IncluirProjetoSemNomeNoZimmer()
        {
            var unit = new MainUnitOfWork();
            var projetoRepository = new ProjetoRepository(unit);
            var clienteRepository = new ClienteRepository(unit);


            Projeto projeto = new Projeto();
            projeto.PackageId = 13;
            projeto.GenerateNewIdentity();

            Cliente cliente = new Cliente();
            cliente.Nome = "Teste de inclusão de projeto";
            cliente.PackageId = 10;
            cliente.GenerateNewIdentity();
            cliente.Projetos = new List<Projeto>();
            cliente.Projetos.Add(projeto);

            clienteRepository.Add(cliente);

            unit.Commit();

            Assert.IsTrue(false,"Projeto incluido com campo Nome não preenchido.");
        }

        [TestMethod]
        [ExpectedException(typeof(DbUpdateException))]
        public void IncluirProjetoSemClienteNoZimmer()
        {
            var unit = new MainUnitOfWork();
            var projetoRepository = new ProjetoRepository(unit);

            var projeto = new Projeto();
            projeto.Nome = "Teste de inclusão de Projeto sem Cliente";
            projeto.PackageId = 13;
            projeto.GenerateNewIdentity();

            projetoRepository.Add(projeto);

            unit.Commit();

            Assert.IsTrue(false, "Projeto incluido sem Cliente");
        }

        [TestMethod]
        public void ObterProjetoComGuidEmpty()
        {
            var unit = new MainUnitOfWork();
            var projetoRepository = new ProjetoRepository(unit);

            var projeto = projetoRepository.Get(Guid.Empty);

            Assert.IsNull(projeto, "Não pode retornar nenhum projeto quando o id é vazio");
        }

        [TestMethod]
        [ExpectedException(typeof(AssertFailedException))]
        public void IncluirProjetoSemPackegIDNoZimmer()
        {
            var unit = new MainUnitOfWork();
            var projetoRepository = new ProjetoRepository(unit);
            var clienteRepository = new ClienteRepository(unit);

            var projeto = new Projeto();
            var cliente = new Cliente();

            projeto.Nome = "Incluido teste de projeto";
            projeto.GenerateNewIdentity();

            cliente.Nome = "Incluido teste de Projeto";
            cliente.PackageId = 10;
            cliente.GenerateNewIdentity();
            cliente.Projetos = new List<Projeto>();
            cliente.Projetos.Add(projeto);

            clienteRepository.Add(cliente);

            unit.Commit();

            var clienteIncluido = clienteRepository.GetFiltered(s => s.Id == cliente.Id).FirstOrDefault();
            bool equals = clienteIncluido.Equals(cliente);

            Assert.IsTrue(false, "Cliente Cadastrado com PackageID 0.");
        }

        [TestMethod]
        [ExpectedException(typeof(AssertFailedException))]
        public void IncluirProjetoComUmPackegIDExistenteNoZimmer()
        {
            var unit = new MainUnitOfWork();

            var clienteRepository = new ClienteRepository(unit);
            var projetoRepository = new ProjetoRepository(unit);

            var projeto = new Projeto();
            projeto.Nome = "Incluir um projeto no Zimmer";
            projeto.PackageId = 13;
            projeto.GenerateNewIdentity();

            var cliente = new Cliente();
            cliente.Nome = "Incluir um projeto no Zimmer";
            cliente.PackageId = 13;
            cliente.GenerateNewIdentity();
            cliente.Projetos = new List<Projeto>();
            cliente.Projetos.Add(projeto);

            clienteRepository.Add(cliente);

            unit.Commit();

            var clienteIncluido = clienteRepository.GetFiltered(s => s.Id == cliente.Id).FirstOrDefault();
            var projetoIncluido = projetoRepository.GetFiltered(s => s.PackageId == cliente.PackageId).FirstOrDefault();
            bool equals = projetoIncluido.Equals(projeto);

            Assert.IsNull(equals, "Cliente Cadastrado com mesmo PackageID do Projeto.");
        }

        [TestMethod]
        public void IncluirAlterarExcluirProjetoNoZimmer()
        {
            var unit = new MainUnitOfWork();
            var clienteRepository = new ClienteRepository(unit);
            var projetoRepository = new ProjetoRepository(unit);

            var projeto = new Projeto();

            projeto.Nome = "Criando um projeto no Zimmer";
            projeto.PackageId = 13;
            projeto.GenerateNewIdentity();

            var cliente = new Cliente();
            cliente.Nome = "Criando um projeto no Zimmer";
            cliente.PackageId = 10;
            cliente.GenerateNewIdentity();
            cliente.Projetos = new List<Projeto>();
            cliente.Projetos.Add(projeto);

            clienteRepository.Add(cliente);

            unit.Commit();

            var clienteIncluido = clienteRepository.GetFiltered(s => s.Id == cliente.Id).FirstOrDefault();
            bool equals = clienteIncluido.Equals(cliente);
            projeto.Nome = "Teste:EditarUmProjetoNoZimmer";

            clienteRepository.Modify(cliente);
            unit.Commit();

            projetoRepository.Remove(projeto);
            unit.Commit();

            var projetoExcluido = projetoRepository.GetFiltered(s => s.Id == projeto.Id).FirstOrDefault();
            Assert.IsTrue(equals, "Não foi encontrado dados na tabela cliente do zimmer, talvez o método Seed não esteja funcional");
            Assert.IsNull(projetoExcluido, "Mesmo após ter excluido um cliente foi possível encontra-lo no banco de dados");

        }
        

    }
}
