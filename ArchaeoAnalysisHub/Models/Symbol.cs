using System.ComponentModel.DataAnnotations;

namespace ArchaeoAnalysisHub.Models
{
    public class Symbol
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name ="Symbol")]
        public string Name { get; set; }
    }
}