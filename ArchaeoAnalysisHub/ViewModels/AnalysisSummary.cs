using ArchaeoAnalysisHub.Models;
using System.Collections.Generic;

namespace ArchaeoAnalysisHub.ViewModels
{
    public class AnalysisSummary
    {
        public int Id { get; set; }
        public Sample Sample { get; set; }
        public AnalysisType AnalysisType { get; set; }
        public bool IsBulk { get; set; }
        public bool IsNormalised { get; set; }
        public List<AnalysisDataPoint> AnalysisDataPoints { get; set; }
        public ApplicationUser Owner { get; set; }
        public bool IsPublic { get; set; }
        public Image GeneralImage { get; set; }
    }
}