using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSI.Zimmer.Dominio.Specification
{
    public abstract class CompositeSpecification<TEntity> : Specification<TEntity> where TEntity:class
    {
        public abstract ISpecification<TEntity> LeftSpecification { get; }

        public abstract ISpecification<TEntity> RightSpecification { get; }
    }
}
