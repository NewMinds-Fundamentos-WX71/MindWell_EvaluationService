using Microsoft.EntityFrameworkCore;
using MindWell_EvaluationService.Evaluation.Domain.Models;
using MindWell_EvaluationService.Shared.Extensions;

namespace MindWell_EvaluationService.Shared.Persistence.Contexts;

public class AppDbContext : DbContext
{
    public DbSet<Assessment> Assessments { get; set; }
    public DbSet<Diagnosis> Diagnosis { get; set; }
    public DbSet<AssessmentRecommendation> AssessmentRecommendations { get; set; }
    public DbSet<Recommendation> Recommendations { get; set; }
    public DbSet<Treatment> Treatments { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<Test> Tests { get; set; }
    
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
        
        builder.Entity<Diagnosis>().ToTable("Diagnoses");
        builder.Entity<Diagnosis>().HasKey(p => p.Id);
        builder.Entity<Diagnosis>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Diagnosis>().Property(p => p.Name).IsRequired();
        
        builder.Entity<AssessmentRecommendation>().ToTable("AssessmentsRecomendations");
        builder.Entity<AssessmentRecommendation>().HasKey(p => p.Id);
        builder.Entity<AssessmentRecommendation>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        
        builder.Entity<Recommendation>().ToTable("Recommendations");
        builder.Entity<Recommendation>().HasKey(p => p.Id);
        builder.Entity<Recommendation>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Recommendation>().Property(p => p.Frecuency).IsRequired();
        builder.Entity<Recommendation>().Property(p => p.Category).IsRequired();
        builder.Entity<Recommendation>().Property(p => p.Description).IsRequired();
        builder.Entity<Recommendation>().Property(p => p.Lifespan).IsRequired();
        
        builder.Entity<Treatment>().ToTable("Treatments");
        builder.Entity<Treatment>().HasKey(p => p.Id);
        builder.Entity<Treatment>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Treatment>().Property(p => p.Counter).IsRequired();
        
        builder.Entity<Question>().ToTable("Questions");
        builder.Entity<Question>().HasKey(p => p.Id);
        builder.Entity<Question>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Question>().Property(p => p.Text).IsRequired();

        builder.Entity<Test>().ToTable("Tests");
        builder.Entity<Test>().HasKey(p=> p.Id);
        builder.Entity<Test>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Test>().Property(p => p.Name).IsRequired();
        builder.Entity<Test>().Property(p => p.Objective).IsRequired();

        builder.Entity<Assessment>()
            .HasOne(p=>p.Diagnosis)
            .WithMany(p=>p.Assessments)
            .HasForeignKey(p=>p.Diagnosis_Id);
        
        builder.Entity<Assessment>()
            .HasMany(p=>p.AssessmentRecommendations)
            .WithOne(p=>p.Assessment)
            .HasForeignKey(p=>p.Assessment_Id);
        
        builder.Entity<Assessment>()
            .HasOne(p => p.Treatment)
            .WithOne(p => p.Assessment)
            .HasForeignKey<Treatment>(p => p.Assessment_Id);

        builder.Entity<Recommendation>()
            .HasMany(p => p.AssessmentRecomendations)
            .WithOne(p => p.Recommendation)
            .HasForeignKey(p => p.Recommendation_Id);
        
        builder.Entity<Recommendation>()
            .HasOne(p=>p.Diagnosis)
            .WithMany(p=>p.Recommendations)
            .HasForeignKey(p=>p.Diagnosis_Id);

        builder.Entity<Question>()
            .HasOne(p => p.Test)
            .WithMany(p => p.Questions)
            .HasForeignKey(p => p.Test_Id);
        
        // Add data to database
        builder.Entity<Diagnosis>()
            .HasData(
                new Diagnosis { Id = 1, Name = "Sin síntomas mínimos de depresión" },
                new Diagnosis { Id = 2, Name = "Depresión leve" },
                new Diagnosis { Id = 3, Name = "Depresión moderada" },
                new Diagnosis { Id = 4, Name = "Depresión moderadamente severa" },
                new Diagnosis { Id = 5, Name = "Depresión severa" },
                new Diagnosis { Id = 6, Name = "Mínima ansiedad" },
                new Diagnosis { Id = 7, Name = "Ansiedad leve" },
                new Diagnosis { Id = 8, Name = "Ansiedad moderada" },
                new Diagnosis { Id = 9, Name = "Ansiedad severa" },
                new Diagnosis { Id = 10, Name = "Sin diagnóstico" }
            );
        
        builder.Entity<Test>()
            .HasData(
                new Test { Id = 1, Name = "Cuestionario de Salud del Paciente (PHQ-9)", Objective = "Depresión" },
                new Test { Id = 2, Name = "Inventario de Ansiedad de Beck (BAI)", Objective = "Ansiedad" }
            );

        builder.Entity<Question>()
            .HasData(
                new Question { Id = 1, Text = "Poco interés o placer en hacer cosas.", Test_Id = 1 },
                new Question { Id = 2, Text = "Se ha sentido decaído(a), deprimido(a) o sin esperanzas.", Test_Id = 1 },
                new Question { Id = 3, Text = "Ha tenido dificultad para quedarse o permanecer dormido(a), o ha dormido demasiado.", Test_Id = 1 },
                new Question { Id = 4, Text = "Se ha sentido cansado(a) o con poca energía.", Test_Id = 1 },
                new Question { Id = 5, Text = "Sin apetito o ha comido en exceso.", Test_Id = 1 },
                new Question { Id = 6, Text = "Se ha sentido mal con usted mismo(a) – o que es un fracaso o que ha quedado mal con usted mismo(a) o con su familia.", Test_Id = 1 },
                new Question { Id = 7, Text = "Ha tenido dificultad para concentrarse en ciertas actividades, tales como leer el periódico o ver la televisión.", Test_Id = 1 },
                new Question { Id = 8, Text = "¿Se ha movido o hablado tan lento que otras personas podrían haberlo notado? o lo contrario – muy inquieto(a) o agitado(a) que ha estado moviéndose mucho más de lo normal.", Test_Id = 1 },
                new Question { Id = 9, Text = "Pensamientos de que estaría mejor muerto(a) o de lastimarse de alguna manera.", Test_Id = 1 },
                new Question { Id = 10, Text = "Torpe o entumecido.", Test_Id = 2 },
                new Question { Id = 11, Text = "Acalorado.", Test_Id = 2 },
                new Question { Id = 12, Text = "Con temblor en las piernas.", Test_Id = 2 },
                new Question { Id = 13, Text = "Incapaz de relajarse.", Test_Id = 2 },
                new Question { Id = 14, Text = "Con temor a que ocurra lo peor.", Test_Id = 2 },
                new Question { Id = 15, Text = "Mareado, o que se le va la cabeza.", Test_Id = 2 },
                new Question { Id = 16, Text = "Con latidos del corazón fuertes y acelerados.", Test_Id = 2 },
                new Question { Id = 17, Text = "Inestable.", Test_Id = 2 },
                new Question { Id = 18, Text = "Atemorizado o asustado.", Test_Id = 2 },
                new Question { Id = 19, Text = "Nervioso.", Test_Id = 2 },
                new Question { Id = 20, Text = "Con sensación de bloqueo.", Test_Id = 2 },
                new Question { Id = 21, Text = "Con temblores en las manos.", Test_Id = 2 },
                new Question { Id = 22, Text = "Inquieto, inseguro.", Test_Id = 2 },
                new Question { Id = 23, Text = "Con miedo a perder el control.", Test_Id = 2 },
                new Question { Id = 24, Text = "Con sensación de ahogo.", Test_Id = 2 },
                new Question { Id = 25, Text = "Con temor a morir.", Test_Id = 2 },
                new Question { Id = 26, Text = "Con miedo.", Test_Id = 2 },
                new Question { Id = 27, Text = "Con problemas digestivos.", Test_Id = 2 },
                new Question { Id = 28, Text = "Con desvanecimientos.", Test_Id = 2 },
                new Question { Id = 29, Text = "Con rubor facial.", Test_Id = 2 },
                new Question { Id = 30, Text = "Con sudores, fríos o calientes.", Test_Id = 2 }
            );

        builder.Entity<Recommendation>()
            .HasData(
                new Recommendation { Id = 1, Frecuency = "Diaria", Category = "DIN", Description = "Mantener un diario de gratitud para enfocarse en aspectos positivos de la vida", Lifespan = 15, Diagnosis_Id = 1},
                new Recommendation { Id = 2, Frecuency = "Tridiana", Category = "DOUT", Description = "Pasear al aire libre, como en un parque, para disfrutar de la naturaleza y el aire fresco.", Lifespan = 5, Diagnosis_Id = 1 },
                new Recommendation { Id = 3, Frecuency = "Diaria", Category = "DIN", Description = "Practicar meditación o técnicas de relajación durante 10-15 minutos al día.", Lifespan = 30, Diagnosis_Id = 2 },
                new Recommendation { Id = 4, Frecuency = "Diaria", Category = "DOUT", Description = "Caminar durante 20-30 minutos al día en un entorno tranquilo.", Lifespan = 30, Diagnosis_Id = 2 },
                new Recommendation { Id = 5, Frecuency = "Biana", Category = "DIN", Description = "Seguir una rutina de ejercicios de yoga para mejorar el estado de ánimo y la relajación.", Lifespan = 20, Diagnosis_Id = 3 },
                new Recommendation { Id = 6, Frecuency = "Biana", Category = "DOUT", Description = "Participar en una clase de ejercicio en grupo, como aeróbicos o zumba, para incrementar la actividad física y socializar.", Lifespan = 20, Diagnosis_Id = 3 },
                new Recommendation { Id = 7, Frecuency = "Diaria", Category = "DIN", Description = "Establecer una rutina diaria estructurada, incluyendo tiempo para hobbies que te gusten, como la lectura o la jardinería.", Lifespan = 60, Diagnosis_Id = 4 },
                new Recommendation { Id = 8, Frecuency = "Biana", Category = "DOUT", Description = "Realizar actividades físicas vigorosas, como correr o andar en bicicleta durante 30-45 minutos, tres veces por semana.", Lifespan = 30, Diagnosis_Id = 4 },
                new Recommendation { Id = 9, Frecuency = "Biana", Category = "DIN", Description = "Participar en terapia cognitivo-conductual en línea o aplicaciones de terapia guiada.", Lifespan = 60, Diagnosis_Id = 5 },
                new Recommendation { Id = 10, Frecuency = "Biana", Category = "DOUT", Description = "Unirse a un grupo de apoyo local o clases de actividades creativas, como arte o música, para interactuar con otros y obtener apoyo social.", Lifespan = 60, Diagnosis_Id = 5 },
                new Recommendation { Id = 11, Frecuency = "Diaria", Category = "AIN", Description = "Practicar técnicas de respiración profunda diariamente para mantener la calma y prevenir el estrés.", Lifespan = 15, Diagnosis_Id = 6 },
                new Recommendation { Id = 12, Frecuency = "Tridiana", Category = "AOUT", Description = "Realizar caminatas cortas al aire libre, aprovechando el tiempo para reflexionar y relajarse.", Lifespan = 5, Diagnosis_Id = 6 },
                new Recommendation { Id = 13, Frecuency = "Diaria", Category = "AIN", Description = "Realizar ejercicios de estiramiento o pilates para mejorar la flexibilidad y reducir la tensión muscular.", Lifespan = 15, Diagnosis_Id = 7 },
                new Recommendation { Id = 14, Frecuency = "Biana", Category = "AOUT", Description = "Participar en actividades recreativas ligeras, como jugar al frisbee o badminton en el parque.", Lifespan = 7, Diagnosis_Id = 7 },
                new Recommendation { Id = 15, Frecuency = "Diaria", Category = "AIN", Description = "Practicar mindfulness o meditación guiada durante 20 minutos al día.", Lifespan = 40, Diagnosis_Id = 8 },
                new Recommendation { Id = 16, Frecuency = "Biana", Category = "AOUT", Description = "Asistir a clases de yoga o tai chi en un estudio local para combinar ejercicio y relajación.", Lifespan = 20, Diagnosis_Id = 8 },
                new Recommendation { Id = 17, Frecuency = "Diaria", Category = "AIN", Description = "Seguir programas de terapia cognitivo-conductual online y establecer un espacio de relajación en casa.", Lifespan = 60, Diagnosis_Id = 9 },
                new Recommendation { Id = 18, Frecuency = "Diaria", Category = "AOUT", Description = "Asistir a terapia grupal en persona para recibir apoyo emocional adicional.", Lifespan = 60, Diagnosis_Id = 9 }
            );
        
        // Apply Snake Case Naming Convention
        builder.UseSnakeCaseNamingConvention();
    }
}