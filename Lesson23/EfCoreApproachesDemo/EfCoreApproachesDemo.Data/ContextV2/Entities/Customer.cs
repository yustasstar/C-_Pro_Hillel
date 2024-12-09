using System.ComponentModel.DataAnnotations;

namespace EfCoreExamples.ContextV2.Entities
{
    public record Customer : BaseEntity
    {
		[Required]
		[MinLength(2)]
		[MaxLength(20)]
		public string FirstName { get; set; } = string.Empty;

		[Required]
		[MinLength(2)]
		[MaxLength(20)]
		public string LastName { get; set; } = string.Empty;

		[Required]
		[DataType(DataType.DateTime)]
		public DateTime BirthDate { get; set; }

        public virtual IEnumerable<Order> Orders { get; set; } = [];
    }
}
