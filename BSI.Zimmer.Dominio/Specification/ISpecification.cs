﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BSI.Zimmer.Dominio.Specification
{
    public interface ISpecification<TEntity> where TEntity :class
    {
        Expression<Func<TEntity, bool>> SatisfiedBy();
    }
}
