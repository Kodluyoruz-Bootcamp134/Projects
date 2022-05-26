using Base.Api.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

namespace Base.Api.Persistence.EntityConfigurations.Seed;

public static class Seed
{
    public static void AddData(ModelBuilder builder)
    {
        var AdminRoleId = 1;
        var AdminUserId = 1;

        builder.Entity<ApplicationRole>().HasData(new ApplicationRole { Id = AdminRoleId, Name = "Admin", NormalizedName = "ADMIN" });

        var hasher = new PasswordHasher<ApplicationUser>();

        builder.Entity<ApplicationUser>().HasData(
            new ApplicationUser
            {
                Id = AdminUserId,
                Email = "admin@gmail.com",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "123123"),
                SecurityStamp = Guid.NewGuid().ToString()
            }
        );

        builder.Entity<ApplicationUserRole>().HasData(
            new ApplicationUserRole()
            {
                RoleId = AdminRoleId,
                UserId = AdminUserId
            }
        );

        var userRoleId = 2;
        var userId = 2;

        builder.Entity<ApplicationRole>().HasData(new ApplicationRole { Id = userRoleId, Name = "User", NormalizedName = "USER" });

        builder.Entity<ApplicationUser>().HasData(
            new ApplicationUser
            {
                Id = userId,
                Email = "user@gmail.com",
                UserName = "user",
                NormalizedUserName = "USER",
                NormalizedEmail = "USER@GMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "123123"),
                SecurityStamp = Guid.NewGuid().ToString()
            }
        );

        builder.Entity<ApplicationUserRole>().HasData(
            new ApplicationUserRole()
            {
                RoleId = userRoleId,
                UserId = userId
            }
        );

        builder.Entity<Category>().HasData(
            new Category()
            {
                Id = 1,
                ApplicationUserId = AdminUserId,
                Title = "Math",
                CreatedDate = DateTime.UtcNow
            },
            new Category()
            {
                Id = 2,
                ApplicationUserId = AdminUserId,
                Title = "Software",
                CreatedDate = DateTime.UtcNow
            },
            new Category()
            {
                Id = 3,
                ApplicationUserId = AdminUserId,
                Title = "Homework",
                CreatedDate = DateTime.UtcNow
            },
            new Category()
            {
                Id = 4,
                ApplicationUserId = userId,
                Title = "Geography",
                CreatedDate = DateTime.UtcNow
            },
            new Category()
            {
                Id = 5,
                ApplicationUserId = userId,
                Title = "Chemical",
                CreatedDate = DateTime.UtcNow
            },
            new Category()
            {
                Id = 6,
                ApplicationUserId = userId,
                Title = "Astronomy",
                CreatedDate = DateTime.UtcNow
            }
        );

        builder.Entity<Article>().HasData(
            new Article()
            {
                Id = 1,
                ApplicationUserId = userId,
                CategoryId = 5,
                IsPublic = true,
                Title = "What is a Chemical ?",
                Content = "A chemical is any substance that has a defined composition. In other words, a chemical is always made up of the same stuff Some chemicals occur in nature, such as water. Other chemicals are manufactured, such as chlorine (used for bleaching fabrics or in swimming pools). Chemicals are all around you: the food you eat, the clothes you wear. You, in fact, are made up of a wide variety of chemicals. A chemical reaction refers to a change in a chemical. More generally, a chemical reaction can be understood as the process by which one or more substances change to produce one or more different substances. Chemical changes are different from physical changes, which don't result in a change in substances. One example of a physical change is when water freezes into ice. While ice may have different physical properties, it is still just water. Another example is when you dissolve salt into a cup of water. While the salt may appear to disappear into the water, you still have water and salt no substance changed into a completely new substance.",
                CreatedDate = DateTime.UtcNow
            },

            new Article()
            {
                Id = 2,
                ApplicationUserId = AdminUserId,
                CategoryId = 2,
                IsPublic = true,
                Title = "What Is Pi, and How Did It Originate?",
                Content = "Otherwise said, if you cut several pieces of string equal in length to the diameter, you will need a little more than three of them to cover the circumference of the circle. Pi is most commonly used in certain computations regarding circles. Pi not only relates circumference and diameter. Amazingly, it also connects the diameter or radius of a circle with the area of that circle by the formula: the area is equal to pi times the radius squared. Additionally, pi shows up often unexpectedly in many mathematical situations. For example, the sum of the infinite series",
                CreatedDate = DateTime.UtcNow
            }

            );
    }
}