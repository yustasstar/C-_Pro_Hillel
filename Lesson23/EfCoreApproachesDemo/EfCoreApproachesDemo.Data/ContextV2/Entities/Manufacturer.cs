using System.ComponentModel.DataAnnotations;

namespace EfCoreExamples.ContextV2.Entities
{
    public record Manufacturer : BaseEntity
    {
		[Required]
		[MinLength(2)]
		[MaxLength(20)]
		public string Name { get; set; } = string.Empty;

		[Required]
		[MinLength(2)]
		[MaxLength(100)]
		public string Description { get; set; } = string.Empty;

		[Required]
		[DataType(DataType.Date)]
		public DateTime FoundedDate { get; set; }

        public virtual IEnumerable<Product> Products { get; set; } = [];
    }
}
