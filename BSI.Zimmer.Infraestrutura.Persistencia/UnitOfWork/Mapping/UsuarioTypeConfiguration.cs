using BSI.Zimmer.Dominio.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSI.Zimmer.Infraestrutura.Persistencia.UnitOfWork.Mapping
{
    public class UsuarioTypeConfiguration : EntityTypeConfiguration<Usuario>
    {
        public UsuarioTypeConfiguration()
        {                  
            this.HasKey(c => c.Id);
            
            this.Property(s => s.Nome)
                .HasMaxLength(250)
                .IsRequired();

            this.ToTable("usuario");
            
            
        }


    }
}
