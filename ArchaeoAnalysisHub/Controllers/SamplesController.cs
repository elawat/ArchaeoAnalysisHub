﻿using ArchaeoAnalysisHub.Data.Repository.Interfaces;
using ArchaeoAnalysisHub.Models;
using ArchaeoAnalysisHub.ViewModels;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;

namespace ArchaeoAnalysisHub.Controllers
{
    public class SamplesController : Controller
    {
        private ISampleRepository repository;

        public SamplesController(ISampleRepository repository)
        {
            this.repository = repository;
        }

        public ActionResult Details(int id)
        {
            var sample = repository.GetSample(id);
            var viewModel = new SampleFormViewModel()
            {
                Id = sample.Id,
                IsAnalysed = sample.IsAnalysed,
                ArtifactId = sample.ArtifactId,
                Artifact = sample.Artifact,
                Analyses = sample.Analyses,
                SampleTypeId = sample.SampleTypeId,
                SampleType = sample.SampleType,
                Owner = sample.Owner,
                OwnerId = sample.OwnerId,
                IsPublic = sample.IsPublic,
            };

            return View(viewModel);
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            var sample = repository.GetSample(id);
            var viewModel = new SampleFormViewModel()
            {
                Heading = "Edit a Sample",
                Id = sample.Id,
                IsAnalysed = sample.IsAnalysed,
                ArtifactId = sample.ArtifactId,
                Artifact = sample.Artifact,
                Artifacts = sample.Artifacts,
                SampleTypeId = sample.SampleTypeId,
                SampleType = sample.SampleType,
                SampleTypes = sample.SampleTypes,
                IsPublic = sample.IsPublic,
            };

            return View("SampleForm", viewModel);
        }

        [Authorize]
        public ActionResult Update(SampleFormViewModel viewModel)
        {
            var userId = User.Identity.GetUserId();

            if (!ModelState.IsValid)
            {
                viewModel.SampleTypes = repository.GetSampleTypes();
                viewModel.Artifacts = repository.GetArtifactsForUser(userId);
                return View("SampleForm", viewModel);
            }

            repository.Update(viewModel);

            return RedirectToAction("Details", "Samples", new { id = viewModel.Id });

        }

        [Authorize]
        public ActionResult Create()
        {

            var userId = User.Identity.GetUserId();

            var viewModel = new SampleFormViewModel()
            {
                SampleTypes = repository.GetSampleTypes(),
                Artifacts = repository.GetArtifactsForUser(userId),
                Heading = "Create a sample",
            };

            return View("SampleForm", viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SampleFormViewModel viewModel)
        {

            var userId = User.Identity.GetUserId();
            

            if (!ModelState.IsValid)
            {
                viewModel.SampleTypes = repository.GetSampleTypes();
                viewModel.Artifacts = repository.GetArtifactsForUser(userId);
                return View("SampleForm", viewModel);
            }

            var artifact = new Sample
            {
                IsAnalysed = viewModel.IsAnalysed,
                ArtifactId = viewModel.ArtifactId,
                SampleTypeId = viewModel.SampleTypeId,
                OwnerId = userId,
                IsPublic = viewModel.IsPublic,
                IsDeleted = false
            };

            repository.Create(artifact);

            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public ActionResult Delete(int id)
        {
            repository.Delete(id);
            return RedirectToAction("Index", "Home");
        }
    }
}