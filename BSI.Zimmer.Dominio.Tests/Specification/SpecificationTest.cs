using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BSI.Zimmer.Dominio.Specification;
using BSI.Zimmer.Dominio.Tests.Specification.Stub;
using System.Linq.Expressions;

namespace BSI.Zimmer.Dominio.Tests.Specification
{
    [TestClass]
    public class SpecificationTest
    {
        [TestMethod()]
        public void TestaSpecification()
        {
            Expression<Func<ClienteStub, bool>> specification = s => string.IsNullOrWhiteSpace(s.Nome) == false;

            var directSpecification = new DirectSpecification<ClienteStub>(specification);

            Assert.ReferenceEquals(new PrivateObject(directSpecification).GetField("_MatchingCriteria"), specification);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CriaSpecificationComLambdaNullEThrowArgumentNullExceptionTest()
        {
            //Arrange
            DirectSpecification<ClienteStub> adHocSpecification;
            Expression<Func<ClienteStub, bool>> spec = null;

            //Act
            adHocSpecification = new DirectSpecification<ClienteStub>(spec);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CriaAndSpecificationComLambdaLeftNullEThrowArgumentNullExceptionTest()
        {
            //Arrange
            CompositeSpecification<ClienteStub> compoSpecification;
            Expression<Func<ClienteStub, bool>> lambda = s => s.Nome != string.Empty;

            DirectSpecification<ClienteStub> direct = new DirectSpecification<ClienteStub>(lambda);

            //Act
            compoSpecification = new AndSpecification<ClienteStub>(null, direct);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CriaAndSpecificationComLambdaRightNullEThrowArgumentNullExceptionTest()
        {
            //Arrange
            CompositeSpecification<ClienteStub> compoSpecification;
            Expression<Func<ClienteStub, bool>> lambda = s => s.Nome != string.Empty;

            DirectSpecification<ClienteStub> direct = new DirectSpecification<ClienteStub>(lambda);

            //Act
            compoSpecification = new AndSpecification<ClienteStub>(direct, null);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CriaOrSpecificationComLambdaLeftNullEThrowArgumentNullExceptionTest()
        {
            //Arrange
            CompositeSpecification<ClienteStub> compoSpecification;
            Expression<Func<ClienteStub, bool>> lambda = s => s.Nome != string.Empty;

            DirectSpecification<ClienteStub> direct = new DirectSpecification<ClienteStub>(lambda);

            //Act
            compoSpecification = new OrSpecification<ClienteStub>(null, direct);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CriaOrSpecificationComLambdaRightNullEThrowArgumentNullExceptionTest()
        {
            //Arrange
            CompositeSpecification<ClienteStub> compoSpecification;
            Expression<Func<ClienteStub, bool>> lambda = s => s.Nome != string.Empty;

            DirectSpecification<ClienteStub> direct = new DirectSpecification<ClienteStub>(lambda);

            //Act
            compoSpecification = new OrSpecification<ClienteStub>(direct, null);
        }

        [TestMethod]
        public void CriaAndSpecificationTest()
        {
            Expression<Func<ClienteStub, bool>> leftLambda = s => string.IsNullOrWhiteSpace(s.Nome) == false;
            Expression<Func<ClienteStub, bool>> rightLambda = s => s.Nome.ToUpper() != "MARCUS";

            var leftSpecification = new DirectSpecification<ClienteStub>(leftLambda);
            var rightSpecification = new DirectSpecification<ClienteStub>(rightLambda);

            CompositeSpecification<ClienteStub> andSpec = new AndSpecification<ClienteStub>(leftSpecification, rightSpecification);

            List<ClienteStub> listaCliente = new List<ClienteStub>();

            listaCliente.Add(new ClienteStub() { Nome = "luiz" });

            var result = listaCliente.AsQueryable().Where(andSpec.SatisfiedBy()).ToList();

            Assert.IsTrue(result.Count == 1);
        }

        [TestMethod]
        public void CriaOrSpecificationPassedTest()
        {
            Expression<Func<ClienteStub, bool>> leftLambda = s => s.Nome == "MARCUS";
            Expression<Func<ClienteStub, bool>> rightLambda = s => s.Nome == "VINICIUS";

            var leftSpecification = new DirectSpecification<ClienteStub>(leftLambda);
            var rightSpecification = new DirectSpecification<ClienteStub>(rightLambda);

            CompositeSpecification<ClienteStub> andSpec = new OrSpecification<ClienteStub>(leftSpecification, rightSpecification);

            List<ClienteStub> listaCliente = new List<ClienteStub>();

            listaCliente.Add(new ClienteStub() { Nome = "MARCUS" });

            var result = listaCliente.AsQueryable().Where(andSpec.SatisfiedBy()).ToList();

            Assert.IsTrue(result.Count == 1);
        }

        [TestMethod]
        public void CriaOrSpecificationNotPassedTest()
        {
            Expression<Func<ClienteStub, bool>> leftLambda = s => s.Nome == "MARCUS";
            Expression<Func<ClienteStub, bool>> rightLambda = s => s.Nome == "VINICIUS";

            var leftSpecification = new DirectSpecification<ClienteStub>(leftLambda);
            var rightSpecification = new DirectSpecification<ClienteStub>(rightLambda);

            CompositeSpecification<ClienteStub> andSpec = new OrSpecification<ClienteStub>(leftSpecification, rightSpecification);

            List<ClienteStub> listaCliente = new List<ClienteStub>();

            listaCliente.Add(new ClienteStub() { Nome = "CARREIRA" });

            var result = listaCliente.AsQueryable().Where(andSpec.SatisfiedBy()).ToList();

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void CriaNotSpecificationTest()
        {
            Expression<Func<ClienteStub, bool>> leftLambda = s => s.Nome == "MARCUS";

            var leftSpecification = new DirectSpecification<ClienteStub>(leftLambda);

            Specification<ClienteStub> andSpec = new NotSpecification<ClienteStub>(leftSpecification);

            List<ClienteStub> listaCliente = new List<ClienteStub>();

            listaCliente.Add(new ClienteStub() { Nome = "MARCUS" });

            var result = listaCliente.AsQueryable().Where(andSpec.SatisfiedBy()).ToList();

            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void CriaNotSpecificationTest2()
        {
            Expression<Func<ClienteStub, bool>> leftLambda = s => s.Nome == "MARCUS";

            var leftSpecification = new DirectSpecification<ClienteStub>(leftLambda);

            Specification<ClienteStub> notSpec = new NotSpecification<ClienteStub>(leftSpecification);


            List<ClienteStub> listaCliente = new List<ClienteStub>();

            listaCliente.Add(new ClienteStub() { Nome = "VINICIUS" });

            var result = listaCliente.AsQueryable().Where(notSpec.SatisfiedBy()).ToList();

            Assert.IsTrue(result.Count == 1);
        }

        [TestMethod]
        public void CriaTrueSpecificationTest()
        {
            Expression<Func<ClienteStub, bool>> leftLambda = s => s.Nome == "MARCUS";

            var leftSpecification = new DirectSpecification<ClienteStub>(leftLambda);

            Specification<ClienteStub> andSpec = new TrueSpecification<ClienteStub>();

            List<ClienteStub> listaCliente = new List<ClienteStub>();

            listaCliente.Add(new ClienteStub() { Nome = "VINICIUS" });

            var result = listaCliente.AsQueryable().Where(andSpec.SatisfiedBy()).ToList();

            Assert.IsTrue(result.Count == 1);
        }


    }
}
