namespace ArchaeoAnalysisHub.Data
{
    using ArchaeoAnalysisHub.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
    {
        public DbSet<Sample> Samples { get; set; }
        public DbSet<SampleType> SampleTypes { get; set; }
        public DbSet<Artefact> Artifacts { get; set; }
        public DbSet<ArtefactType> ArtifactTypes { get; set; }
        public DbSet<Analysis> Analyses { get; set; }
        public DbSet<AnalysisType> AnalysisTypes { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<AnalysisDataPoint> AnalysisDataPoints { get; set; }

        public ApplicationDbContext()
            : base("LocalConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

    }
}