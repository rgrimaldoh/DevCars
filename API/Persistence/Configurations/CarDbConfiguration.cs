using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Persistence.Configurations
{
    public class CarDbConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Car> builder)
        {

            builder
            .HasKey(c => c.Id);
            builder
            .ToTable("TB_CAR");
            builder
            .Property(c => c.Brand)
            .HasMaxLength(100);
            builder
            .Property(c => c.ProductionDate)
            .HasDefaultValueSql("GETDATE()");
        }
    }
}