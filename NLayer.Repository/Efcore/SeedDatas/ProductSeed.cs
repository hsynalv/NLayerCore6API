using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.Entities;

namespace NLayer.Repository.Efcore.SeedDatas
{
    public class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(

                new Product { Id = 1, Name = "Lenovo", CategoryId = 1, Price=11000, Stock=100, CreatedDate = DateTime.Now,},
                new Product { Id = 2, Name = "Huawei", CategoryId = 1, Price = 8000, Stock = 90, CreatedDate = DateTime.Now,},
                new Product { Id = 3, Name = "Oppo", CategoryId = 2, Price = 4000, Stock = 120,CreatedDate = DateTime.Now,},
                new Product { Id = 4, Name = "Realme", CategoryId = 2, Price = 2750, Stock = 150, CreatedDate = DateTime.Now},
                new Product { Id = 5, Name = "Buzdolabı", CategoryId = 3, Price = 7000, Stock = 10, CreatedDate = DateTime.Now},
                new Product { Id = 6, Name = "Çamaşır Makinesi", CategoryId = 3, Price = 6500, Stock = 10, CreatedDate = DateTime.Now}
                );
        }
    }
}
