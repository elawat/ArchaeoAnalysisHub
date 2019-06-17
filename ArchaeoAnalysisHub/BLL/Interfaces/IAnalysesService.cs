using ArchaeoAnalysisHub.Models;
using ArchaeoAnalysisHub.ViewModels;
using System.Collections.Generic;

namespace ArchaeoAnalysisHub.BLL.Interfaces
{
    public interface IAnalysesService
    {
        Analysis GetAnalysis(int id);
        List<AnalysisSummary> GetSummary();
        List<Analysis> GetAll();
        AnalysisFormViewModel GetAnalysisDetailedView(int id);
        AnalysisFormViewModel GetAnalysisEmptyView(string userId);
        AnalysisFormViewModel RepopulateListsForAnalysisEmptyView(string userId, AnalysisFormViewModel viewModel);
        void CreateAnalysis(AnalysisFormViewModel viewModel, string userId);
        AnalysisFormViewModel GetAnalysisDeteiledViewForEdit(int id, string userId);
        void UpdateAnalysis(AnalysisFormViewModel viewModel);
        void DeleteAnalysis(int id);
    }
}
