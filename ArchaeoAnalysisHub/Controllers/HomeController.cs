using ArchaeoAnalysisHub.BLL.Interfaces;
using ArchaeoAnalysisHub.Data.Repository.Interfaces;
using ArchaeoAnalysisHub.ViewModels;
using System.Web.Mvc;


namespace ArchaeoAnalysisHub.Controllers
{
    public class HomeController : Controller
    {
        private IAnalysesService analysesService;

        public HomeController(IAnalysesService analysesHandler)
        {
            this.analysesService = analysesHandler;
        }
        public ActionResult Index()
        {
            var analyses = analysesService.GetSummary();
            var viewModel = new AnalysesViewModel()
            {
                Analyses = analyses,
                Heading = "Analyses"
            };

            return View("Analyses", viewModel);
        }

       
    }
}