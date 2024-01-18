using Microsoft.EntityFrameworkCore;
using RubBotApi.Models;

namespace RubBotApi.Data;

public class RubBotContext: DbContext
{
    public RubBotContext(DbContextOptions<RubBotContext> options) : base(options) {}
    
    public DbSet<Area> Areas { get; set; }
    public DbSet<Labels> Labels { get; set; }
    public DbSet<Note> Notes { get; set; }
    public DbSet<NoteBooks> NoteBooks { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Resource> Resources { get; set; }
    public DbSet<Status> Status { get; set; }
    public DbSet<Tasks> Tasks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Labels>().HasData(
            new Labels { Id = Guid.NewGuid().ToString(), Name = "Personal" },
            new Labels { Id = Guid.NewGuid().ToString(), Name =  "Business"},
            new Labels { Id = Guid.NewGuid().ToString(), Name =  "School"},
            new Labels { Id = Guid.NewGuid().ToString(), Name =  "Productivity"},
            new Labels { Id = Guid.NewGuid().ToString(), Name =  "Fitness"},
            new Labels { Id = Guid.NewGuid().ToString(), Name =  "Investment"});

        modelBuilder.Entity<Status>().HasData(
            new Status { Id = Guid.NewGuid().ToString(), Name = "Inbox" },
            new Status { Id = Guid.NewGuid().ToString(), Name = "Planned" },
            new Status { Id = Guid.NewGuid().ToString(), Name = "In Progress" },
            new Status { Id = Guid.NewGuid().ToString(), Name = "Done" });

        modelBuilder.Entity<Area>().HasData(
            new Area { Id = Guid.NewGuid().ToString(), Name = "Personal", AreaCover = "user", IsAchieved = false},
            new Area { Id = Guid.NewGuid().ToString(), Name = "Health & Fitness", AreaCover = "dumbbell", IsAchieved = false},
            new Area { Id = Guid.NewGuid().ToString(), Name = "Work", AreaCover = "briefcase", IsAchieved = false},
            new Area { Id = Guid.NewGuid().ToString(), Name = "Side Hustle", AreaCover = "money-bill-trend-up", IsAchieved = false},
            new Area { Id = Guid.NewGuid().ToString(), Name = "Travel", AreaCover = "route", IsAchieved = false},
            new Area { Id = Guid.NewGuid().ToString(), Name = "Learning", AreaCover = "leanpub", IsAchieved = false}
            );

        modelBuilder.Entity<Area>().HasOne(ar => ar.Type)
            .WithMany(type => type.Areas)
            .HasForeignKey(ar => ar.LabelId);
        
        modelBuilder.Entity<Note>().HasOne(note => note.Labels)
            .WithMany(labels => labels.Notes)
            .HasForeignKey(ar => ar.LabelId);
        
        modelBuilder.Entity<Note>().HasOne(ar => ar.Status)
            .WithMany(re => re.Notes)
            .HasForeignKey(ar => ar.StatusId);
        
        modelBuilder.Entity<Project>().HasOne(ar => ar.Status)
            .WithMany(re => re.Projects)
            .HasForeignKey(ar => ar.StatusId);
        
        modelBuilder.Entity<Resource>().HasOne(note => note.Labels)
            .WithMany(labels => labels.Resources)
            .HasForeignKey(ar => ar.LabelId);
        
        modelBuilder.Entity<Resource>().HasOne(ar => ar.Status)
            .WithMany(re => re.Resources)
            .HasForeignKey(ar => ar.StatusId);
        
        
       
    }
}