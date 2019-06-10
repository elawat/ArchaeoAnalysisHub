using ArchaeoAnalysisHub.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ArchaeoAnalysisHub.ViewModels
{
    public class AnalysisFormViewModel
    {
        public int Id { get; set; }
        [Required]
        public int SampleId { get; set; }
        public Sample Sample { get; set; }
        [Required]
        public int AnalysisTypeId { get; set; }
        public AnalysisType AnalysisType { get; set; }
        [Display(Name = "Bulk")]
        [Required]
        public bool IsBulk { get; set; }
        [Required]
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
        public string SpectrumNo { get; set; }
        public string Heading { get; set; }
        public ICollection<Sample> Samples { get; set; }
        public ICollection<Artifact> Artifacts { get; set; }
        public ICollection<AnalysisType> AnalysisTypes { get; set; }
        public ICollection<string> Symbols { get; set; }
    }
}