using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace Server.Data;

public class AcademicProjectDbContext : IdentityDbContext<ApplicationUser>
{
    public AcademicProjectDbContext(DbContextOptions<AcademicProjectDbContext> options) : base(options)
    {
        
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure ApplicationUser to ProjectReport relationship
        modelBuilder.Entity<ApplicationUser>()
            .HasMany<ProjectReport>(u => u.SubmittedReports)
            .WithOne(r => r.Submitter)
            .HasForeignKey(r => r.SubmitterId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ApplicationUser>()
            .HasMany<ProjectReport>(u => u.ApprovedReports)
            .WithOne(r => r.Approver)
            .HasForeignKey(r => r.ApproverId)
            .OnDelete(DeleteBehavior.Restrict);

        // Configure ProjectGroup to ProjectReport relationship
        modelBuilder.Entity<ProjectGroup>()
            .HasMany<ProjectReport>(g => g.Reports)
            .WithOne(r => r.Group)
            .HasForeignKey(r => r.Id) // Renamed foreign key property
            .OnDelete(DeleteBehavior.Restrict);

        // Configure ProjectGroup to ProjectContributor relationship
        modelBuilder.Entity<ProjectGroup>()
            .HasMany<ProjectContributor>(g => g.Members)
            .WithOne(c => c.ProjectGroup)
            .HasForeignKey(c => c.ProjectGroupId)
            .OnDelete(DeleteBehavior.Restrict);

        // Configure ProjectReport to ProjectContributor relationship
        modelBuilder.Entity<ProjectReport>()
            .HasMany<ProjectContributor>(r => r.Contributors)
            .WithOne(c => c.ProjectReport)
            .HasForeignKey(c => c.ProjectReportId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}