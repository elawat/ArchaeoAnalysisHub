using ArchaeoAnalysisHub.Models;
using ArchaeoAnalysisHub.ViewModels;
using System.Collections.Generic;

namespace ArchaeoAnalysisHub.Data.Repository.Interfaces
{
    public interface IArtifactRepository
    {
        Artifact GetArtifact(int id);
        IEnumerable<ArtifactType> GetArtifactTypes();
        void Update(ArtifactFormViewModel viewModel);
        void Create(Artifact artifact);
        void Delete(int id);
    }
}