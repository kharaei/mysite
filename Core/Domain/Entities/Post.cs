using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kharaei.Domain;

public class Post: BaseEntity<int>
{   
    public required string Title { get; set; } 
    public required string Image { get; set; }
    public required string Text { get; set; }
    public string PublishDate { get; set; }
    public string PublishTime { get; set; }
    public int CategoryId { get; set; }
    public int AuthorId { get; set; } 
    public Category Category { get; set; }
    public User Author { get; set; }
}

public class PostConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.Property(p => p.Title).HasMaxLength(200); 
        builder.Property(p => p.PublishDate).IsRequired();
        builder.Property(p => p.PublishTime).IsRequired();
        builder.HasOne(p => p.Category).WithMany(c => c.Posts).HasForeignKey(p => p.CategoryId);
        builder.HasOne(p => p.Author).WithMany(c => c.Posts).HasForeignKey(p => p.AuthorId);
    }
}