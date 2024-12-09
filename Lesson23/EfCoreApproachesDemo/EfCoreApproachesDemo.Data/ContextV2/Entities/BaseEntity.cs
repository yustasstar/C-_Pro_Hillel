using System.ComponentModel.DataAnnotations;

namespace EfCoreExamples.ContextV2.Entities
{
    public abstract record BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
