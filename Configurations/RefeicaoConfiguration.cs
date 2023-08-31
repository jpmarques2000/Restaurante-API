using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestauranteAPI.Entity;

namespace RestauranteAPI.Configurations
{
    public class RefeicaoConfiguration : IEntityTypeConfiguration<Refeicao>
    {
        public void Configure(EntityTypeBuilder<Refeicao> builder)
        {
            builder.ToTable("Refeicao");
            builder.HasKey(r => r.Id);
            builder.Property(r => r.Id)
            .HasColumnType("INT").UseIdentityColumn();
            builder.Property(r => r.Nome).HasColumnType("VARCHAR(100)");
            builder.Property(r => r.Descricao)
                .HasColumnType("VARCHAR(200)")
                .IsRequired();
            builder.Property(r => r.Preco)
                .HasColumnType("decimal")
                .IsRequired();
            builder.HasMany(r => r.Pedidos)
                .WithOne(p => p.Refeicao)
                .HasForeignKey(p => p.RefeicaoId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
