using ArchaeoAnalysisHub.BLL.Interfaces;
using ArchaeoAnalysisHub.ViewModels;
using Microsoft.AspNet.Identity;
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
        public ActionResult Index(string query = null)
        {
            var userId = User.Identity.GetUserId();
            var analyses = analysesService.GetSummary(query, userId);
            var viewModel = new AnalysesViewModel()
            {
                Analyses = analyses,
                Heading = "Analyses",
                IsInSelectMode = false
            };

            return View("Analyses", viewModel);
        }

       
    }
}