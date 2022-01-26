using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Efcore.SeedDatas
{
    public class CategorySeed : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category 
                {
                    Id=1, 
                    Name="Bilgisayar"
                },
                new Category
                {
                    Id = 2,
                    Name = "Telefon"
                },
                new Category
                {
                    Id = 3,
                    Name = "Beyaaz Eşya"
                }
                );
        }
    }
}
