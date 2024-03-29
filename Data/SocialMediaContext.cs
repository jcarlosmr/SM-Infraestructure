﻿using Microsoft.EntityFrameworkCore;
using SocialMedia.Core.Entities;
using SocialMedia.Infraestructure.Data.Configurations;

#nullable disable

namespace SocialMedia.Infraestructure.Data {
  public partial class SocialMediaContext : DbContext {
    public SocialMediaContext() {
    }

    public SocialMediaContext(DbContextOptions<SocialMediaContext> options)
        : base(options) {
    }

    public virtual DbSet<Comment> Comments { get; set; }
    public virtual DbSet<Post> Posts { get; set; }
    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
      modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

      modelBuilder.ApplyConfiguration(new CommentConfiguration());
      modelBuilder.ApplyConfiguration(new PostConfiguration());
      modelBuilder.ApplyConfiguration(new UserConfiguration());
    }
  }
}
