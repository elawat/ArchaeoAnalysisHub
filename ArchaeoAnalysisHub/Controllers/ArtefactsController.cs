using ArchaeoAnalysisHub.Data.Repository.Interfaces;
using ArchaeoAnalysisHub.Models;
using ArchaeoAnalysisHub.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Web.Mvc;

namespace ArchaeoAnalysisHub.Controllers
{
    public class ArtefactsController : Controller
    {
        private IArtifactRepository repository;

        public ArtefactsController(IArtifactRepository repository)
        {
            this.repository = repository;
        }

        public ActionResult Details(int id)
        {
            var artefact = repository.GetArtifact(id);
            var viewModel = new ArtefactFormViewModel()
            {
                Id = artefact.Id,
                Name = artefact.Name,
                Description = artefact.Description,
                ArtifactType = artefact.ArtefactType,
                Country = artefact.Country,
                Site = artefact.Site,
                Owner = artefact.Owner,
                Samples = artefact.Samples,
                AddedDate = artefact.AddedDate
            };

            return View(viewModel);
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            var artefact = repository.GetArtifact(id);
            var viewModel = new ArtefactFormViewModel()
            {
                Heading = "Edit an Artifact",
                Id = artefact.Id,
                Name = artefact.Name,
                Description = artefact.Description,
                ArtifactTypeId = artefact.ArtefactTypeId,
                ArtifactType = artefact.ArtefactType,
                Country = artefact.Country,
                Site = artefact.Site,
                ArtefactTypes = repository.GetArtifactTypes()

            };

            return View("ArtefactForm", viewModel);
        }

        [Authorize]
        public ActionResult Update(ArtefactFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.ArtefactTypes = repository.GetArtifactTypes();
                return View("ArtefactForm", viewModel);
            }

            repository.Update(viewModel);

            return RedirectToAction("Details", "Artifacts", new { id = viewModel.Id });

        }

        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new ArtefactFormViewModel()
            {
                ArtefactTypes = repository.GetArtifactTypes(),
                Heading = "Create an artifact",
            };

            return View("ArtefactForm", viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ArtefactFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.ArtefactTypes = repository.GetArtifactTypes();
                return View("ArtefactForm", viewModel);
            }

            var artifact = new Artefact
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                Description = viewModel.Name,
                ArtefactTypeId = viewModel.ArtifactTypeId,
                Country = viewModel.Country,
                Site = viewModel.Site,
                OwnerId = User.Identity.GetUserId(),
                IsPublic = viewModel.IsPublic,
                AddedDate = DateTime.Now
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