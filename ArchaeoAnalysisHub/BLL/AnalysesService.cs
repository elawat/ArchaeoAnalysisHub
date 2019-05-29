using ArchaeoAnalysisHub.BLL.Interfaces;
using ArchaeoAnalysisHub.Data.Repository.Interfaces;
using ArchaeoAnalysisHub.Models;
using ArchaeoAnalysisHub.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ArchaeoAnalysisHub.BLL
{
    public class AnalysesService : IAnalysesHandler
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
            var query = from analysis in analyses
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
    }
}