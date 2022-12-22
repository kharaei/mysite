using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kharaei.Domain;

public class Article: BaseEntity<int>
{    
    public string Title { get; set; } 
    public string Image { get; set; }
    public string Text { get; set; }
    public string PublishDateTime { get; set; }    
    public bool Status { get; set; }
    public int CategoryId { get; set; }
    public int AuthorId { get; set; } 
    public ArticleCategory Category { get; set; }
    public User Author { get; set; }
}

public class PostConfiguration : IEntityTypeConfiguration<Article>
{
    public void Configure(EntityTypeBuilder<Article> builder)
    {
        builder.Property(p => p.Title).HasMaxLength(200); 
        builder.Property(p => p.PublishDateTime).IsRequired(); 
        builder.HasOne(p => p.Category).WithMany(c => c.Articles).HasForeignKey(p => p.CategoryId);
        builder.HasOne(p => p.Author).WithMany(c => c.Articles).HasForeignKey(p => p.AuthorId);
    }
}