using ArchaeoAnalysisHub.Data.Repository.Interfaces;
using ArchaeoAnalysisHub.Models;
using ArchaeoAnalysisHub.ViewModels;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ArchaeoAnalysisHub.Data.Repository
{
    public class ArtifactRepository : IArtifactRepository
    {
        private ApplicationDbContext context;

        public ArtifactRepository()
        {
            this.context = new ApplicationDbContext();
        }

        public Artifact GetArtifact(int id)
        {
            var artifact = context.Artifacts
                .Include(a => a.ArtifactType)
                .Include(a => a.Owner)
                .Where(x => x.Id == id)
                .FirstOrDefault();

            artifact.Samples = context
                .Samples
                .Include(s => s.SampleType)
                .Where(s => s.ArtifactId == id).ToList();

            return artifact;
        }

        public IEnumerable<ArtifactType> GetArtifactTypes()
        {
            return context.ArtifactTypes.ToList();
        }

        public void Update(ArtifactFormViewModel updatedArtifact)
        {
            
            var artifact = context.Artifacts
                .Where(x => x.Id == updatedArtifact.Id)
                .Single();

            artifact.Name = updatedArtifact.Name;
            artifact.Description = updatedArtifact.Description;
            artifact.ArtifactTypeId = updatedArtifact.ArtifactTypeId;
            artifact.Country = updatedArtifact.Country;
            artifact.Site = updatedArtifact.Site;
            artifact.IsPublic = updatedArtifact.IsPublic;

            context.SaveChanges();
        }

        public void Create(Artifact artifact)
        {
            context.Artifacts.Add(artifact);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var artifact = context.Artifacts.Where(a => a.Id == id).FirstOrDefault();
            context.Artifacts.Remove(artifact);
            context.SaveChanges();
        }
    }
}