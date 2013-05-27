

using BSI.Zimmer.Dominio;
using BSI.Zimmer.Dominio.Entity;
using BSI.Zimmer.Infraestrutura.Persistencia.UnitOfWork;
using BSI.Zimmer.Dominio.Repository;

namespace BSI.Zimmer.Infraestrutura.Persistencia.Repository
{
    public partial class QuestaoAvaliadaRepository :Repository<QuestaoAvaliada>, IQuestaoAvaliadaRepository
    {
        #region Constructor

        /// <summary>
        /// Cria uma Nova Instância
        /// </summary>
        /// <param name="unitOfWork">Associado ao Unit Of Work</param>
        public QuestaoAvaliadaRepository(IQueryableUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        #endregion
    }
}
