


using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Configuration;
using System.Globalization;

namespace BSI.Zimmer.UI.Web.Tests.Globalization
{
    [TestClass]    
    public class FormatacaoDataTest
    {

        [TestInitialize()]
        public void TestInitialize()
        {
            var culture = new CultureInfo("pt-BR");
            System.Threading.Thread.CurrentThread.CurrentCulture = culture;
            System.Threading.Thread.CurrentThread.CurrentUICulture = culture;
        }

        [TestMethod]
        public void TestaFormatoDataConformeLocalizacao()
        {                        
            //Prepara
            DateTime date = new DateTime(2012, 12, 8);

            //EN = 12/08/2012
            //PT = 08/12/2012

            //Executa
            string data = date.ToShortDateString();

            //Verifica
            Assert.AreEqual(data, "08/12/2012");

        }

    }
}


