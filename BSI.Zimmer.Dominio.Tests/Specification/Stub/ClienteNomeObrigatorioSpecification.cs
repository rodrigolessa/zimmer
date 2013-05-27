using BSI.Zimmer.Dominio.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BSI.Zimmer.Dominio.Tests.Specification.Stub
{
    public class ClienteNomeObrigatorioSpecification<T> : Specification<T> where T : ClienteStub
    {
        public ClienteNomeObrigatorioSpecification(T cliente)
        {
            clienteStub = cliente;
        }

        private ClienteStub clienteStub = null;

        public override Expression<Func<T, bool>> SatisfiedBy()
        {
            Expression<Func<T, bool>> leftSpec = s => string.IsNullOrWhiteSpace(s.Nome) == false;
            return leftSpec;
        }

    }
}
