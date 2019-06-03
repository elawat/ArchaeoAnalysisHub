using ArchaeoAnalysisHub.Models;
using ArchaeoAnalysisHub.ViewModels;
using System.Collections.Generic;

namespace ArchaeoAnalysisHub.Data.Repository.Interfaces
{
    public interface ISampleRepository
    {
        Sample GetSample(int id);
        IEnumerable<SampleType> GetSampleTypes();
        IEnumerable<Artifact> GetArtifactsForUser(string userId);
        void Update(SampleFormViewModel updatedSample);
        void Create(Sample sample);
        void Delete(int id);
    }
}
