using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ArchaeoAnalysisHub.ViewModels
{
    public class TernaryPlotViewModel
    {
        public IEnumerable<string> Symbols { get; set; }
        public string Heading { get; set; }
        [Display(Name = "Vertex A")]
        [Required]
        public string SymbolA { get; set; }
        [Display(Name = "Vertex B")]
        [Required]
        public string SymbolB { get; set; }
        [Display(Name = "Vertex C")]
        [Required]
        public string SymbolC { get; set; }
        public bool SymbolsSelectionIsValid { get; private set; }

        public TernaryPlotViewModel()
        {
            SymbolsSelectionIsValid = true;
        }
        public bool IsValid()
        {
            if (SymbolA == SymbolB || SymbolA == SymbolC || SymbolB == SymbolC)
            {
                SymbolsSelectionIsValid = false;
                return false;
            }
            else
            {
                SymbolsSelectionIsValid = true;
                return true;
            }
        }
    }
}