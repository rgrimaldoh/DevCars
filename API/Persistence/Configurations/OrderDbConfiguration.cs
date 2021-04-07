using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Persistence.Configurations
{
    public class OrderDbConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Order> builder)
        {
            //Define properties to Order Entity
            builder
            .HasKey(o => o.Id);
            builder
            .ToTable("TB_ORDER");
            //A order has many ExtraItems
            builder
            .HasMany(o => o.ExtraItems)
            .WithOne()
            .HasForeignKey(e => e.IdOrder)
            .OnDelete(DeleteBehavior.Restrict);
            //A order has only a car 
            //A car can exist witout a order but a order can't exist without a car
            //>When you have a case when the relation is one to one yo have to put <Order> in the foreignKey to point that the order is the principal
            builder
            .HasOne(o => o.Car)
            .WithOne()
            .HasForeignKey<Order>(c => c.IdCar)
            .OnDelete(DeleteBehavior.Restrict);


        }
    }
}