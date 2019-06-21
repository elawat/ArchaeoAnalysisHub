using ArchaeoAnalysisHub.BLL.Interfaces;
using ArchaeoAnalysisHub.ViewModels;
using System.Web.Mvc;

namespace ArchaeoAnalysisHub.Controllers
{
    public class PlotsController : Controller
    {
        private IAnalysesService analysesService;

        public PlotsController(IAnalysesService analysesHandler)
        {
            this.analysesService = analysesHandler;
        }

        public ActionResult SelectAnalyses()
        {
            var analyses = analysesService.GetSummary();
            var ternaryPlot = new TernaryPlotViewModel()
            {
                Symbols = analysesService.GetSymbols(),
            };
            var viewModel = new AnalysesViewModel()
            {
                Analyses = analyses,
                Heading = "Select analyses",
                IsInSelectMode = true,
                TernaryPlot = ternaryPlot
            };

            return View("Analyses", viewModel);
        }

        public ActionResult TernaryPlot(TernaryPlotViewModel plot)
        {

            if (!ModelState.IsValid)
            {
                if (plot.Heading is null)
                {
                    var ternaryPlot = new TernaryPlotViewModel()
                    {
                        Symbols = analysesService.GetSymbols(),
                    };
                    var analyses = analysesService.GetSummary();
                    var vModel = new AnalysesViewModel()
                    {
                        Analyses = analyses,
                        Heading = "Select analyses",
                        IsInSelectMode = true,
                        TernaryPlot = ternaryPlot
                    };
                    return View("Analyses", vModel);
                }
            }
            var viewModel = new TernaryPlotViewModel()
            {
                Symbols = analysesService.GetSymbols(),
                SymbolA = plot.SymbolA,
                SymbolB = plot.SymbolB,
                SymbolC = plot.SymbolC,
                Heading = "Ternary plot"
            };
            return View("TernaryPlot", viewModel);
        }
    }
}
