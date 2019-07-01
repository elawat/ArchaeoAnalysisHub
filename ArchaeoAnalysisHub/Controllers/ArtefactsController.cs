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
        private IArtefactRepository repository;

        public ArtefactsController(IArtefactRepository repository)
        {
            this.repository = repository;
        }

        public ActionResult Details(int id)
        {
            var userId = User.Identity.GetUserId();
            var artefact = repository.GetArtefact(id);
            var viewModel = new ArtefactFormViewModel()
            {
                Id = artefact.Id,
                Name = artefact.Name,
                Description = artefact.Description,
                ArtefactType = artefact.ArtefactType,
                Country = artefact.Country,
                Site = artefact.Site,
                OwnerId = artefact.OwnerId,
                Owner = artefact.Owner,
                Samples = artefact.Samples,
                AddedDate = artefact.AddedDate,
                Period = artefact.Period
            };

            if (viewModel.OwnerId == userId)
            {
                viewModel.ShowActionButtons = true;
            }

            return View(viewModel);
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            var artefact = repository.GetArtefact(id);
            var viewModel = new ArtefactFormViewModel()
            {
                Heading = "Edit an Artefact",
                Id = artefact.Id,
                Name = artefact.Name,
                Description = artefact.Description,
                ArtefactTypeId = artefact.ArtefactTypeId,
                ArtefactType = artefact.ArtefactType,
                Country = artefact.Country,
                Site = artefact.Site,
                ArtefactTypes = repository.GetArtefactTypes(),
                Period = artefact.Period
            };

            return View("ArtefactForm", viewModel);
        }

        [Authorize]
        public ActionResult Update(ArtefactFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.ArtefactTypes = repository.GetArtefactTypes();
                return View("ArtefactForm", viewModel);
            }

            repository.Update(viewModel);

            return RedirectToAction("Details", "Artefacts", new { id = viewModel.Id });

        }

        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new ArtefactFormViewModel()
            {
                ArtefactTypes = repository.GetArtefactTypes(),
                Heading = "Create an artefact",
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
                viewModel.ArtefactTypes = repository.GetArtefactTypes();
                return View("ArtefactForm", viewModel);
            }

            var artefact = new Artefact
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                Description = viewModel.Name,
                ArtefactTypeId = viewModel.ArtefactTypeId,
                Country = viewModel.Country,
                Site = viewModel.Site,
                OwnerId = User.Identity.GetUserId(),
                IsPublic = viewModel.IsPublic,
                AddedDate = DateTime.Now,
                Period = viewModel.Period
            };

            repository.Create(artefact);

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