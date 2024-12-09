using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EfCoreExamples.ContextV2.Entities
{
    public record Product : BaseEntity
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
		[Column(TypeName = "decimal(18, 2)")]
		public decimal Price { get; set; }

		[Required]
		public int ManufacturerId { get; set; }

		public virtual Manufacturer? Manufacturer { get; set; }

        public virtual IEnumerable<Category> Categories { get; set; } = [];
    }
}
