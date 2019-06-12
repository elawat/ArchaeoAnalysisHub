using ArchaeoAnalysisHub.Models;
using ArchaeoAnalysisHub.ViewModels;
using System.Collections.Generic;

namespace ArchaeoAnalysisHub.Data.Repository.Interfaces
{
    public interface IArtifactRepository
    {
        Artefact GetArtifact(int id);
        IEnumerable<ArtefactType> GetArtifactTypes();
        void Update(ArtefactFormViewModel viewModel);
        void Create(Artefact artifact);
        void Delete(int id);
    }
}