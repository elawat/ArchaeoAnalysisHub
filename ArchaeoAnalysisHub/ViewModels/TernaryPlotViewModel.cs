using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ArchaeoAnalysisHub.ViewModels
{
    public class TernaryPlotViewModel
    {
        public IEnumerable<string> Symbols { get; set; }
        public string Heading { get; set; }
        [Display(Name = "Vertex A")]
        public string SymbolA { get; set; }
        [Display(Name = "Vertex B")]
        public string SymbolB { get; set; }
        [Display(Name = "Vertex C")]
        public string SymbolC { get; set; }
    }
}