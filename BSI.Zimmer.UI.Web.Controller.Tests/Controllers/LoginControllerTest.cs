using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BSI.Zimmer.UI.Web.Controller.Controllers;
using BSI.Zimmer.Dominio.Repository;
using BSI.Zimmer.Dominio;
using BSI.Zimmer.Infraestrutura.Comuns.Security;
using BSI.Zimmer.UI.Web.Controller.ViewModel;
using BSI.Zimmer.Test.Mock.Infraestrutura.Persistencia.UnitOfWork;
using BSI.Zimmer.Test.Mock.Infraestrutura.Comuns.Security;
using BSI.Zimmer.Infraestrutura.Persistencia.Repository;

namespace BSI.Zimmer.UI.Web.Controller.Tests.Controllers
{
    [TestClass]
    public class CriarControllerTest
    {

        MockMainUnitOfWork _UnitOfWork;
        IUsuarioRepository _UsuarioRepository;
        IApplicationContext _ApplicationContext;

        [TestInitialize]
        public void TestInitialize()
        {
            _UnitOfWork = new MockMainUnitOfWork();
            _UsuarioRepository = new UsuarioRepository(_UnitOfWork);
            _ApplicationContext = new MockApplicationContext();
        }

        private CriarViewModel GetCriarViewModel()
        {
            CriarViewModel viewModel = new CriarViewModel();
            viewModel.Login = _ApplicationContext.Login;
            viewModel.Senha = "@abc123#$";
            viewModel.ConfirmaSenha = viewModel.Senha;
            viewModel.Nome = "Marcus Dorbação";
            viewModel.PerfilAcesso = new ItemListaModel(1, string.Empty);

            return viewModel;
        }

        [TestMethod]
        public void SalvarTest()
        {
            _ApplicationContext.Login = "mdorbacao";
            LoginController loginController = new LoginController(_UsuarioRepository, _ApplicationContext);

            var viewModel = GetCriarViewModel();

            var resultado = loginController.Salvar(viewModel);

            CriarViewModel viewModelResult = (CriarViewModel)resultado.Data;

            bool notHasError = !viewModelResult.HasError;
            bool hasSuccess = viewModelResult.HasSuccess;

            Assert.IsTrue(notHasError);
            Assert.IsTrue(hasSuccess);
        }

        [TestMethod]
        public void SalvarSenhaEConfirmaSenhaNotEqualTest()
        {
            _ApplicationContext.Login = "mdorbacao";
            LoginController loginController = new LoginController(_UsuarioRepository, _ApplicationContext);

            var viewModel = GetCriarViewModel();
            viewModel.ConfirmaSenha = viewModel.Senha + "123";

            var resultado = loginController.Salvar(viewModel);

            CriarViewModel viewModelResult = (CriarViewModel)resultado.Data;

            bool hasError = viewModelResult.HasError;
            bool hasSuccess = viewModelResult.HasSuccess;

            Assert.IsTrue(hasError);
            Assert.IsFalse(hasSuccess);
            Assert.IsTrue(viewModelResult.Mensagem.Contains(""));
        }

        [TestMethod]
        public void SalvarSenhaNaoInformadaTest()
        {
            //validationResults.Add(new ValidationResult(Messages.ValidationUsuarioLoginNaoPodeSerNulo));
            //validationResults.Add(new ValidationResult(Messages.ValidationUsuarioNomeNaoPodeSerNulo));
            //validationResults.Add(new ValidationResult(Messages.ValidationUsuarioSenhaNaoPodeSerNulo));
            //validationResults.Add(new ValidationResult(Messages.ValidationUsuarioPerfilAcessoNaoPodeSerNulo));


            _ApplicationContext.Login = "mdorbacao";
            LoginController loginController = new LoginController(_UsuarioRepository, _ApplicationContext);

            var viewModel = GetCriarViewModel();
            viewModel.Senha = string.Empty;

            var resultado = loginController.Salvar(viewModel);

            ViewModelBase viewModelResult = (ViewModelBase)resultado.Data;

            bool hasError = viewModelResult.HasError;
            bool hasSuccess = viewModelResult.HasSuccess;

            Assert.IsTrue(hasError);
            Assert.IsFalse(hasSuccess);
            Assert.IsTrue(viewModelResult.Mensagem.Contains(Messages.ValidationUsuarioSenhaNaoPodeSerNulo));
        }


        [TestMethod]
        public void Logar()
        {
            _ApplicationContext.Login = "mdorbacao";
            LoginController loginController = new LoginController(_UsuarioRepository, _ApplicationContext);

            var viewModel = GetCriarViewModel();

            var resultado = loginController.Salvar(viewModel);

            CriarViewModel viewModelResult = (CriarViewModel)resultado.Data;

            bool notHasError = !viewModelResult.HasError;
            bool hasSuccess = viewModelResult.HasSuccess;

            Assert.IsTrue(notHasError);
            Assert.IsTrue(hasSuccess);

            var loginViewModel = new LoginViewModel();
            loginViewModel.Login = "mdorbacao";
            loginViewModel.Senha = "@abc123#$";

            var resultadoLogar = loginController.Logar(loginViewModel);

            LoginViewModel loginViewModelResult = (LoginViewModel)resultadoLogar.Data;

            Assert.IsFalse(loginViewModelResult.HasError);
            Assert.IsTrue(loginViewModelResult.HasSuccess);


        }
    }
}
