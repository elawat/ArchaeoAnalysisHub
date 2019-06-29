using ArchaeoAnalysisHub.BLL.Interfaces;
using ArchaeoAnalysisHub.ViewModels;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;

namespace ArchaeoAnalysisHub.Controllers
{
    public class AnalysesController : Controller
    {
        private IAnalysesService _analysesService;
        private IAnalysesLoader _analysesLoader;

        public AnalysesController(IAnalysesService analysesService, IAnalysesLoader analysesLoader)
        {
            _analysesService = analysesService;
            _analysesLoader = analysesLoader;
        }

        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Details(int id)
        {
            var userId = User.Identity.GetUserId();

            return View(_analysesService.GetAnalysisDetailedView(id, userId));
        }

        [Authorize]
        public ActionResult Create()
        {
            var userId = User.Identity.GetUserId();

            var viewModel = _analysesService.GetAnalysisEmptyView(userId);

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
                var repopulatedViewModel = _analysesService.RepopulateListsForAnalysisEmptyView(userId, viewModel);
                return View("AnalysisForm", viewModel);
            }

            _analysesService.CreateAnalysis(viewModel, userId);

            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            var userId = User.Identity.GetUserId();

            var viewModel = _analysesService.GetAnalysisDetailedViewForEdit(id, userId);

            return View("AnalysisForm", viewModel);
        }

        [Authorize]
        public ActionResult Update(AnalysisFormViewModel viewModel)
        {
            var userId = User.Identity.GetUserId();

            if (!ModelState.IsValid)
            {
                var repopulatedViewModel = _analysesService.RepopulateListsForAnalysisEmptyView(userId, viewModel);
                return View("AnalysisForm", viewModel);
            }

            _analysesService.UpdateAnalysis(viewModel);

            return RedirectToAction("Details", "Analyses", new { id = viewModel.Id });

        }

        [Authorize]
        public ActionResult Delete(int id)
        {
            _analysesService.DeleteAnalysis(id);
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult Search(AnalysesViewModel viewModel)
        {
            if (viewModel.IsInSelectMode)
            {
                return RedirectToAction("SelectAnalyses", "Plots", new { query = viewModel.SearchTerm });
            }
            else
            {
                return RedirectToAction("Index", "Home", new { query = viewModel.SearchTerm });
            }
        }

        public ActionResult LoadMore(bool isInSelectMode = false, string searchedTerm = null)
        {

            _analysesLoader.Increment();
            if (isInSelectMode)
            {
                return RedirectToAction("SelectAnalyses", "Plots", new { query = searchedTerm });
            }
            else
            {
                return RedirectToAction("Index", "Home", new { query = searchedTerm });
            }

        }
    }
}