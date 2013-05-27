using BSI.Zimmer.Aplicacao.DTO;
using BSI.Zimmer.Aplicacao.ModuloCheckList;
using BSI.Zimmer.Dominio.Repository;
using BSI.Zimmer.UI.Web.Controller.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;
using BSI.Zimmer.UI.Web.Controller;
using BSI.Zimmer.Infraestrutura.Comuns.Security;
using BSI.Zimmer.Dominio.Entity;

namespace BSI.Zimmer.UI.Web.Controller.Controllers
{
    public class LoginController : ZimmerControllerBase
    {

        private IUsuarioRepository _usuarioRepository;
        private IUsuarioRepository UsuarioRepository
        {
            get
            {
                return _usuarioRepository;
            }
        }


        public LoginController(IUsuarioRepository usuarioRepository, IApplicationContext applicationContext)
            : base(applicationContext)
        {
            _usuarioRepository = usuarioRepository;
        }

        public ActionResult Index()
        {
            var login = new LoginViewModel();

            return View(login);
        }

        public ActionResult Criar()
        {
            return View(CriarViewModel.Empty());
        }

        public JsonResult Logar(LoginViewModel viewModel)
        {
            var usuario = UsuarioRepository
                .GetFiltered(s => s.Login == viewModel.Login)
                .FirstOrDefault();

            if (usuario != null)
            {
                if(usuario.Senha != viewModel.Senha)
                    viewModel.DoError("Login e/ou Senha inválida", "Login de Acesso");
                else
                    viewModel.DoSuccess("Parabéns, aguarde enquanto te redirecionamos para seu DashBoard", "Acesso permitido");
            }
            else
                viewModel.DoError("Não conseguimos encontrar sua credencial, fale com o dorba para que ele faça seu cadastro inicial", "Login de Acesso");

            return Json(viewModel);
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
        }

        [HttpPost]
        public JsonResult Salvar(CriarViewModel viewModel)
        {

            viewModel.DoSuccess("Agora já sabemos quem é você e o que faz por aqui. Só um minuto enquanto te redirecionamos para sua página principal", "Parabéns!");

            Usuario usuario = viewModel.Traduzir<Usuario>();
            usuario.GenerateNewIdentity();

            var erros = usuario.DoIfIsValid<Usuario>(() =>
            {
                UsuarioRepository.Add(usuario);
                UsuarioRepository.UnitOfWork.Commit();
            });

            if (erros.HasErros())
                return Json(erros.GetViewModel());
                        
            return Json(viewModel);


        }


    }
}
