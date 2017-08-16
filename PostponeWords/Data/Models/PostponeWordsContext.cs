using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PostponeWords.Data.Models
{
  public partial class PostponeWordsContext : DbContext
  {
    public virtual DbSet<User> User { get; set; }

    public PostponeWordsContext(DbContextOptions<PostponeWordsContext> options)
    : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<User>(entity =>
      {
        entity.Property(e => e.Email)
                  .IsRequired()
                  .HasColumnType("nchar(50)");

        entity.Property(e => e.Hesh)
                  .IsRequired()
                  .HasColumnType("nchar(50)");

        entity.Property(e => e.Salt)
                  .IsRequired()
                  .HasColumnType("nchar(50)");
      });
    }
  }
}