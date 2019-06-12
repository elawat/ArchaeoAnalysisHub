using ArchaeoAnalysisHub.BLL.Interfaces;
using ArchaeoAnalysisHub.ViewModels;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;

namespace ArchaeoAnalysisHub.Controllers
{
    public class AnalysisDataPointsController : Controller
    {
        private IAnalysisDataPointService dataPointsService;

        public AnalysisDataPointsController(IAnalysisDataPointService dataPointsService)
        {
            this.dataPointsService = dataPointsService;
        }

        public ActionResult Details(int id)
        {

            var viewModel = dataPointsService.GetDataPoint(id);

            return View("Details", viewModel);
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            var viewModel = dataPointsService.GetDataPoint(id);

            return View("AnalysisDataPointForm", viewModel);
        }

        [Authorize]
        public ActionResult Update(AnalysisDataPointFormViewModel viewModel)
        {
            var userId = User.Identity.GetUserId();

            if (!ModelState.IsValid)
            {
                return View("AnalysisDataPointForm", viewModel);
            }

            dataPointsService.UpdateAnalysisDataPoint(viewModel);

            return RedirectToAction("Details", "Analyses", new { id = viewModel.AnalysisId });

        }

        [Authorize]
        public ActionResult Delete(int id)
        {
            dataPointsService.DeleteAnalysisDataPoint(id);
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public ActionResult Create(int analysisId)
        {
            var viewModel = dataPointsService.GetAnalysisDataPointEmptyView(analysisId);

            return View("AnalysisDataPointForm", viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AnalysisDataPointFormViewModel viewModel)
        {
            var userId = User.Identity.GetUserId();

            if (!ModelState.IsValid)
            {
                var repopulatedViewModel = dataPointsService.RepopulateListsForAnalysisDataPointEmptyView(viewModel);
                return View("AnalysisDataPointForm", repopulatedViewModel);
            }

            dataPointsService.CreateAnalysisDataPoint(viewModel);

            return RedirectToAction("Details", "Analyses", new { id = viewModel.AnalysisId });
        }
    }
}