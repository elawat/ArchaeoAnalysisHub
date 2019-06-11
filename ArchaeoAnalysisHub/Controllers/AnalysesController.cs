using ArchaeoAnalysisHub.BLL.Interfaces;
using ArchaeoAnalysisHub.Data.Repository.Interfaces;
using ArchaeoAnalysisHub.ViewModels;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;

namespace ArchaeoAnalysisHub.Controllers
{
    public class AnalysesController : Controller
    {
        private IAnalysisRepository repository;
        private IAnalysesService analysesService;

        public AnalysesController(IAnalysisRepository repository, IAnalysesService analysesService)
        {
            this.repository = repository;
            this.analysesService = analysesService;
        }

        public ActionResult Index()
        {
            return View(analysesService.GetAll());
        }

        public ActionResult Details(int id)
        {
            return View(analysesService.GetAnalysisDetailedView(id));
        }

        [Authorize]
        public ActionResult Create()
        {
            var userId = User.Identity.GetUserId();

            var viewModel = analysesService.GetAnalysisEmptyView(userId);

            return View("AnalysisForm", viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AnalysisFormViewModel viewModel)
        {
            var userId = User.Identity.GetUserId();

            if (!ModelState.IsValid)
            {
                var repopulatedViewModel = analysesService.RepopulateListsForAnalysisEmptyView(userId, viewModel);
                return View("AnalysisForm", viewModel);
            }

            analysesService.CreateAnalysis(viewModel, userId);

            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            var userId = User.Identity.GetUserId();

            var viewModel = analysesService.GetAnalysisDeteiledViewForEdit(id, userId);

            return View("AnalysisForm", viewModel);
        }

        [Authorize]
        public ActionResult Update(AnalysisFormViewModel viewModel)
        {
            var userId = User.Identity.GetUserId();

            if (!ModelState.IsValid)
            {
                var repopulatedViewModel = analysesService.RepopulateListsForAnalysisEmptyView(userId, viewModel);
                return View("AnalysisForm", viewModel);
            }

            analysesService.UpdateAnalysis(viewModel);

            return RedirectToAction("Details", "Analyses", new { id = viewModel.Id });

        }

        [Authorize]
        public ActionResult Delete(int id)
        {
            analysesService.DeleteAnalysis(id);
            return RedirectToAction("Index", "Home");
        }
    }
}