using ArchaeoAnalysisHub.Data.Repository.Interfaces;
using ArchaeoAnalysisHub.Models;
using ArchaeoAnalysisHub.ViewModels;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
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

        public ActionResult Index()
        {
            return View(repository.GetAll());
        }

        public ActionResult Details(int id)
        {
            var analysis = repository.GetAnalysis(id);
            var viewModel = new AnalysisFormViewModel()
            {
                Id = analysis.Id,
                SampleId = analysis.SampleId,
                Sample = analysis.Sample, 
                AnalysisTypeId = analysis.AnalysisTypeId,
                AnalysisType = analysis.AnalysisType,
                IsBulk = analysis.IsBulk,
                IsNormalised = analysis.IsNormalised,
                OwnerId = analysis.OwnerId,
                Owner = analysis.Owner,
                IsPublic = analysis.IsPublic,
                GeneralImageId = analysis.GeneralImageId,
                GeneralImage = analysis.GeneralImage,
                SpectrumImage = analysis.SpectrumImage,
                SpectrumImageId = analysis.SpectrumImageId,
                SpectrumNo = analysis.SpectrumNo,
                AnalysisDataPoints = analysis.AnalysisDataPoints
            };

            return View(viewModel);
        }

        [Authorize]
        public ActionResult Create()
        {
            var userId = User.Identity.GetUserId();

            var viewModel = new AnalysisFormViewModel()
            {
                Samples = repository.GetSamplesForUser(userId),
                Artifacts = repository.GetArtifactsForUser(userId),
                AnalysisTypes = repository.GetAnalysisTypes(),
                Symbols = repository.GetSymbols(),
                AnalysisDataPoints = new List<AnalysisDataPoint>(),
                Heading = "Create an analysis",
            };

            return View("AnalysisForm", viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AnalysisFormViewModel viewModel)
        {

            var errors = ModelState.Where(x => x.Value.Errors.Any())
                .Select(x => new { x.Key, x.Value.Errors });

            var userId = User.Identity.GetUserId();

            if (!ModelState.IsValid)
            {
                viewModel.Samples = repository.GetSamplesForUser(userId);
                viewModel.Artifacts = repository.GetArtifactsForUser(userId);
                viewModel.AnalysisTypes = repository.GetAnalysisTypes();
                viewModel.Symbols = repository.GetSymbols();
                viewModel.AnalysisDataPoints = new List<AnalysisDataPoint>();
                return View("AnalysisForm", viewModel);
            }

            var analysis = new Analysis
            {
                AnalysisDataPoints = viewModel.AnalysisDataPoints,
                Id = viewModel.Id,
                SampleId = viewModel.SampleId,
                AnalysisTypeId = viewModel.AnalysisTypeId,
                IsBulk = viewModel.IsBulk,
                IsNormalised = viewModel.IsNormalised,
                IsPublic = viewModel.IsPublic,
                SpectrumNo = viewModel.SpectrumNo,
                OwnerId = userId
        };

            repository.Create(analysis);

            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            var userId = User.Identity.GetUserId();

            var analysis = repository.GetAnalysis(id);

            var viewModel = new AnalysisFormViewModel()
            {
                Heading = "Edit an analysis",
                Samples = repository.GetSamplesForUser(userId),
                Artifacts = repository.GetArtifactsForUser(userId),
                AnalysisTypes = repository.GetAnalysisTypes(),
                Symbols = repository.GetSymbols(),
                Id = id,
                SampleId = analysis.SampleId,
                Sample = analysis.Sample,
                AnalysisTypeId = analysis.AnalysisTypeId,
                AnalysisType = analysis.AnalysisType,
                IsBulk = analysis.IsBulk,
                IsNormalised = analysis.IsNormalised,
                AnalysisDataPoints = analysis.AnalysisDataPoints,
                IsPublic = analysis.IsPublic,
                SpectrumNo = analysis.SpectrumNo
            };


            return View("AnalysisForm", viewModel);
        }

        [Authorize]
        public ActionResult Update(AnalysisFormViewModel viewModel)
        {
            var userId = User.Identity.GetUserId();

            if (!ModelState.IsValid)
            {
                viewModel.Samples = repository.GetSamplesForUser(userId);
                viewModel.Artifacts = repository.GetArtifactsForUser(userId);
                viewModel.AnalysisTypes = repository.GetAnalysisTypes();
                viewModel.Symbols = repository.GetSymbols();
                return View("AnalysisForm", viewModel);
            }

            repository.Update(viewModel);

            return RedirectToAction("Details", "Analyses", new { id = viewModel.Id });

        }

        [Authorize]
        public ActionResult Delete(int id)
        {
            repository.Delete(id);
            return RedirectToAction("Index", "Home");
        }
    }
}