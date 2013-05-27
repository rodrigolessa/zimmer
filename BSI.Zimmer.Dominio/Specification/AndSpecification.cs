using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BSI.Zimmer.Dominio.Specification
{
    public class AndSpecification<T> : CompositeSpecification<T> where T:class
    {

        private ISpecification<T> leftSpecification = null;
        private ISpecification<T> rightSpecification = null;

        public override ISpecification<T> LeftSpecification
        {
            get { return leftSpecification; }
        }

        public override ISpecification<T> RightSpecification
        {
            get { return rightSpecification; }
        }

        public AndSpecification(ISpecification<T> left, ISpecification<T> right)
        {
            if (left == (ISpecification<T>)null)
                throw new ArgumentNullException("left");

            if (right == (ISpecification<T>)null)
                throw new ArgumentNullException("right");

            this.leftSpecification = left;
            this.rightSpecification = right;
        }


        public override Expression<Func<T, bool>> SatisfiedBy()
        {
            Expression<Func<T, bool>> left = leftSpecification.SatisfiedBy();
            Expression<Func<T, bool>> right = rightSpecification.SatisfiedBy();
            
            return left.And(right);
        }
    }
}
