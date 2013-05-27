using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;
using BSI.Zimmer.Infraestrutura.Persistencia.UnitOfWork;

namespace BSI.Zimmer.Infraestrutura.Persistencia.Tests.Initializers
{
    [TestClass]
    public class AssemblyTestsInitialize
    {
        [AssemblyInitialize()]
        public static void RebuildUnitOfWork(TestContext context)
        {
            //Set default initializer for MainBCUnitOfWork
            Database.SetInitializer<MainUnitOfWork>(new MainUnitOfWorkInitializer());            
        }
    }
}
