

using BSI.Zimmer.Dominio;
using BSI.Zimmer.Dominio.Entity;
using BSI.Zimmer.Infraestrutura.Persistencia.UnitOfWork;
using BSI.Zimmer.Dominio.Repository;

namespace BSI.Zimmer.Infraestrutura.Persistencia.Repository
{
    public partial class AvaliacaoRepository :Repository<Avaliacao>, IAvaliacaoRepository
    {
        #region Constructor

        /// <summary>
        /// Cria uma Nova Instância
        /// </summary>
        /// <param name="unitOfWork">Associado ao Unit Of Work</param>
        public AvaliacaoRepository(IQueryableUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        #endregion
    }
}
