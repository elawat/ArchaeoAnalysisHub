using ArchaeoAnalysisHub.Models;
using System.Data.Entity;

namespace ArchaeoAnalysisHub.Data
{
    public interface IApplicationDbContext
    {
        DbSet<Sample> Samples { get; set; }
        DbSet<SampleType> SampleTypes { get; set; }
        DbSet<Artifact> Artifacts { get; set; }
        DbSet<ArtifactType> ArtifactTypes { get; set; }
        DbSet<Analysis> Analyses { get; set; }
        DbSet<AnalysisType> AnalysisTypes { get; set; }
        DbSet<AnalysisDataPoint> AnalysisDataPoints { get; set; }
    }
}
