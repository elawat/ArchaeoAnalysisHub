using ArchaeoAnalysisHub.Data.Repository.Interfaces;
using ArchaeoAnalysisHub.Models;
using ArchaeoAnalysisHub.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ArchaeoAnalysisHub.Data.Repository
{
    public class AnalysisRepository : IAnalysisRepository
    {
        private ApplicationDbContext context;

        public AnalysisRepository(ApplicationDbContext context)
        {
            this.context = new ApplicationDbContext();
        }

        public List<Analysis> GetAllForHomeView(string query = null)
        {
            var results = context.Analyses
                .Include(a => a.Sample)
                .Include(a => a.Sample.SampleType)
                .Include(a => a.Sample.Artefact)
                .Include(a => a.Sample.Artefact.ArtefactType)
                .Include(a => a.AnalysisType)
                .Include(a => a.AnalysisDataPoints)
                .Include(a => a.GeneralImage)
                .Include(a => a.SpectrumImage)
                .Include(a => a.Owner)
                .Where(a => a.Sample.Artefact.Name == "PB-24a")
                .Take(10)
                .ToList();

            if (!String.IsNullOrWhiteSpace(query))
            {
                results = results
                    .Where(a =>
                    Convert.ToString(a.Id).Equals(query) ||
                    a.Owner.Name.Contains(query) ||
                    a.AnalysisType.Name.Contains(query) ||
                    a.Sample.SampleType.Name.Contains(query) ||
                    a.Sample.Artefact.Name.Contains(query) ||
                    a.Sample.Artefact.Site.Contains(query) ||
                    a.Sample.Artefact.Country.Contains(query) ||
                    a.Sample.Artefact.Name.Contains(query) ||
                    a.Sample.Artefact.Description.Contains(query))
                    .ToList();
            }

            return results;
        }

        public List<Analysis> GetAnalyses(List<int> analysesIds)
        {
            return context.Analyses
                .Include(a => a.Sample)
                .Include(a => a.Sample.SampleType)
                .Include(a => a.Sample.Artefact)
                .Include(a => a.Sample.Artefact.ArtefactType)
                .Include(a => a.AnalysisType)
                .Include(a => a.AnalysisDataPoints)
                .Include(a => a.GeneralImage)
                .Include(a => a.SpectrumImage)
                .Include(a => a.Owner)
                .Where(a => analysesIds.Contains(a.Id))
                .ToList();
        }

        public List<Analysis> GetAll()
        {
            return context.Analyses
                .Include(a => a.Sample)
                .Include(a => a.Sample.SampleType)
                .Include(a => a.Sample.Artefact)
                .Include(a => a.Sample.Artefact.ArtefactType)
                .Include(a => a.AnalysisType)
                .Include(a => a.AnalysisDataPoints)
                .Include(a => a.GeneralImage)
                .Include(a => a.SpectrumImage)
                .Include(a => a.Owner)
                .ToList();
        }

        public Analysis GetAnalysis(int id)
        {
            var analysis = context.Analyses
                .Include(a => a.Sample)
                .Include(a => a.Sample.SampleType)
                .Include(a => a.Sample.Artefact.ArtefactType)
                .Include(a => a.AnalysisType)
                .Include(a => a.Owner)
                .Include(a => a.SpectrumImage)
                .Include(a => a.GeneralImage)
                .Where(a => a.Id == id).FirstOrDefault();

            analysis.AnalysisDataPoints = context.AnalysisDataPoints
                .Where(dp => dp.AnalysisId == id)
                .ToList();

            return analysis;
        }

        public List<Sample> GetSamplesForUser(string userId)
        {
            return context.Samples
                .Include(s => s.Artefact)
                .Where(s => s.OwnerId == userId)
                .ToList();
        }

        public List<Artefact> GetArtefactsForUser(string userId)
        {
            return context.Artefacts
                .Where(s => s.OwnerId == userId)
                .ToList();
        }

        public List<AnalysisType> GetAnalysisTypes()
        {
            return context.AnalysisTypes.ToList();
        }

        public List<string> GetSymbols()
        {
            return context.Symbols
                .Select(dp => dp.Name)
                .ToList();
        }

        public void Update(AnalysisFormViewModel updateAnalysis)
        {
            var analysis = context.Analyses
                .Where(x => x.Id == updateAnalysis.Id)
                .Single();

            analysis.SampleId = updateAnalysis.SampleId;
            analysis.AnalysisTypeId = updateAnalysis.AnalysisTypeId;
            analysis.IsBulk = updateAnalysis.IsBulk;
            analysis.IsNormalised = updateAnalysis.IsNormalised;
            analysis.AnalysisDataPoints = updateAnalysis.AnalysisDataPoints;
            analysis.IsPublic = updateAnalysis.IsPublic;
            analysis.SpectrumNo = updateAnalysis.SpectrumNo;

            context.SaveChanges();
        }

        public void Create(Analysis analysis)
        {
            context.Analyses.Add(analysis);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var analysis = context.Analyses.Where(a => a.Id == id).FirstOrDefault();
            context.Analyses.Remove(analysis);
            context.SaveChanges();
        }

        public AnalysisDataPoint GetDataPoint(int id)
        {
            return context.AnalysisDataPoints
                .Where(dp => dp.Id == id)
                .Include(dp => dp.Analysis)
                .FirstOrDefault();
        }

        public void UpdateDataPoint(AnalysisDataPointFormViewModel updatedDataPoint)
        {
            var dataPoint = context.AnalysisDataPoints
                .Where(dp => dp.Id == updatedDataPoint.Id)
                .FirstOrDefault();

            dataPoint.Symbol = updatedDataPoint.Symbol;
            dataPoint.ResultInPercentage = updatedDataPoint.ResultInPercentage;

            context.SaveChanges();
        }

        public void CreateDataPoint(AnalysisDataPoint dataPoint)
        {
            context.AnalysisDataPoints.Add(dataPoint);
            context.SaveChanges();
        }

        public void DeleteDataPoint(int id)
        {
            var dataPoint = context.AnalysisDataPoints
                .Where(dp => dp.Id == id).FirstOrDefault();
            context.AnalysisDataPoints.Remove(dataPoint);
            context.SaveChanges();
        }
    }
}