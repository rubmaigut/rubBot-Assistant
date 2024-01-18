using Microsoft.EntityFrameworkCore;
using RubBotApi.Models;
using RubBotApi.Util;

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
            new Labels { Id = "2f81a686-7531-11e8-86e5-f0d5bf731f68", Name = "Personal" },
            new Labels { Id = "2f99a636-7111-11e8-86e5-f0d534f731f68" , Name =  "Work"},
            new Labels { Id = "2f81a686-7531-11e8-86e5-f0d534f731f68" , Name =  "Business"},
            new Labels { Id = "2f81a612-7531-11e8-86e5-f0d534f731f68" , Name =  "School"},
            new Labels { Id = "2f81a789-1234-11e8-86e5-f0d534f731f68" , Name =  "Productivity"},
            new Labels { Id = "2f81a112-5678-11e8-86e5-f0d534f731f68" , Name =  "Fitness"},
            new Labels { Id = "2f81a632-9012-11e8-86e5-f0d534f731f68" , Name =  "Investment"});

        modelBuilder.Entity<Status>().HasData(
            new Status { Id = "2f81a686-7531-11e8-86e5-f0d5bf731f68", Name = "Inbox" },
            new Status { Id = "2f81a123-1234-11e8-86e5-f0d5bf731f68", Name = "Planned" },
            new Status { Id = "2f81a456-5678-11e8-86e5-f0d5bf731f68", Name = "In Progress" },
            new Status { Id = "2f81a789-9012-11e8-86e5-f0d5bf731f68", Name = "Done" });

        modelBuilder.Entity<Area>().HasData(
            new Area { Id = ShortGuidGenerator.GenerateShortGuid(), Name = "Personal",  LabelId =  "2f81a686-7531-11e8-86e5-f0d5bf731f68", AreaCover = "user", IsAchieved = false},
            new Area { Id = ShortGuidGenerator.GenerateShortGuid(), Name = "Health & Fitness", LabelId = "2f81a112-5678-11e8-86e5-f0d534f731f68", AreaCover = "dumbbell", IsAchieved = false},
            new Area { Id = ShortGuidGenerator.GenerateShortGuid(), Name = "Work",LabelId = "2f99a636-7111-11e8-86e5-f0d534f731f68", AreaCover = "briefcase", IsAchieved = false},
            new Area { Id = ShortGuidGenerator.GenerateShortGuid(), Name = "Side Hustle",LabelId = "2f81a686-7531-11e8-86e5-f0d534f731f68", AreaCover = "money-bill-trend-up", IsAchieved = false},
            new Area { Id = ShortGuidGenerator.GenerateShortGuid(), Name = "Travel", LabelId = "2f81a686-7531-11e8-86e5-f0d5bf731f68" ,AreaCover = "route", IsAchieved = false},
            new Area { Id = ShortGuidGenerator.GenerateShortGuid(), Name = "Learning", LabelId = "2f81a612-7531-11e8-86e5-f0d534f731f68" ,AreaCover = "leanpub", IsAchieved = false}
            );

        modelBuilder.Entity<Area>().HasOne(ar => ar.Type)
            .WithMany(type => type.Areas)
            .HasForeignKey(ar => ar.LabelId).OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Note>().HasOne(note => note.Labels)
            .WithMany(labels => labels.Notes)
            .HasForeignKey(ar => ar.LabelId).OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<Note>().HasOne(ar => ar.Status)
            .WithMany(re => re.Notes)
            .HasForeignKey(ar => ar.StatusId).OnDelete(DeleteBehavior.Restrict);  
        
        modelBuilder.Entity<Note>().HasOne(t => t.Tasks)
            .WithMany(t => t.Notes)
            .HasForeignKey(ar => ar.TaskId).OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<Project>().HasOne(ar => ar.Status)
            .WithMany(re => re.Projects)
            .HasForeignKey(ar => ar.StatusId).OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<Resource>().HasOne(note => note.Labels)
            .WithMany(labels => labels.Resources)
            .HasForeignKey(ar => ar.LabelId).OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<Resource>().HasOne(ar => ar.Status)
            .WithMany(re => re.Resources)
            .HasForeignKey(ar => ar.StatusId).OnDelete(DeleteBehavior.Restrict);
        
        
       
    }
}