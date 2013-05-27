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
    public class UsuarioProfileTest
    {
        [TestMethod]
        public void UsuarioToPrimeiroAcessoViewModel()
        {
            Mapper.Initialize(cfg => cfg.AddProfile(new UsuarioProfile()));

            Usuario usuario = new Usuario() { Login = "mdorbacao", Nome = "Marcus" };
            
            usuario.PerfilAcesso = PerfilAcesso.AnalistaRequisitos;

            var model = usuario.Traduzir<CriarViewModel>();

            var loginEqual = model.Login == usuario.Nome;
            var perfilEqual = model.PerfilAcesso.Id.Value == (int)usuario.PerfilAcesso;

            var equals = loginEqual && perfilEqual;

            Assert.IsTrue(equals);
        }
    }
}
