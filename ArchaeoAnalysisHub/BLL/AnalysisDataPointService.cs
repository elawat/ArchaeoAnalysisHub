using ArchaeoAnalysisHub.BLL.Interfaces;
using ArchaeoAnalysisHub.Data.Repository.Interfaces;
using ArchaeoAnalysisHub.Models;
using ArchaeoAnalysisHub.ViewModels;
using AutoMapper;

namespace ArchaeoAnalysisHub.BLL
{
    public class AnalysisDataPointService : IAnalysisDataPointService
    {
        private IAnalysisRepository repository;

        public AnalysisDataPointService(IAnalysisRepository repository)
        {
            this.repository = repository;
        }

        public AnalysisDataPointFormViewModel GetDataPoint(int id)
        {
            var dataPoint = repository.GetDataPoint(id);
            var viewModel = Mapper.Map<AnalysisDataPointFormViewModel>(dataPoint);
            viewModel.Symbols = repository.GetSymbols();
            return viewModel;
        }

        public void UpdateAnalysisDataPoint(AnalysisDataPointFormViewModel viewModel)
        {
            repository.UpdateDataPoint(viewModel);
        }

        public void DeleteAnalysisDataPoint(int id)
        {
            repository.DeleteDataPoint(id);
        }

        public AnalysisDataPointFormViewModel GetAnalysisDataPointEmptyView(int analysisId)
        {
            return new AnalysisDataPointFormViewModel()
            {
                AnalysisId = analysisId,
                Symbols = repository.GetSymbols()
            };
        }

        public AnalysisDataPointFormViewModel RepopulateListsForAnalysisDataPointEmptyView(AnalysisDataPointFormViewModel viewModel)
        {
            return new AnalysisDataPointFormViewModel()
            {
                AnalysisId = viewModel.AnalysisId,
                Symbol = viewModel.Symbol,
                ResultInPercentage = viewModel.ResultInPercentage,
                Symbols = repository.GetSymbols()
            };
        }

        public void CreateAnalysisDataPoint(AnalysisDataPointFormViewModel viewModel)
        {
            var dataPoint = new AnalysisDataPoint()
            {
                Symbol = viewModel.Symbol,
                ResultInPercentage = viewModel.ResultInPercentage,
                AnalysisId = viewModel.AnalysisId,
            };

            repository.CreateDataPoint(dataPoint);
        }
    }
}