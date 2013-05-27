using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BSI.Zimmer.Dominio.Entity;
using System.Collections.Generic;
using BSI.Zimmer.UI.Web.Controller.ViewModel;
using BSI.Zimmer.UI.Web.Controller.ProfileMapper;
using AutoMapper;

namespace BSI.Zimmer.UI.Web.Controller.Tests.ProfileMapper
{
    [TestClass]
    public class CriarViewModelProfileTest
    {
        [TestMethod]
        public void CriarViewModelToUsuario()
        {            

            CriarViewModel viewModel = new CriarViewModel()
            {
                Senha = "123456",
                ConfirmaSenha = "123456",
                Login = "loginteste",
                Nome = "marcusdorbacao",
                PerfilAcesso = new ItemListaModel(1, "descricaoteste"),
            };

            var usuario = viewModel.Traduzir<Usuario>();

            var equalConfirmaSenha = viewModel.Senha == viewModel.ConfirmaSenha;
            var equalSenha = viewModel.Senha == usuario.Senha;
            var equalLogin = viewModel.Login == usuario.Login;
            var equalNome = viewModel.Nome == usuario.Nome;
            var perfilAcessoNotNull = viewModel.PerfilAcesso != null;
            var idNotNull = viewModel.PerfilAcesso.Id.HasValue;
            var equalIdPerfilAcesso = viewModel.PerfilAcesso.Id.Value == (int)usuario.PerfilAcesso;

            var equals = equalConfirmaSenha
                        && equalSenha
                        && equalLogin
                        && equalNome
                        && perfilAcessoNotNull
                        && idNotNull
                        && equalIdPerfilAcesso;

            Assert.IsTrue(equals);
        }
    }
}
