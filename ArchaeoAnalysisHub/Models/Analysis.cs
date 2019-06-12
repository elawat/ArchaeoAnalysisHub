using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace ArchaeoAnalysisHub.Models
{
    public class Analysis
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int SampleId { get; set; }
        public Sample Sample { get; set; }
        [Required]
        public int AnalysisTypeId { get; set; }
        public AnalysisType AnalysisType { get; set; }
        [Display(Name = "Bulk")]
        public bool IsBulk { get; set; }
        public bool IsNormalised { get; set; }
        public ICollection<AnalysisDataPoint> AnalysisDataPoints { get; set; }
        public ApplicationUser Owner { get; set; }
        [Required]
        public string OwnerId { get; set; }
        public bool IsPublic { get; set; }
        public int? GeneralImageId { get; set; }
        public Image GeneralImage { get; set; }
        public int? SpectrumImageId { get; set; }
        public Image SpectrumImage { get; set; }
        [Display(Name = "Spectrum")]
        public string SpectrumNo { get; set; }
    }
}