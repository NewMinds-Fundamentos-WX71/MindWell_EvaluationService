using Microsoft.EntityFrameworkCore;
using MindWell_EvaluationService.Evaluation.Domain.Models;
using MindWell_EvaluationService.Shared.Extensions;

namespace MindWell_EvaluationService.Shared.Persistence.Contexts;

public class AppDbContext : DbContext
{
    public DbSet<Assessment> Assessments { get; set; }
    public DbSet<AssessmentQuestion> AssessmentQuestions { get; set; }
    public DbSet<Diagnose> Diagnoses { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<Recommendation> Recommendations { get; set; }
    
    public AppDbContext(DbContextOptions options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.Entity<Assessment>().ToTable("Assessments");
        builder.Entity<Assessment>().HasKey(p=>p.Id);
        builder.Entity<Assessment>().Property(p=>p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Assessment>().Property(p=>p.Date).IsRequired();
        builder.Entity<Assessment>().Property(p=>p.User_Id).IsRequired();
        
        builder.Entity<AssessmentQuestion>().ToTable("AssessmentQuestions");
        builder.Entity<AssessmentQuestion>().HasKey(p => p.Id);
        builder.Entity<AssessmentQuestion>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        
        builder.Entity<Diagnose>().ToTable("Diagnoses");
        builder.Entity<Diagnose>().HasKey(p => p.Id);
        builder.Entity<Diagnose>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Diagnose>().Property(p => p.Result).IsRequired();
        
        builder.Entity<Question>().ToTable("Questions");
        builder.Entity<Question>().HasKey(p => p.Id);
        builder.Entity<Question>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Question>().Property(p => p.Text).IsRequired();
        
        builder.Entity<Recommendation>().ToTable("Recommendations");
        builder.Entity<Recommendation>().HasKey(p => p.Id);
        builder.Entity<Recommendation>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Recommendation>().Property(p => p.Frecuency).IsRequired();
        builder.Entity<Recommendation>().Property(p => p.Category).IsRequired();
        builder.Entity<Recommendation>().Property(p => p.Details).IsRequired();

        builder.Entity<Assessment>()
            .HasMany(p => p.AssessmentQuestions)
            .WithOne(p => p.Assessment)
            .HasForeignKey(p => p.Assessment_Id);

        builder.Entity<Diagnose>()
            .HasOne(p => p.Assessment)
            .WithOne(p => p.Diagnose)
            .HasForeignKey<Assessment>(p => p.Diagnose_Id);
        
        builder.Entity<AssessmentQuestion>()
            .HasOne(p => p.Question)
            .WithMany(p=> p.AssessmentQuestions)
            .HasForeignKey(p => p.Question_Id);
        
        builder.Entity<Recommendation>()
            .HasOne(p=> p.Diagnose)
            .WithMany(p=> p.Recommendations)
            .HasForeignKey(p=> p.Diagnose_Id);
        
        // Apply Snake Case Naming Convention
        builder.UseSnakeCaseNamingConvention();
    }
}