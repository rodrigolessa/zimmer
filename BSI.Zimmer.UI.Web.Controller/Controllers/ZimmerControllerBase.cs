using BSI.Zimmer.Infraestrutura.Comuns.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSI.Zimmer.UI.Web.Controller.Controllers
{
    public class ZimmerControllerBase : System.Web.Mvc.Controller
    {
        protected IApplicationContext ApplicationContext;

        public ZimmerControllerBase(IApplicationContext applicationContext)
        {
            ApplicationContext = applicationContext;
        }

        public ZimmerControllerBase()
        {

        }
    }
}
