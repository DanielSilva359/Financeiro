using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Maps
{
    public class BoletoMap : BaseMap<Boleto>
    {
        public BoletoMap() : base("tb_boleto")
        { }

        public override void Configure(EntityTypeBuilder<Boleto> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.CpfCnpfBeneficiario).HasColumnType("varchar(11)").HasColumnName("cpfcnpj_beneficiario").IsRequired();
            builder.Property(x => x.NomeBeneficiario).HasColumnType("varchar(100)").HasColumnName("nome_beneficiario").IsRequired();
            builder.Property(x => x.CpfCnpjPagador).HasColumnType("varchar(11)").HasColumnName("cpfcnpj_pagador").IsRequired();
            builder.Property(x => x.NomePagador).HasColumnType("varchar(100)").HasColumnName("nome_pagador").IsRequired();
            builder.Property(x => x.Valor).HasPrecision(7, 2).HasColumnName("valor");
            builder.Property(x => x.Observacao).HasColumnType("varchar(100)").HasColumnName("observacao");
            builder.Property(x => x.BancoId).HasColumnType("integer").HasColumnName("banco_id");
        }
    }
}
