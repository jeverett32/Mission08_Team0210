using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission08_TeamXXXX.Models
{
    public class TaskModel
    {
        [Key]
        [Required]
        public int TaskId { get; set; }

        [Required]
        public string TaskName { get; set; }

        public string? DueDate { get; set; }

        [Required]
        public int Quadrant { get; set; }

        // Foreign Key Setup
        [ForeignKey("CategoryId")]
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

        public bool Completed { get; set; } = false;
    }
}