﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ConsultaMedica.Models;

namespace ConsultaMedica.Data.Configurations
{
    public class EspecialidadeConfiguration : IEntityTypeConfiguration<Especialidade>
    {
        public void Configure(EntityTypeBuilder<Especialidade> builder)
        {
            builder.ToTable("Especialidades");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .IsRequired(true)
                .HasColumnType("VARCHAR(60)");

            builder.Property(x => x.Descricao)
                .IsRequired(false)
                .HasColumnType("VARCHAR(150)");

            builder.HasMany(m => m.Medicos)
                .WithOne(e => e.Especialidade)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
