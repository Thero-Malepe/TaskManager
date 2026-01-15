using System.ComponentModel.DataAnnotations;

namespace TaskManager.Models
{
    public class TaskModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public string Status { get; set; } = string.Empty;

        public DateTime DueDate { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
