using ArchaeoAnalysisHub.BLL.Interfaces;
using ArchaeoAnalysisHub.Data.Repository.Interfaces;
using ArchaeoAnalysisHub.ViewModels;
using System.Web.Mvc;


namespace ArchaeoAnalysisHub.Controllers
{
    public class HomeController : Controller
    {
        private IAnalysesHandler analysesHandler;

        public HomeController(IAnalysesHandler analysesHandler)
        {
            this.analysesHandler = analysesHandler;
        }
        public ActionResult Index()
        {
            var analyses = analysesHandler.GetSummary();
            var viewModel = new AnalysesViewModel()
            {
                Analyses = analyses,
                Heading = "Analyses"
            };

            return View("Analyses", viewModel);
        }

       
    }
}