using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace Server.Data;

public class AcademicProjectDbContext : IdentityDbContext<ApplicationUser>
{
    public AcademicProjectDbContext(DbContextOptions<AcademicProjectDbContext> options) : base(options) { }
    
    public DbSet<ProjectGroup> ProjectGroups { get; set; }
    public DbSet<ProjectReport> ProjectReports { get; set; }
    public DbSet<ProjectContributor> ProjectContributors { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ApplicationUser>()
            .HasMany(u => u.SubmittedReports)
            .WithOne(r => r.Submitter)
            .HasForeignKey(r => r.SubmitterId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ApplicationUser>()
            .HasMany(u => u.ApprovedReports)
            .WithOne(r => r.Approver)
            .HasForeignKey(r => r.ApproverId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ApplicationUser>()
            .HasMany(u => u.Contributions)
            .WithOne(c => c.User)
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ProjectGroup>()
            .HasMany(g => g.Reports)
            .WithOne(r => r.Group)
            .HasForeignKey(r => r.GroupId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ProjectGroup>()
            .HasMany(g => g.Members)
            .WithOne(c => c.ProjectGroup)
            .HasForeignKey(c => c.ProjectGroupId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ProjectReport>()
            .HasMany(r => r.Contributors)
            .WithOne(c => c.ProjectReport)
            .HasForeignKey(c => c.ProjectReportId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}