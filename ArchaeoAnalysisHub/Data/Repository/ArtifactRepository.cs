using ArchaeoAnalysisHub.Data.Repository.Interfaces;
using ArchaeoAnalysisHub.Models;
using ArchaeoAnalysisHub.ViewModels;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ArchaeoAnalysisHub.Data.Repository
{
    public class ArtefactRepository : IArtefactRepository
    {
        private ApplicationDbContext context;

        public ArtefactRepository()
        {
            this.context = new ApplicationDbContext();
        }

        public Artefact GetArtefact(int id)
        {
            var artefact = context.Artefacts
                .Include(a => a.ArtefactType)
                .Include(a => a.Owner)
                .Where(x => x.Id == id)
                .FirstOrDefault();

            artefact.Samples = context
                .Samples
                .Include(s => s.SampleType)
                .Where(s => s.ArtefactId == id).ToList();

            return artefact;
        }

        public IEnumerable<ArtefactType> GetArtefactTypes()
        {
            return context.ArtefactTypes.ToList();
        }

        public void Update(ArtefactFormViewModel updatedArtefact)
        {
            
            var artefact = context.Artefacts
                .Where(x => x.Id == updatedArtefact.Id)
                .Single();

            artefact.Name = updatedArtefact.Name;
            artefact.Description = updatedArtefact.Description;
            artefact.ArtefactTypeId = updatedArtefact.ArtefactTypeId;
            artefact.Country = updatedArtefact.Country;
            artefact.Site = updatedArtefact.Site;
            artefact.IsPublic = updatedArtefact.IsPublic;

            context.SaveChanges();
        }

        public void Create(Artefact artefact)
        {
            context.Artefacts.Add(artefact);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var artefact = context.Artefacts.Where(a => a.Id == id).FirstOrDefault();
            context.Artefacts.Remove(artefact);
            context.SaveChanges();
        }
    }
}