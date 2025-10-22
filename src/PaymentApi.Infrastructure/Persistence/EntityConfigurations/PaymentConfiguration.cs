using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaymentApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApi.Infrastructure.Persistence.EntityConfigurations
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> entity)
        {
            entity.ToTable("Pago");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Alumno_Id)
                .IsRequired();
            entity.Property(e => e.Entrenador_Id)
                .IsRequired();
            entity.Property(e => e.Monto)
                .IsRequired();
            entity.Property(e => e.Moneda)
                .HasMaxLength(15)
                .IsRequired();
            entity.Property(e => e.Metodo)
                .HasMaxLength(15)
                .IsRequired();
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .HasDefaultValue("Pendiente");
            entity.Property(e => e.Creado_En)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
        }
    }
}
