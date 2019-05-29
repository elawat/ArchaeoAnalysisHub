using ArchaeoAnalysisHub.Data.Repository.Interfaces;
using System.Web.Mvc;

namespace ArchaeoAnalysisHub.Controllers
{
    public class AnalysesController : Controller
    {
        private IAnalysisRepository repository;

        public AnalysesController(IAnalysisRepository repository)
        {
            this.repository = repository;
        }

        // GET: Analyses
        public ActionResult Index()
        {
            return View(repository.GetAll());
        }
    }
}