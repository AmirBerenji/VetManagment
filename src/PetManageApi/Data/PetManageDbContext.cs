using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PetManageApi.Entities;

namespace PetManageApi.Data;

public class PetManageDbContext : IdentityDbContext<AppUser>
{
    public PetManageDbContext(DbContextOptions<PetManageDbContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<PetKind> PetKinds { get; set; }
    public DbSet<Pet> Pets { get; set; }
    public DbSet<UserInformation> UsersInfo { get; set; }
    public DbSet<Clinic> Clinics { get; set; }
    public DbSet<Branch> Branches { get; set; }
    public DbSet<Personal> Personals { get; set; }
    public DbSet<PersonalKind> PersonalKinds { get; set; }
    public DbSet<PersonalBranch> PersonalBranches { get; set; }

}
