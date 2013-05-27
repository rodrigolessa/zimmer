using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BSI.Zimmer.Infraestrutura.Comuns.Logging;
using BSI.Zimmer.Infraestrutura.Comuns.Validator;
using BSI.Zimmer.Infraestrutura.Comuns.Tests.Validator.Stub;
using System.Linq;

namespace BSI.Zimmer.Infraestrutura.Comuns.Tests
{
    [TestClass]
    public class ValidatorsTest
    {

        #region Class Initialize

        [ClassInitialize()]
        public static void ClassInitialze(TestContext context)
        {            
            EntityValidatorFactory.SetCurrent(new DataAnnotationsEntityValidatorFactory());
        }

        #endregion


        [TestMethod()]
        public void EntidadeComAtributoObrigatorio()
        {
            //Arrange
            var entidadeA = new EntidadeComAtributoDeValidacao();
            entidadeA.PropriedadeObrigatoria= null;

            IEntityValidator entityValidator = EntityValidatorFactory.CreateValidator();

            //Act
            var entityAValidationResult = entityValidator.IsValid(entidadeA);
            var entityAInvalidMessages = entityValidator.GetInvalidMessages(entidadeA);


            //Assert
            Assert.IsFalse(entityAValidationResult);

            Assert.IsTrue(entityAInvalidMessages.Any());
        }

        [TestMethod()]
        public void EntidadeValidavelComAtributoObrigatorio()
        {
            //Arrange
            var entidadeA = new EntidadeValidavel();
            entidadeA.PropriedadeObrigatoria = null;

            IEntityValidator entityValidator = EntityValidatorFactory.CreateValidator();

            //Act
            var entityAValidationResult = entityValidator.IsValid(entidadeA);
            var entityAInvalidMessages = entityValidator.GetInvalidMessages(entidadeA);


            //Assert
            Assert.IsFalse(entityAValidationResult);

            Assert.IsTrue(entityAInvalidMessages.Any());
        }

        [TestMethod()]
        public void TestaValidatorDaEntidadeNula()
        {
            //Arrange
            EntidadeValidavel entidadeA = null;

            IEntityValidator entityValidator = EntityValidatorFactory.CreateValidator();

            //Act
            var entityAValidationResult = entityValidator.IsValid(entidadeA);
            var entityAInvalidMessages = entityValidator.GetInvalidMessages(entidadeA);


            //Assert
            Assert.IsFalse(entityAValidationResult);

            Assert.IsFalse(entityAInvalidMessages.Any());
        }

    }
}
