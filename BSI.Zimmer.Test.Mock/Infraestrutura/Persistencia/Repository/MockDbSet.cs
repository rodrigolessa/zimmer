using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSI.Zimmer.Test.Mock.Infraestrutura.Persistencia.Repository
{
    public class MockDbSet<TEntity> : System.Data.Entity.IDbSet<TEntity> where TEntity : class
    {
        readonly HashSet<TEntity> _set;
        readonly IQueryable<TEntity> _queryableSet;

        public MockDbSet()
            : this(Enumerable.Empty<TEntity>())
        {

        }

        public MockDbSet(IEnumerable<TEntity> entities)
        {
            _set = new HashSet<TEntity>();
            foreach (var entity in entities)
            {
                _set.Add(entity);
            }
            _queryableSet = _set.AsQueryable();
        }

        public TEntity Add(TEntity entity)
        {
            _set.Add(entity);
            return entity;
        }

        public TEntity Attach(TEntity entity)
        {
            _set.Add(entity);
            return entity;
        }

        public TDerivedEntity Create<TDerivedEntity>() where TDerivedEntity : class, TEntity
        {
            throw new NotImplementedException();
        }

        public TEntity Create()
        {
            return (TEntity)Activator.CreateInstance(typeof(TEntity));
        }

        public TEntity Find(params object[] keyValues)
        {
            throw new NotImplementedException();
        }

        public System.Collections.ObjectModel.ObservableCollection<TEntity> Local
        {
            get { throw new NotImplementedException(); }
        }

        public TEntity Remove(TEntity entity)
        {
            _set.Remove(entity);
            return entity;
        }

        public IEnumerator<TEntity> GetEnumerator()
        {
            return _set.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _set.GetEnumerator();
        }

        public Type ElementType
        {
            get
            {
                return _queryableSet.ElementType;
            }
        }

        public System.Linq.Expressions.Expression Expression
        {
            get
            {
                return _queryableSet.Expression;
            }
        }

        public IQueryProvider Provider
        {
            get
            {
                return _queryableSet.Provider;
            }
        }
    }
}
