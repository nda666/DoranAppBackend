using System;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;
using DoranOfficeBackend.Entities.Interfaces;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DoranOfficeBackend.Entities;

public partial class MyDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public DbSet<KeylessCount> KeylessCount { get; set; }
    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Sales> Sales { get; set; }

    public virtual DbSet<SalesTeam> SalesTeams { get; set; }

    public virtual DbSet<SalesChannel> SalesChannels { get; set; }

    public virtual DbSet<HkategoriBarang> HkategoriBarang { get; set; }

    public virtual DbSet<DkategoriBarang> DkategoriBarang { get; set; }

    public virtual DbSet<MasterBarang> MasterBarang { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseMySQL(System.Configuration.ConfigurationManager.AppSettings.Get("ConnectionStrings.DefaultConnection"));
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Sales>(entity =>
        {
            entity.HasOne(p => p.SalesTeam)
                .WithMany(p => p.Sales)
                .HasForeignKey(p => p.SalesTeamId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("sales_sales_team_id_foreign");
        });

        modelBuilder.Entity<SalesTeam>(entity =>
        {
            entity.HasOne(p => p.SalesChannel)
                .WithMany(p => p.SalesTeams)
                .HasForeignKey(p => p.SalesChannelId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("sales_sales_channel_id_foreign");
        });

        modelBuilder.Entity<Role>(entity =>
    {
        entity.HasKey(e => e.Id).HasName("PRIMARY");

        entity.ToTable("roles");

        entity.HasIndex(e => e.Name, "roles_name_unique").IsUnique();

        entity.Property(e => e.Id)
            .HasColumnName("id");

        entity.Property(e => e.Active)
            .HasDefaultValueSql("'1'")
            .HasColumnType("tinyint(1)")
            .HasColumnName("active")
            .ValueGeneratedNever();

        entity.Property(e => e.CreatedAt)
            .HasDefaultValueSql("'NULL'")
            .HasColumnType("timestamp")
            .HasColumnName("created_at");
        entity.Property(e => e.DeletedAt)
            .HasDefaultValueSql("'NULL'")
            .HasColumnType("timestamp")
            .HasColumnName("deleted_at");
        entity.Property(e => e.Name).HasColumnName("name");
        entity.Property(e => e.UpdatedAt)
            .HasDefaultValueSql("'NULL'")
            .HasColumnType("timestamp")
            .HasColumnName("updated_at");
    });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("users");

            entity.HasIndex(e => e.ApiToken, "users_api_token_unique").IsUnique();

            entity.HasIndex(e => e.RoleId, "users_role_id_foreign");

            entity.HasIndex(e => e.Username, "users_username_unique").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnName("id");

            entity.Property(e => e.Active)
                .HasDefaultValueSql("'1'")
                .HasColumnType("tinyint(1)")
                .HasColumnName("active")
                .ValueGeneratedNever();
            entity.Property(e => e.ApiToken)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("api_token");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("timestamp")
                .HasColumnName("deleted_at");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.PasswordText)
                .HasMaxLength(255)
                .HasColumnName("passwordText");
            entity.Property(e => e.RememberToken)
                .HasMaxLength(100)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("remember_token");
            entity.Property(e => e.RoleId)
                .HasColumnName("role_id");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.Username).HasColumnName("username");

            entity.HasOne(d => d.Role)
                .WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("users_role_id_foreign");

            entity.HasOne(d => d.Sales)
               .WithOne(p => p.User)
               .HasForeignKey<User>(d => d.SalesId)
               .OnDelete(DeleteBehavior.Restrict)
               .HasConstraintName("users_sales_id_foreign");
        });

        modelBuilder.Entity<MasterBarang>(entity =>
        {
            entity.HasOne(d => d.DkategoriBarang)
            .WithMany(x => x.MasterBarangs)
            .HasForeignKey(x => x.dkategoribarangId)
            .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<DkategoriBarang>(entity =>
        {
            entity.HasOne(d => d.HkategoriBarang)
            .WithMany(x => x.DkategoriBarang)
            .HasForeignKey(x => x.hkategoribarangId)
            .OnDelete(DeleteBehavior.Restrict);
            entity.Property(x => x.id).HasColumnOrder(0);
        });

        modelBuilder.Entity<HkategoriBarang>(entity =>
        {
            entity.Property(x => x.id).HasColumnOrder(0);
        });

        modelBuilder
       .Entity<KeylessCount>(
           eb =>
           {
               eb.HasNoKey();
               eb.ToView("View_Count");
           });

        //var RoleId = Guid.NewGuid();
        //var UserId = Guid.NewGuid();
        //modelBuilder.Entity<Role>().HasData(new Role { Id = RoleId, Name = "superadmin", Active = true });
        //modelBuilder.Entity<User>().HasData(new User
        //{
        //    Id = UserId,
        //    Username = "superadmin",
        //    Password = BCrypt.Net.BCrypt.HashPassword("superadmin"),
        //    PasswordText = "superadmin",
        //    RoleId = RoleId
        //});


        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    public override int SaveChanges()
    {
        ApplyCreatedAtUpdatedAt();
        ApplySoftDelete();
        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        ApplyCreatedAtUpdatedAt();
        ApplySoftDelete();
        return base.SaveChangesAsync(cancellationToken);
    }

    public override EntityEntry<TEntity> Remove<TEntity>(TEntity entity)
    {
        if (entity is ISoftDelete softDeletableEntity)
        {
            softDeletableEntity.DeletedAt = DateTime.Now;
            return Update(softDeletableEntity as TEntity);
        }

        return base.Remove(entity);
    }

    private void ApplySoftDelete()
    {
        var currentTime = DateTime.Now;
        var deletedEntities = ChangeTracker.Entries()
            .Where(e => e.Entity is ISoftDelete && e.State == EntityState.Deleted);

        foreach (var entityEntry in deletedEntities)
        {
            entityEntry.State = EntityState.Modified;
            entityEntry.CurrentValues["DeletedAt"] = currentTime;
        }
    }

    private void ApplyCreatedAtUpdatedAt()
    {
        var currentTime = DateTime.Now;
        var modifiedEntities = ChangeTracker.Entries()
            .Where(e => {
                Console.WriteLine("123123 " + (e.Entity is ITimestamps).ToString());
                return e.Entity is ITimestamps && (e.State == EntityState.Added || e.State == EntityState.Modified ); 
            });

      
        foreach (var entityEntry in modifiedEntities)
        {
           
            if (entityEntry.State == EntityState.Added)
            {
                entityEntry.CurrentValues["CreatedAt"] = currentTime;
            }

            if (entityEntry.State == EntityState.Modified)
            {
                entityEntry.CurrentValues["UpdatedAt"] = currentTime;
            }

                
        }
    }

    public void SoftDelete<TEntity>(TEntity entity) where TEntity : class, ISoftDelete
    {
        entity.DeletedAt = DateTime.Now;
        Update(entity);
    }

    public Task RestoreSoftDeleteAsync<TEntity>(TEntity entity) where TEntity : class, ISoftDelete
    {
        entity.DeletedAt = null;
        Update(entity);
        return SaveChangesAsync();
    }


}
