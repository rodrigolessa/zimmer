using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BSI.Zimmer.Infraestrutura.Persistencia.UnitOfWork;
using BSI.Zimmer.Infraestrutura.Persistencia.Repository;
using System.Linq;
using BSI.Zimmer.Dominio.Entity;
using System.Data.Entity.Validation;

namespace BSI.Zimmer.Infraestrutura.Persistencia.Repository.Tests
{
    [TestClass]
    public class ArtefatoRepositoryTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var unit = new MainUnitOfWork();
            var artefatoRepository = new ArtefatoRepository(unit);

            var selectedArtefato = new Guid("0343C0B0-7C40-444A-B044-B463F36A1A1F");

            var artefato = artefatoRepository.Get(selectedArtefato);

            Assert.IsNotNull(artefato);

        }

        [TestMethod]
        public void VerificaSeDadosForamMigradosDoEAParaOZimmer()
        {
            var unit = new MainUnitOfWork();
            var artefatoRepository = new ArtefatoRepository(unit);

            var all = artefatoRepository.GetAll();

            Assert.IsNotNull(all);
            Assert.IsTrue(all.Count() > 0, "Não foi encontrado dados na tabela Artefato do zimmer, talvez o método Seed não esteja funcional");
        }

    }
}
