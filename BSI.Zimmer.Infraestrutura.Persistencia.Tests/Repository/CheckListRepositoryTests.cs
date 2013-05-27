using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BSI.Zimmer.Infraestrutura.Persistencia.UnitOfWork;
using BSI.Zimmer.Infraestrutura.Persistencia.Repository;
using System.Linq;
using BSI.Zimmer.Dominio.Entity;
using System.Data.Entity.Validation;
using System.Collections.Generic;

namespace BSI.Zimmer.Infraestrutura.Persistencia.Tests.Repository
{
    [TestMethod]
    public class CheckListRepositoryTests
    {
        [TestMethod]
        public void IncluirCheckListZimmer()
        {
            var unit = new MainUnitOfWork();
            var checkListRepository = new CheckListRepository(unit);

            var check = new CheckList();
            check.Nome = "Teste de inclusão";
            check.Descricao = "Inclusão";
            check.Artefato.CodigoArtefatoEA = 110;

            var questao = new Questao();
            questao.Nome = "Teste de questão";
            questao.GenerateNewIdentity();
            questao.Descricao = "teste";
            questao.DeveEvitar = "inclusão de caracteres especiais";
            questao.DeveSeguir = "Processo todo de inclusão";
            questao.Evidencia = "T2";

        }



    }
}
