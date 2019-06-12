using ArchaeoAnalysisHub.ViewModels;

namespace ArchaeoAnalysisHub.BLL.Interfaces
{
    public interface IAnalysisDataPointService
    {
        AnalysisDataPointFormViewModel GetDataPoint(int id);
        void UpdateAnalysisDataPoint(AnalysisDataPointFormViewModel viewModel);
        void DeleteAnalysisDataPoint(int id);
        AnalysisDataPointFormViewModel GetAnalysisDataPointEmptyView(int analysisId);
        AnalysisDataPointFormViewModel RepopulateListsForAnalysisDataPointEmptyView(AnalysisDataPointFormViewModel viewModel);
        void CreateAnalysisDataPoint(AnalysisDataPointFormViewModel viewModel);
    }
}
