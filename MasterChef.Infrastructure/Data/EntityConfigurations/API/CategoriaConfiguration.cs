using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace MasterChef.Infrastructure.Data.EntityConfigurations.API
{
    public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
    {
        [Obsolete]
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder
                .ToTable("Categorias");

            builder
               .Property(c => c.Id)
               .ValueGeneratedOnAdd()
               .HasColumnType("int")
               .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            builder
                .Property(c => c.Titulo)
                .HasColumnType("nvarchar(100)")
                .HasMaxLength(100);

            builder
                .Property(c => c.Descricao)
                .HasColumnType("nvarchar(500)")
                .HasMaxLength(500);
        }
    }

    public class Categoria
    {
        [JsonProperty]
        public virtual int Id { get; set; }
        [JsonProperty]
        public virtual string Titulo { get; set; }
        [JsonProperty]
        public virtual string Descricao { get; set; }

        [JsonProperty]
        public virtual List<Receita> Receitas { get; set; }
    }
}