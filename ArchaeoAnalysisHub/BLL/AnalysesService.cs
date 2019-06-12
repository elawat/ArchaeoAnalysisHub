﻿using ArchaeoAnalysisHub.BLL.Interfaces;
using ArchaeoAnalysisHub.Data.Repository.Interfaces;
using ArchaeoAnalysisHub.Models;
using ArchaeoAnalysisHub.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ArchaeoAnalysisHub.BLL
{
    public class AnalysesService : IAnalysesService
    {
        private IAnalysisRepository repository;
        private List<Analysis> analyses;

        public AnalysesService(IAnalysisRepository repository)
        {
            this.repository = repository;
            this.analyses = repository.GetAll(); 
        }

        public List<AnalysisSummary> GetSummary()
        {
            var query = from analysis in repository.GetAllForHomeView()
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
                                                      ResultInPercentage = Math.Round(dataPoint.ResultInPercentage,2)
                                                  }
                                                  ).Take(5).ToList(),
                            Owner = analysis.Owner,
                            IsPublic = analysis.IsPublic,
                            GeneralImage = analysis.GeneralImage
                        };
            return query.ToList();
        }

        public List<Analysis> GetAll()
        {
            return analyses;
        }

        public List<Analysis> GetAllForHomeView()
        {
            return repository.GetAllForHomeView();
        }

        public AnalysisFormViewModel GetAnalysisDetailedView(int id)
        {
            var analysis = analyses.Where(a => a.Id == id).FirstOrDefault();
            return new AnalysisFormViewModel()
            {
                Id = analysis.Id,
                SampleId = analysis.SampleId,
                Sample = analysis.Sample,
                AnalysisTypeId = analysis.AnalysisTypeId,
                AnalysisType = analysis.AnalysisType,
                IsBulk = analysis.IsBulk,
                IsNormalised = analysis.IsNormalised,
                OwnerId = analysis.OwnerId,
                Owner = analysis.Owner,
                IsPublic = analysis.IsPublic,
                GeneralImageId = analysis.GeneralImageId,
                GeneralImage = analysis.GeneralImage,
                SpectrumImage = analysis.SpectrumImage,
                SpectrumImageId = analysis.SpectrumImageId,
                SpectrumNo = analysis.SpectrumNo,
                AnalysisDataPoints = analysis.AnalysisDataPoints,
                AddedDate = analysis.AddedDate
            };
        }

        public AnalysisFormViewModel GetAnalysisEmptyView(string userId)
        {
            return new AnalysisFormViewModel()
            {
                Samples = repository.GetSamplesForUser(userId),
                Artifacts = repository.GetArtifactsForUser(userId),
                AnalysisTypes = repository.GetAnalysisTypes(),
                Symbols = repository.GetSymbols(),
                AnalysisDataPoints = new List<AnalysisDataPoint>(),
                Heading = "Create an analysis"
            };
        }

        public AnalysisFormViewModel RepopulateListsForAnalysisEmptyView(string userId, AnalysisFormViewModel viewModel)
        {
            viewModel.Samples = repository.GetSamplesForUser(userId);
            viewModel.Artifacts = repository.GetArtifactsForUser(userId);
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

        public AnalysisFormViewModel GetAnalysisDeteiledViewForEdit(int id, string userId)
        {
            var analysis = repository.GetAnalysis(id);

            return new AnalysisFormViewModel()
            {
                Heading = "Edit an analysis",
                Samples = repository.GetSamplesForUser(userId),
                Artifacts = repository.GetArtifactsForUser(userId),
                AnalysisTypes = repository.GetAnalysisTypes(),
                Symbols = repository.GetSymbols(),
                Id = id,
                SampleId = analysis.SampleId,
                Sample = analysis.Sample,
                AnalysisTypeId = analysis.AnalysisTypeId,
                AnalysisType = analysis.AnalysisType,
                IsBulk = analysis.IsBulk,
                IsNormalised = analysis.IsNormalised,
                AnalysisDataPoints = analysis.AnalysisDataPoints,
                IsPublic = analysis.IsPublic,
                SpectrumNo = analysis.SpectrumNo
            };
        }

        public void UpdateAnalysis(AnalysisFormViewModel viewModel)
        {
            repository.Update(viewModel);
        }

        public void DeleteAnalysis(int id)
        {
            repository.Delete(id);
        }
    }
}