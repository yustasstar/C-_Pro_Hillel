using System.ComponentModel.DataAnnotations;

namespace EfCoreExamples.ContextV2.Entities
{
    public record Order : BaseEntity
    {
		[Required]
		[DataType(DataType.Date)]
		public DateTime CreatedAt { get; set; }

		[Required]
		public int ProductId { get; set; }

		[Required]
		public int CustomerId { get; set; }

        public virtual Product? Product { get; set; }

        public virtual Customer? Customer { get; set; }
    }
}
