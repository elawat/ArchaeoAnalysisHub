using ArchaeoAnalysisHub.Models;
using ArchaeoAnalysisHub.ViewModels;
using System.Collections.Generic;

namespace ArchaeoAnalysisHub.BLL.Interfaces
{
    public interface IAnalysesService
    {
        Analysis GetAnalysis(int id);
        List<AnalysisSummary> GetSummary(string query = null, string userId = null);
        List<Analysis> GetAll();
        AnalysisFormViewModel GetAnalysisDetailedView(int id, string userId = null);
        AnalysisFormViewModel GetAnalysisEmptyView(string userId);
        AnalysisFormViewModel RepopulateListsForAnalysisEmptyView(string userId, AnalysisFormViewModel viewModel);
        void CreateAnalysis(AnalysisFormViewModel viewModel, string userId);
        AnalysisFormViewModel GetAnalysisDetailedViewForEdit(int id, string userId);
        void UpdateAnalysis(AnalysisFormViewModel viewModel);
        void DeleteAnalysis(int id);
        IEnumerable<string> GetSymbols();
        IEnumerable<Analysis> GetNormalisedAnalysesForSelectedSymbols(List<string> symbols, List<Analysis> analyses);
    }
}
