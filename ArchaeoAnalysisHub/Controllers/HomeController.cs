using ArchaeoAnalysisHub.BLL.Interfaces;
using ArchaeoAnalysisHub.ViewModels;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;


namespace ArchaeoAnalysisHub.Controllers
{
    public class HomeController : Controller
    {
        private IAnalysesService _analysesService;
        private IAnalysesLoader _analysesLoader;

        public HomeController(IAnalysesService analysesHandler, IAnalysesLoader analysesLoader)
        {
            _analysesService = analysesHandler;
            _analysesLoader = analysesLoader;
        }
        public ActionResult Index(string query = null)
        {
            var userId = User.Identity.GetUserId();
            var analyses = _analysesService.GetSummary(query, userId, _analysesLoader.IncrementCount);
            var viewModel = new AnalysesViewModel()
            {
                SearchTerm = query,
                Analyses = analyses,
                Heading = "Analyses"
            };

            return View("Analyses", viewModel);
        }

       
    }
}