using System.ComponentModel.DataAnnotations;

namespace EfCoreExamples.ContextV2.Entities
{
    public record Category : BaseEntity
    {
        [Required]
        [MinLength(2)]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

		[Required]
		[MinLength(2)]
		[MaxLength(250)]
		public string Description { get; set; } = string.Empty;

        public virtual IEnumerable<Product> Products { get; set; } = [];
    }
}
