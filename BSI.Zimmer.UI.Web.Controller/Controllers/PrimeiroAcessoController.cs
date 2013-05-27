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
using BSI.Zimmer.Dominio.Entity;
using BSI.Zimmer.Infraestrutura.Comuns.Validator;
using BSI.Zimmer.Infraestrutura.Comuns.Security;

namespace BSI.Zimmer.UI.Web.Controller.Controllers
{
    public class PrimeiroAcessoController : ZimmerControllerBase
    {
        private IUsuarioRepository _usuarioRepository;
        private IUsuarioRepository UsuarioRepository
        {
            get
            {
                return _usuarioRepository;
            }
        }

        public PrimeiroAcessoController(IUsuarioRepository usuarioRepository, IApplicationContext applicationContext)
            : base(applicationContext)
        {
            _usuarioRepository = usuarioRepository;
        }

        public ActionResult Index()
        {
            var usuario = UsuarioRepository.GetFiltered(s => s.Login == this.ApplicationContext.Login).FirstOrDefault();

            if (usuario != null)
                return RedirectToAction("Index", "DashBoard");

            var viewModel = CriarViewModel.Empty();

            return View(viewModel);
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
        }

        [HttpPost]
        public JsonResult DefinirPerfil(CriarViewModel viewModel)
        {

            viewModel.DoSuccess("Agora já sabemos quem é você e o que faz por aqui. Clique no botão abaixo para seguir para sua dashboard", "Parabéns!");

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
