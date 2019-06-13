using ArchaeoAnalysisHub.Models;
using ArchaeoAnalysisHub.ViewModels;
using System.Collections.Generic;

namespace ArchaeoAnalysisHub.Data.Repository.Interfaces
{
    public interface IArtefactRepository
    {
        Artefact GetArtefact(int id);
        IEnumerable<ArtefactType> GetArtefactTypes();
        void Update(ArtefactFormViewModel viewModel);
        void Create(Artefact artefact);
        void Delete(int id);
    }
}