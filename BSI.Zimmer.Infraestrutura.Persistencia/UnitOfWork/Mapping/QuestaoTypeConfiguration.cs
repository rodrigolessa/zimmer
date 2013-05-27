using BSI.Zimmer.Dominio.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSI.Zimmer.Infraestrutura.Persistencia.UnitOfWork.Mapping
{
    public class QuestaoTypeConfiguration : EntityTypeConfiguration<Questao>
    {
        public QuestaoTypeConfiguration()
        {            
            this.HasKey(c => c.Id);

            this.HasMany(o => o.Avaliacao)
                .WithRequired();

            this.Property(c => c.Nome)
                .IsRequired();

            this.ToTable("questao"); 
            
        }


    }
}
