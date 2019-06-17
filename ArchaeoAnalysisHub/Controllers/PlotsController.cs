using ArchaeoAnalysisHub.BLL.Interfaces;
using ArchaeoAnalysisHub.ViewModels;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ArchaeoAnalysisHub.Controllers.Api
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
            return View("TernaryPlot");
        }
    }
}
