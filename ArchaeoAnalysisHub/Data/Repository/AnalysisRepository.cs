using ArchaeoAnalysisHub.Data.Repository.Interfaces;
using ArchaeoAnalysisHub.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ArchaeoAnalysisHub.Data.Repository
{
    public class AnalysisRepository : IAnalysisRepository
    {
        private IApplicationDbContext context;

        public AnalysisRepository(ApplicationDbContext context)
        {
            this.context = context;
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
                .Where(a => a.Sample.Artifact.Name == "PB-24a")
                .Take(10)
                .ToList();
        }
    }
}