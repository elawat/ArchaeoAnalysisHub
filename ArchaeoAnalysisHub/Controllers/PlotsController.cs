using ArchaeoAnalysisHub.BLL.Interfaces;
using ArchaeoAnalysisHub.ViewModels;
using System.Net.Http;
using System.Threading.Tasks;
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

        public Task<HttpResponseMessage> ApiHelper { get; private set; }

        public ActionResult SelectAnalyses()
        {
            var analyses = analysesService.GetSummary();
            var viewModel = new AnalysesViewModel()
            {
                Analyses = analyses,
                Heading = "Select analyses",
                IsInSelectMode = true
            };

            return View("Analyses", viewModel);
        }

        public ActionResult TernaryPlot()
        {
            var viewModel = new TernaryPlotViewModel()
            {
                Symbols = analysesService.GetSymbols(),
                Heading = "Ternary plot"
            };
            return View("TernaryPlot", viewModel);
        }
    }
}
