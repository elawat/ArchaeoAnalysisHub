using ArchaeoAnalysisHub.Data.Repository.Interfaces;
using ArchaeoAnalysisHub.Models;
using ArchaeoAnalysisHub.ViewModels;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;

namespace ArchaeoAnalysisHub.Controllers
{
    public class ArtifactsController : Controller
    {
        private IArtifactRepository repository;

        public ArtifactsController(IArtifactRepository repository)
        {
            this.repository = repository;
        }

        public ActionResult Details(int id)
        {
            var artifact = repository.GetArtifact(id);
            var viewModel = new ArtifactFormViewModel()
            {
                Id = artifact.Id,
                Name = artifact.Name,
                Description = artifact.Description,
                ArtifactType = artifact.ArtifactType,
                Country = artifact.Country,
                Site = artifact.Site,
                Owner = artifact.Owner,
                Samples = artifact.Samples

            };
            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
            var artifact = repository.GetArtifact(id);
            var viewModel = new ArtifactFormViewModel()
            {
                Heading = "Edit an Artifact",
                Id = artifact.Id,
                Name = artifact.Name,
                Description = artifact.Description,
                ArtifactTypeId = artifact.ArtifactTypeId,
                ArtifactType = artifact.ArtifactType,
                Country = artifact.Country,
                Site = artifact.Site,
                ArtifactTypes = repository.GetArtifactTypes()

            };

            return View("ArtifactForm", viewModel);
        }

        public ActionResult Update(ArtifactFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.ArtifactTypes = repository.GetArtifactTypes();
                return View("ArtifactForm", viewModel);
            }

            repository.Update(viewModel);

            return RedirectToAction("Details", "Artifacts", new { id = viewModel.Id });

        }

        public ActionResult Create()
        {
            var viewModel = new ArtifactFormViewModel()
            {
                ArtifactTypes = repository.GetArtifactTypes(),
                Heading = "Create an artifact",
        };
            return View("ArtifactForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ArtifactFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.ArtifactTypes = repository.GetArtifactTypes();
                return View("ArtifactForm", viewModel);
            }


            var artifact = new Artifact
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                Description = viewModel.Name,
                ArtifactTypeId = viewModel.ArtifactTypeId,
                Country = viewModel.Country,
                Site = viewModel.Site,
                OwnerId = User.Identity.GetUserId(),
                IsPublic = viewModel.IsPublic
            };

            repository.Create(artifact);

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Delete(int id)
        {
            repository.Delete(id);
            return RedirectToAction("Index", "Home");
        }

    }
}