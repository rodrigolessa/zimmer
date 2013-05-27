using AutoMapper;
using BSI.Zimmer.Infraestrutura.Comuns.Adapter;
using BSI.Zimmer.Infraestrutura.Comuns.Validator;
using BSI.Zimmer.Test.Mock;
using BSI.Zimmer.UI.Web.Controller.ProfileMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSI.Zimmer.UI.Web.Controller.Tests.Initialize
{
    [TestClass]
    public class Initialize
    {
        [AssemblyInitialize()]
        public static void InicializandoFabricas(TestContext context)
        {
            MockInitialize.InitializeTypeAdapter();

            MockInitialize.InitializeEntityValidator();

            MockInitialize.InitializeProfileMapper();
        }

    }
}
