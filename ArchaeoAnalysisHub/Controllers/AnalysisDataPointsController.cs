using ArchaeoAnalysisHub.BLL.Interfaces;
using ArchaeoAnalysisHub.ViewModels;
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

        [Authorize]
        public ActionResult Edit(int id)
        {
            var viewModel = dataPointsService.GetDataPoint(id);

            return View("AnalysisDataPointForm", viewModel);
        }

        [Authorize]
        public ActionResult Update(AnalysisDataPointFormViewModel viewModel)
        {
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
            var analysisId = dataPointsService.GetDataPoint(id).AnalysisId;
            dataPointsService.DeleteAnalysisDataPoint(id);
            return RedirectToAction("Details", "Analyses", new { id = analysisId });
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