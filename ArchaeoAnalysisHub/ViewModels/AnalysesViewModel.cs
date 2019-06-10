using ArchaeoAnalysisHub.Models;
using System.Collections.Generic;

namespace ArchaeoAnalysisHub.ViewModels
{
    public class AnalysesViewModel
    {
        public IEnumerable<AnalysisSummary> Analyses { get; set; }
        public string Heading { get; set; }
    }
}