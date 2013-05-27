using BSI.Zimmer.Dominio;
using BSI.Zimmer.Dominio.Entity;
using BSI.Zimmer.Test.Mock.Infraestrutura.Persistencia.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSI.Zimmer.Test.Mock.Infraestrutura.Persistencia.UnitOfWork
{
    public class MockMainUnitOfWork : IQueryableUnitOfWork
    {

        #region IDbSet Members

        IDbSet<Artefato> _artefato;
        public IDbSet<Artefato> Artefatos
        {
            get
            {
                if (_artefato == null)
                    _artefato = new MockDbSet<Artefato>();

                return _artefato;
            }
        }




        IDbSet<Projeto> _projeto;
        public IDbSet<Projeto> Projeto
        {
            get
            {
                if (_projeto == null)
                    _projeto = new MockDbSet<Projeto>();

                return _projeto;
            }
        }

        IDbSet<CheckList> _checklist;
        public IDbSet<CheckList> Checklist
        {
            get
            {
                if (_checklist == null)
                    _checklist = new MockDbSet<CheckList>();

                return _checklist;
            }
        }


        IDbSet<Questao> _questao;
        public IDbSet<Questao> Questao
        {
            get
            {
                if (_questao == null)
                    _questao = new MockDbSet<Questao>();

                return _questao;
            }
        }


        IDbSet<CategoriaQuestao> _categoriaQuestao;
        public IDbSet<CategoriaQuestao> CategoriaQuestao
        {
            get
            {
                if (_categoriaQuestao == null)
                    _categoriaQuestao = new MockDbSet<CategoriaQuestao>();

                return _categoriaQuestao;
            }
        }

        IDbSet<Avaliacao> _avaliacao;
        public IDbSet<Avaliacao> Avaliacao
        {
            get
            {
                if (_avaliacao == null)
                    _avaliacao = new MockDbSet<Avaliacao>();

                return _avaliacao;
            }
        }

        IDbSet<Usuario> _usuarios;
        public IDbSet<Usuario> Usuarios
        {
            get
            {
                if (_usuarios == null)
                    _usuarios = new MockDbSet<Usuario>();

                return _usuarios;
            }
        }


        IDbSet<QuestaoAvaliada> _questaoAvaliada;
        public IDbSet<QuestaoAvaliada> QuestaoAvaliada
        {
            get
            {
                if (_questaoAvaliada == null)
                    _questaoAvaliada = new MockDbSet<QuestaoAvaliada>();

                return _questaoAvaliada;
            }
        }


        #endregion

        #region IQueryableUnitOfWork Members

        public IDbSet<TEntity> CreateSet<TEntity>()
            where TEntity : class
        {
            //return base.Set<TEntity>();
            return new MockDbSet<TEntity>();            
        }

        public void Attach<TEntity>(TEntity item)
            where TEntity : class
        {
            //attach and set as unchanged
            //base.Entry<TEntity>(item).State = System.Data.EntityState.Unchanged;
            
        }

        public void SetModified<TEntity>(TEntity item)
            where TEntity : class
        {
            //this operation also attach item in object state manager
            //base.Entry<TEntity>(item).State = System.Data.EntityState.Modified;
            
        }
        public void ApplyCurrentValues<TEntity>(TEntity original, TEntity current)
            where TEntity : class
        {
            //if it is not attached, attach original and set current values
            //base.Entry<TEntity>(original).CurrentValues.SetValues(current);
            
        }

        public void Commit()
        {
            //base.SaveChanges();
            
        }

        public void CommitAndRefreshChanges()
        {
            bool saveFailed = false;

            do
            {
                try
                {
                    //base.SaveChanges();

                    saveFailed = false;

                }
                catch (DbUpdateConcurrencyException ex)
                {
                    saveFailed = true;

                    ex.Entries.ToList()
                              .ForEach(entry =>
                              {
                                  entry.OriginalValues.SetValues(entry.GetDatabaseValues());
                              });

                }
            } while (saveFailed);

        }

        public void RollbackChanges()
        {
            // set all entities in change tracker 
            // as 'unchanged state'
            //base.ChangeTracker.Entries().ToList().ForEach(entry => entry.State = System.Data.EntityState.Unchanged);
        }

        public IEnumerable<TEntity> ExecuteQuery<TEntity>(string sqlQuery, params object[] parameters)
        {
            //return base.Database.SqlQuery<TEntity>(sqlQuery, parameters);
            return null;
        }

        public int ExecuteCommand(string sqlCommand, params object[] parameters)
        {
            //return base.Database.ExecuteSqlCommand(sqlCommand, parameters);
            return 0;
        }

        #endregion


        public void Dispose()
        {
            
        }
    }
}
