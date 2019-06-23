using ArchaeoAnalysisHub.BLL.Interfaces;
using ArchaeoAnalysisHub.Data.Repository.Interfaces;
using ArchaeoAnalysisHub.Models;
using ArchaeoAnalysisHub.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ArchaeoAnalysisHub.BLL
{
    public class AnalysesService : IAnalysesService
    {
        private IAnalysisRepository repository;
        private IAnalysesNormalizer normalizer;

        public AnalysesService(IAnalysisRepository repository, IAnalysesNormalizer normalizer)
        {
            this.repository = repository;
            this.normalizer = normalizer;
        }

        public Analysis GetAnalysis(int id)
        {
            return repository.GetAnalysis(id);
        }

        public List<AnalysisSummary> GetSummary(string query = null)
        {
            var results = from analysis in repository.GetAllForHomeView(query)
                        select new AnalysisSummary()
                        {
                            Id = analysis.Id,
                            Sample = analysis.Sample,
                            AnalysisType = analysis.AnalysisType,
                            IsBulk = analysis.IsBulk,
                            IsNormalised = analysis.IsNormalised,
                            AnalysisDataPoints = (from dataPoint in analysis.AnalysisDataPoints
                                                  orderby dataPoint.ResultInPercentage
                                                  descending
                                                  select new AnalysisDataPoint
                                                  {
                                                      Symbol = dataPoint.Symbol,
                                                      ResultInPercentage = Math.Round(dataPoint.ResultInPercentage, 2)
                                                  }
                                                  ).Take(5).ToList(),
                            Owner = analysis.Owner,
                            IsPublic = analysis.IsPublic,
                            GeneralImage = analysis.GeneralImage
                        };
            return results.ToList();
        }

        public List<Analysis> GetAll()
        {
            return repository.GetAll();
        }

        public List<Analysis> GetAllForHomeView()
        {
            return repository.GetAllForHomeView();
        }

        public AnalysisFormViewModel GetAnalysisDetailedView(int id)
        {
            var analysis = repository.GetAll().Where(a => a.Id == id).FirstOrDefault();

            return Mapper.Map<AnalysisFormViewModel>(analysis);
        }

        public AnalysisFormViewModel GetAnalysisEmptyView(string userId)
        {
            return new AnalysisFormViewModel()
            {
                Samples = repository.GetSamplesForUser(userId),
                Artefacts = repository.GetArtefactsForUser(userId),
                AnalysisTypes = repository.GetAnalysisTypes(),
                Symbols = repository.GetSymbols(),
                AnalysisDataPoints = new List<AnalysisDataPoint>(),
                Heading = "Create an analysis"
            };
        }

        public AnalysisFormViewModel RepopulateListsForAnalysisEmptyView(string userId, AnalysisFormViewModel viewModel)
        {
            viewModel.Samples = repository.GetSamplesForUser(userId);
            viewModel.Artefacts = repository.GetArtefactsForUser(userId);
            viewModel.AnalysisTypes = repository.GetAnalysisTypes();
            viewModel.Symbols = repository.GetSymbols();
            viewModel.AnalysisDataPoints = new List<AnalysisDataPoint>();
            return viewModel;
        }

        public void CreateAnalysis(AnalysisFormViewModel viewModel, string userId)
        {
            var analysis = new Analysis
            {
                AnalysisDataPoints = viewModel.AnalysisDataPoints,
                Id = viewModel.Id,
                SampleId = viewModel.SampleId,
                AnalysisTypeId = viewModel.AnalysisTypeId,
                IsBulk = viewModel.IsBulk,
                IsNormalised = viewModel.IsNormalised,
                IsPublic = viewModel.IsPublic,
                SpectrumNo = viewModel.SpectrumNo,
                OwnerId = userId,
                AddedDate = DateTime.Now
            };

            repository.Create(analysis);
        }

        public AnalysisFormViewModel GetAnalysisDetailedViewForEdit(int id, string userId)
        {
            var analysis = repository.GetAnalysis(id);

            var viewModel = Mapper.Map<AnalysisFormViewModel>(analysis);
            viewModel.Heading = "Edit an analysis";
            viewModel.Samples = repository.GetSamplesForUser(userId);
            viewModel.Artefacts = repository.GetArtefactsForUser(userId);
            viewModel.AnalysisTypes = repository.GetAnalysisTypes();
            viewModel.Symbols = repository.GetSymbols();

            return viewModel;

        }

        public void UpdateAnalysis(AnalysisFormViewModel viewModel)
        {
            repository.Update(viewModel);
        }

        public void DeleteAnalysis(int id)
        {
            repository.Delete(id);
        }

        public IEnumerable<string> GetSymbols()
        {
            return repository.GetSymbols();
        }

        public IEnumerable<Analysis> GetNormalisedAnalysesForSelectedSymbols
            (List<string> symbols, List<Analysis> analyses)
        {
            var results = new List<Analysis>();
            foreach (var analysis in analyses)
            {
                results.Add(normalizer.GetNormalisedDataPointsForSelectedSymbols(symbols, analysis));
            }

            return results;
        }
    }
}