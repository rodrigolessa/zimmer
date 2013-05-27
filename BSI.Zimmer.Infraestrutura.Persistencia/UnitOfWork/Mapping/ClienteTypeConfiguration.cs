using BSI.Zimmer.Dominio.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSI.Zimmer.Infraestrutura.Persistencia.UnitOfWork.Mapping
{
    public class ClienteTypeConfiguration : EntityTypeConfiguration<Cliente>
    {
        public ClienteTypeConfiguration()
        {
            this.HasKey(c => c.Id);
               
            this.Property(s => s.Nome)
                .HasMaxLength(100)
                .IsRequired();


            this.HasMany(o => o.Projetos)
             .WithRequired()
             .WillCascadeOnDelete(false);

            this.ToTable("cliente");
            
        }


    }
}
