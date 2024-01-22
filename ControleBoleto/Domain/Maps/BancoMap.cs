using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Maps
{
    public class BancoMap : BaseMap<Banco>
    {
        public BancoMap() : base("tb_banco")
        { }

        public override void Configure(EntityTypeBuilder<Banco> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.CodigoBanco).HasColumnType("varchar(40)").HasColumnName("codigo_banco").IsRequired();
            builder.Property(x => x.NomeBanco).HasColumnType("varchar(100)").HasColumnName("nome_banco").IsRequired();
            builder.Property(x => x.PercentualJuros).HasPrecision(7, 2).HasColumnName("percentual_juros").IsRequired();
        }
    }
}
