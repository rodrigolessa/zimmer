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

namespace BSI.Zimmer.UI.Web.Controller.Controllers
{
    public class DashBoardController : ZimmerControllerBase
    {
        public DashBoardController(IApplicationContext applicationContext)
            : base(applicationContext)
        {

        }


        public ActionResult Index()
        {
            return View();
        }

    }
}
