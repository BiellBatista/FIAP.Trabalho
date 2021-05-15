using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace MasterChef.Infrastructure.Data.EntityConfigurations.API
{
    public class ReceitaConfiguration : IEntityTypeConfiguration<Receita>
    {
        [Obsolete]
        public void Configure(EntityTypeBuilder<Receita> builder)
        {
            builder
                .ToTable("Receitas");

            builder
              .Property(r => r.Id)
              .ValueGeneratedOnAdd()
              .HasColumnType("int")
              .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            builder
                .Property(r => r.Titulo)
                .HasColumnType("nvarchar(100)")
                .HasMaxLength(100);

            builder
                .Property(r => r.Descricao)
                .HasColumnType("nvarchar(500)")
                .HasMaxLength(500);

            builder
                .Property(r => r.Ingredientes)
                .HasColumnType("nvarchar(500)")
                .HasMaxLength(500);

            builder
                .Property(r => r.ModoPreparo)
                .HasColumnType("nvarchar(500)")
                .HasMaxLength(500);

            builder
                .Property(r => r.Foto)
                .HasColumnType("nvarchar(500)")
                .HasMaxLength(500);

            builder
                .Property(r => r.Tags)
                .HasColumnType("nvarchar(50)")
                .HasMaxLength(50);

            builder
                .HasOne(r => r.Categoria)
                .WithMany(c => c.Receitas);
        }
    }

    public class Receita
    {
        [JsonProperty]
        public virtual int Id { get; set; }

        [JsonProperty]
        [Required]
        public virtual string Titulo { get; set; }

        [JsonProperty]
        [Required]
        public virtual string Descricao { get; set; }

        [JsonProperty]
        [Required]
        public virtual string Ingredientes { get; set; }

        [JsonProperty]
        [Required]
        public virtual string ModoPreparo { get; set; }

        [JsonProperty]
        public virtual string Foto { get; set; }

        [JsonProperty]
        public virtual string Tags { get; set; }

        [JsonProperty]
        [Required]
        public virtual Categoria Categoria { get; set; }

        public virtual int CategoriaId { get; set; }
    }
}