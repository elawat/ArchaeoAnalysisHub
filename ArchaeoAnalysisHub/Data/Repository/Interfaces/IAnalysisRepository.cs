using ArchaeoAnalysisHub.Models;
using System.Collections.Generic;

namespace ArchaeoAnalysisHub.Data.Repository.Interfaces
{
    public interface IAnalysisRepository
    {
        List<Analysis> GetAll();
        Analysis GetAnalysis(int id);
        List<Sample> GetSamplesForUser(string userId);
        List<Artifact> GetArtifactsForUser(string userId);
        List<AnalysisType> GetAnalysisTypes();
        List<string> GetSymbols();
    }
}
