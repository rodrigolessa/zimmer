using BSI.Zimmer.Dominio;
using BSI.Zimmer.Dominio.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using BSI.Zimmer.Infraestrutura.Persistencia.UnitOfWork.Mapping;

namespace BSI.Zimmer.Infraestrutura.Persistencia.UnitOfWork
{
    public class MainUnitOfWork : DbContext, IQueryableUnitOfWork
    {

        #region IDbSet Members

        IDbSet<Artefato> _artefato;
        public IDbSet<Artefato> Artefatos
        {
            get
            {
                if (_artefato == null)
                    _artefato = base.Set<Artefato>();

                return _artefato;
            }
        }




        IDbSet<Projeto> _projeto;
        public IDbSet<Projeto> Projeto
        {
            get
            {
                if (_projeto == null)
                    _projeto = base.Set<Projeto>();

                return _projeto;
            }
        }

        IDbSet<CheckList> _checklist;
        public IDbSet<CheckList> Checklist
        {
            get
            {
                if (_checklist == null)
                    _checklist = base.Set<CheckList>();

                return _checklist;
            }
        }


        IDbSet<Questao> _questao;
        public IDbSet<Questao> Questao
        {
            get
            {
                if (_questao == null)
                    _questao = base.Set<Questao>();

                return _questao;
            }
        }


        IDbSet<CategoriaQuestao> _categoriaQuestao;
        public IDbSet<CategoriaQuestao> CategoriaQuestao
        {
            get
            {
                if (_categoriaQuestao == null)
                    _categoriaQuestao = base.Set<CategoriaQuestao>();

                return _categoriaQuestao;
            }
        }

        IDbSet<Avaliacao> _avaliacao;
        public IDbSet<Avaliacao> Avaliacao
        {
            get
            {
                if (_avaliacao == null)
                    _avaliacao = base.Set<Avaliacao>();

                return _avaliacao;
            }
        }

        IDbSet<Usuario> _usuarios;
        public IDbSet<Usuario> Usuarios
        {
            get
            {
                if (_usuarios == null)
                    _usuarios = base.Set<Usuario>();

                return _usuarios;
            }
        }


        IDbSet<QuestaoAvaliada> _questaoAvaliada;
        public IDbSet<QuestaoAvaliada> QuestaoAvaliada
        {
            get
            {
                if (_questaoAvaliada == null)
                    _questaoAvaliada = base.Set<QuestaoAvaliada>();

                return _questaoAvaliada;
            }
        }


        #endregion

        #region IQueryableUnitOfWork Members

        public IDbSet<TEntity> CreateSet<TEntity>()
            where TEntity : class
        {
            return base.Set<TEntity>();
        }

        public void Attach<TEntity>(TEntity item)
            where TEntity : class
        {
            //attach and set as unchanged
            base.Entry<TEntity>(item).State = System.Data.EntityState.Unchanged;
        }

        public void SetModified<TEntity>(TEntity item)
            where TEntity : class
        {
            //this operation also attach item in object state manager
            base.Entry<TEntity>(item).State = System.Data.EntityState.Modified;
        }
        public void ApplyCurrentValues<TEntity>(TEntity original, TEntity current)
            where TEntity : class
        {
            //if it is not attached, attach original and set current values
            base.Entry<TEntity>(original).CurrentValues.SetValues(current);
        }

        public void Commit()
        {
            base.SaveChanges();
        }

        public void CommitAndRefreshChanges()
        {
            bool saveFailed = false;

            do
            {
                try
                {
                    base.SaveChanges();

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
            base.ChangeTracker.Entries()
                              .ToList()
                              .ForEach(entry => entry.State = System.Data.EntityState.Unchanged);
        }

        public IEnumerable<TEntity> ExecuteQuery<TEntity>(string sqlQuery, params object[] parameters)
        {
            return base.Database.SqlQuery<TEntity>(sqlQuery, parameters);
        }

        public int ExecuteCommand(string sqlCommand, params object[] parameters)
        {
            return base.Database.ExecuteSqlCommand(sqlCommand, parameters);
        }

        #endregion

        #region DbContext Overrides

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Remove unused conventions
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            //Add entity configurations in a structured way using 'TypeConfiguration’ classes
            modelBuilder.Configurations.Add(new ArtefatoTypeConfiguration());
            modelBuilder.Configurations.Add(new CheckListTypeConfiguration());
            modelBuilder.Configurations.Add(new ClienteTypeConfiguration());
            modelBuilder.Configurations.Add(new ProjetoTypeConfiguration());
            modelBuilder.Configurations.Add(new QuestaoAvaliadaTypeConfiguration());
            modelBuilder.Configurations.Add(new QuestaoTypeConfiguration());
            modelBuilder.Configurations.Add(new CategoriaQuestaoTypeConfiguration());
            modelBuilder.Configurations.Add(new AvaliacaoTypeConfiguration());
            modelBuilder.Configurations.Add(new UsuarioTypeConfiguration());


        }
        #endregion
    }
}
