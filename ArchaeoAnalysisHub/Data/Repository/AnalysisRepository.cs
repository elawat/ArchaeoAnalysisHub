using ArchaeoAnalysisHub.Data.Repository.Interfaces;
using ArchaeoAnalysisHub.Models;
using ArchaeoAnalysisHub.ViewModels;
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

        public List<Analysis> GetAllForHomeView()
        {
            return context.Analyses
                .Include(a => a.Sample)
                .Include(a => a.Sample.SampleType)
                .Include(a => a.Sample.Artifact)
                .Include(a => a.Sample.Artifact.ArtifactType)
                .Include(a => a.AnalysisType)
                .Include(a => a.AnalysisDataPoints)
                .Include(a => a.GeneralImage)
                .Include(a => a.SpectrumImage)
                .Include(a => a.Owner)
                .Where(a => a.Sample.Artifact.Name == "PB-24a")
                .Take(10)
                .ToList();
        }

        public List<Analysis> GetAll()
        {
            return context.Analyses
                .Include(a => a.Sample)
                .Include(a => a.Sample.SampleType)
                .Include(a => a.Sample.Artifact)
                .Include(a => a.Sample.Artifact.ArtifactType)
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
                .Include(a => a.Sample.Artifact.ArtifactType)
                .Include(a => a.AnalysisType)
                .Include(a => a.Owner)
                .Include(a => a.SpectrumImage)
                .Include(a => a.GeneralImage)
                .Where(a => a.Id == id).FirstOrDefault();

            analysis.AnalysisDataPoints = context.AnalysisDataPoints
                .Where(dp => dp.AnalysisId == id).ToList();

            return analysis;

        }

        public List<Sample> GetSamplesForUser(string userId)
        {
            return context.Samples
                .Include(s => s.Artifact)
                .Where(s => s.OwnerId == userId)
                .ToList();
        }

        public List<Artifact> GetArtifactsForUser(string userId)
        {
            return context.Artifacts
                .Where(s => s.OwnerId == userId)
                .ToList();
        }

        public List<AnalysisType> GetAnalysisTypes()
        {
            return context.AnalysisTypes.ToList();
        }

        public List<string> GetSymbols()
        {
            return context.AnalysisDataPoints
                .Select(dp => dp.Symbol)
                .Distinct()
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
            analysis.IsDeleted = true;
            context.SaveChanges();
        }
    }
}