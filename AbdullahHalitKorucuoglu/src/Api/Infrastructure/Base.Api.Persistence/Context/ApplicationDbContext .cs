using Base.Api.Application.Services;
using Base.Api.Domain.Common;
using Base.Api.Domain.Entities;
using Base.Api.Persistence.EntityConfigurations.Seed;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Base.Api.Persistence.Context;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
{
    private readonly IIdentityService _identityService;

    public DbSet<Category> Categories { get; set; }
    public DbSet<Article> Articles { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IIdentityService identityService) : base(options)
    {
        ChangeTracker.LazyLoadingEnabled = false;
        ChangeTracker.AutoDetectChangesEnabled = false;
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        _identityService = identityService;
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        Seed.AddData(builder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.EnableSensitiveDataLogging();
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var changedEntity in ChangeTracker.Entries<BaseEntity>())
        {
            if (changedEntity.State == EntityState.Added)
            {
                changedEntity.Entity.CreatedDate = DateTime.UtcNow;

                if (changedEntity.Entity is IAuthRequired authRequiredentity)
                {
                    authRequiredentity.ApplicationUserId = _identityService.GetUserDecodeId;
                }
            }

            if (changedEntity.State == EntityState.Modified)
            {
                if (changedEntity.Entity is IUpdateable entity)
                {
                    Entry(changedEntity.Entity).Property(x => x.CreatedDate).IsModified = false;

                    entity.UpdatedDate = DateTime.UtcNow;
                }

                if (changedEntity.Entity is IAuthRequired authRequiredentity)
                {
                    Entry(authRequiredentity).Property(x => x.ApplicationUserId).IsModified = false;
                }
            }
        }

        return await base.SaveChangesAsync(cancellationToken);
    }
}