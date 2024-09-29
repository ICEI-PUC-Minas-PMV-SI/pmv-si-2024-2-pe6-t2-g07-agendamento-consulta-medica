using System.ComponentModel.DataAnnotations;

namespace apirest.Models
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}