using BSI.Zimmer.Dominio.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSI.Zimmer.Infraestrutura.Persistencia.UnitOfWork.Mapping
{
    public class QuestaoAvaliadaTypeConfiguration : EntityTypeConfiguration<QuestaoAvaliada>
    {
        public QuestaoAvaliadaTypeConfiguration()
        {            
            this.HasKey(c => c.Id);

            this.Property(s => s.Conformidade)
                .IsRequired();

            this.HasRequired(s => s.QuestaoPertencente);

            this.ToTable("questaoavaliada"); 
            
        }


    }
}
