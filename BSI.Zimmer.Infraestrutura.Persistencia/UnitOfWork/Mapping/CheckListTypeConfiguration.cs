using BSI.Zimmer.Dominio.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSI.Zimmer.Infraestrutura.Persistencia.UnitOfWork.Mapping
{
    public class CheckListTypeConfiguration : EntityTypeConfiguration<CheckList>
    {
        public CheckListTypeConfiguration()
        {

            this.HasKey(c => c.Id);

            this.Property(s => s.Nome)
                .HasMaxLength(100)
                .IsRequired();

            this.Property(s => s.Descricao)
                .HasMaxLength(400);

            this.HasRequired(c => c.Artefato);

            this.HasMany(o => o.Questao)
                .WithRequired();

            this.ToTable("checklist");

        }


    }
}
