using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BSI.Zimmer.Infraestrutura.Comuns.Logging;

namespace BSI.Zimmer.Infraestrutura.Comuns.Tests.Logging
{
    [TestClass]
    public class TraceSourceLogTest
    {

        #region Class Initialize

        [ClassInitialize()]
        public static void ClassInitialze(TestContext context)
        {
            // Initialize default log factory
            LoggerFactory.SetCurrent(new TraceSourceLogFactory());
        }

        #endregion

        [TestMethod()]
        public void LogInfo()
        {
            //Arrange
            ILogger log = LoggerFactory.CreateLog();

            //Act
            log.LogInfo("{0}", "log do tipo informação");
        }
        [TestMethod()]
        public void LogWarning()
        {
            //Arrange
            ILogger log = LoggerFactory.CreateLog();

            //Act
            log.LogWarning("{0}", "log fo tipo alerta");
        }
        [TestMethod()]
        public void LogError()
        {
            //Arrange
            ILogger log = LoggerFactory.CreateLog();

            //Act
            log.LogError("{0}", "log do tipo erro");
        }

        [TestMethod()]
        public void LogErrorWithException()
        {
            //Arrange
            ILogger log = LoggerFactory.CreateLog();

            //Act
            log.LogError("{0}", new ArgumentNullException("param"), "log erro com exception");
        }
        [TestMethod()]
        public void LogDebugWithObject()
        {
            //Arrange
            ILogger log = LoggerFactory.CreateLog();

            //Act
            log.Debug(new object());
        }
        [TestMethod()]
        public void LogDebugWithMessage()
        {
            //Arrange
            ILogger log = LoggerFactory.CreateLog();

            //Act
            log.Debug("{0}", "log debug com mensagem");
        }
        [TestMethod()]
        public void LogDebugWithException()
        {
            //Arrange
            ILogger log = LoggerFactory.CreateLog();

            //Act
            log.Debug("{0}", new ArgumentNullException("param"), "log debug com exception");
        }
        [TestMethod()]
        public void LogFatalWithMessage()
        {
            //Arrange
            ILogger log = LoggerFactory.CreateLog();

            //Act
            log.Fatal("{0}", "erro fatal com mensagem");
        }
        [TestMethod()]
        public void LogFatalWithException()
        {
            //Arrange
            ILogger log = LoggerFactory.CreateLog();

            //Act
            log.Fatal("{0}", new ArgumentNullException("param"), "erro fatal com exception");
        }

    }
}
