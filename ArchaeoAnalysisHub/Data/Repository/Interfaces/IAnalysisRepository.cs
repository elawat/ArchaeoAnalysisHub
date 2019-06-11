using ArchaeoAnalysisHub.Models;
using ArchaeoAnalysisHub.ViewModels;
using System.Collections.Generic;

namespace ArchaeoAnalysisHub.Data.Repository.Interfaces
{
    public interface IAnalysisRepository
    {
        List<Analysis> GetAll();
        List<Analysis> GetAllForHomeView();
        Analysis GetAnalysis(int id);
        List<Sample> GetSamplesForUser(string userId);
        List<Artifact> GetArtifactsForUser(string userId);
        List<AnalysisType> GetAnalysisTypes();
        List<string> GetSymbols();
        void Update(AnalysisFormViewModel updateAnalysis);
        void Create(Analysis analysis);
        void Delete(int id);


    }
}
