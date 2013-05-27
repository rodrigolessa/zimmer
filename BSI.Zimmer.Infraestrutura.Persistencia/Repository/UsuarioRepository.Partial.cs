

using BSI.Zimmer.Dominio;
using BSI.Zimmer.Dominio.Entity;
using BSI.Zimmer.Infraestrutura.Persistencia.UnitOfWork;
using BSI.Zimmer.Dominio.Repository;
using System.Linq;
using System.Collections.Generic;

namespace BSI.Zimmer.Infraestrutura.Persistencia.Repository
{
    public partial class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public IEnumerable<Usuario> GetByLogin(string login)
        {
            return this.GetFiltered(s=>s.Login == login);
        }
    }
}
