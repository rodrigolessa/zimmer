using BSI.Zimmer.Dominio.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSI.Zimmer.Infraestrutura.Persistencia.UnitOfWork.Mapping
{
    public class AvaliacaoTypeConfiguration : EntityTypeConfiguration<Avaliacao>
    {
        public AvaliacaoTypeConfiguration()
        {
            this.HasKey(c => c.Id);

            this.HasRequired(c => c.Usuario);

            this.HasRequired(c => c.CheckList);

            this.HasRequired(c => c.Projeto);

            this.ToTable("avaliacao");
        }
    }
}
