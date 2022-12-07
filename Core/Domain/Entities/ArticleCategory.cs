
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kharaei.Domain;

public class ArticleCategory : BaseEntity<int>
    {
        [Required]
        [StringLength(50)]
        public string Title { get; set; }
        public int? ParentCategoryId { get; set; }

        [ForeignKey(nameof(ParentCategoryId))]
        public ArticleCategory ParentCategory { get; set; }
        public ICollection<ArticleCategory> ChildCategories { get; set; }
        public ICollection<Article> Articles { get; set; }
    }