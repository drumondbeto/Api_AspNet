using Web_API_ASP.NET_Core.Model;
using Microsoft.EntityFrameworkCore;

namespace Web_API_ASP.NET_Core.Data.Configurations
{
    public class FornecedorConfiguration : IEntityTypeConfiguration<Fornecedor>
    {   
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Fornecedor> builder)
        {
            builder.ToTable("Fornecedor");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Nome).HasColumnType("VARCHAR(80)").IsRequired();
            builder.Property(p => p.Documento).HasColumnType("VARCHAR(14)").IsRequired();
            builder.Property(p => p.Ativo).HasColumnType("BOOL").IsRequired();
        }
    }
}
