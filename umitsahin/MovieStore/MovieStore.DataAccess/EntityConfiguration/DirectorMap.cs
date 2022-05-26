using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.DataAccess.EntityConfiguration;

public class DirectorMap : IEntityTypeConfiguration<Director>
{
   
    public void Configure(EntityTypeBuilder<Director> builder)
    {
        builder.HasKey(x => x.Id);



        builder.HasData(

           new Director { Id = 1, DirectorName = "Timur Bekmambetov" },
           new Director { Id = 2, DirectorName = "Andy Serkis" },
           new Director { Id = 3, DirectorName = "Galder Gaztelu-Urrutia" }

            );
    }
}
