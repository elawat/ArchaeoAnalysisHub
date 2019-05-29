using System.ComponentModel.DataAnnotations;

namespace ArchaeoAnalysisHub.Models
{
    public class Image
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public int ImageTypeId { get; set; }
        public ImageType ImageType { get; set; }
        public string Url { get; set; }
    }
}