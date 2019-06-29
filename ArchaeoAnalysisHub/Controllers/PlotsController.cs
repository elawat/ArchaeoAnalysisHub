using ArchaeoAnalysisHub.BLL.Interfaces;
using ArchaeoAnalysisHub.ViewModels;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;

namespace ArchaeoAnalysisHub.Controllers
{
    public class PlotsController : Controller
    {
        private IAnalysesService _analysesService;
        private IAnalysesLoader _analysesLoader;

        public PlotsController(IAnalysesService analysesHandler, IAnalysesLoader analysesLoader)
        {
            _analysesService = analysesHandler;
            _analysesLoader = analysesLoader;
        }

        public ActionResult SelectAnalyses(string query = null)
        {
            var userId = User.Identity.GetUserId();
            var analyses = _analysesService.GetSummary(query, userId, _analysesLoader.IncrementCount);
            var ternaryPlot = new TernaryPlotViewModel()
            {
                Symbols = _analysesService.GetSymbols(),
            };
            var viewModel = new AnalysesViewModel()
            {
                SearchTerm = query,
                Analyses = analyses,
                Heading = "Select analyses",
                IsInSelectMode = true,
                TernaryPlot = ternaryPlot
            };

            return View("Analyses", viewModel);
        }

        public ActionResult TernaryPlot(TernaryPlotViewModel plot)
        {

            if (!ModelState.IsValid || !plot.IsValid())
            {
                if (plot.Heading is null)
                {

                    plot.Symbols = _analysesService.GetSymbols();
                    var analyses = _analysesService.GetSummary();
                    var vModel = new AnalysesViewModel()
                    {
                        Analyses = analyses,
                        Heading = "Select analyses",
                        IsInSelectMode = true,
                        TernaryPlot = plot
                    };
                    return View("Analyses", vModel);
                }
            }

            plot.Symbols = _analysesService.GetSymbols();
            plot.Heading = "Ternary plot";

            return View("TernaryPlot", plot);
        }
    }
}
