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
    public class UsuarioRepositoryTests
    {
        [TestMethod]
        public void ObterUsuarioPeloLogin()
        {
            var unit = new MainUnitOfWork();
            var usuarioRepository = new UsuarioRepository(unit);

            var usuario = new Usuario();
            usuario.Login = "testeUsuarioLogin";
            usuario.Nome = "teste";
            usuario.PerfilAcesso = PerfilAcesso.Desenvolvedor;
            
            usuario.GenerateNewIdentity();

            usuarioRepository.Add(usuario);
            unit.CommitAndRefreshChanges();

            var usuarioCadastrado = usuarioRepository.GetByLogin(usuario.Login).FirstOrDefault();

            Assert.IsNotNull(usuarioCadastrado);
            Assert.IsTrue(usuarioCadastrado.Login == usuario.Login, "Não foi encontrado dados na tabela projeto do zimmer, talvez o método Seed não esteja funcional");

        }

    }
}
