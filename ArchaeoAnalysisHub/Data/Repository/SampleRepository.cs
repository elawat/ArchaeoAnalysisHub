﻿using ArchaeoAnalysisHub.Data.Repository.Interfaces;
using ArchaeoAnalysisHub.Models;
using ArchaeoAnalysisHub.ViewModels;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ArchaeoAnalysisHub.Data.Repository
{
    public class SampleRepository : ISampleRepository
    {
        private ApplicationDbContext context;

        public SampleRepository()
        {
            this.context = new ApplicationDbContext();
        }

        public Sample GetSample(int id)
        {
            var sample = context.Samples
                .Include(s => s.Owner)
                .Include(s => s.SampleType)
                .Include(s => s.Artefact)
                .Where(x => x.Id == id).FirstOrDefault();

            sample.Analyses = context.Analyses
                .Include(a => a.AnalysisType)
                .Include(a => a.Owner)
                .Where(a => a.SampleId == id).ToList();

            sample.Artefacts = context.Artefacts
                .Where(a => a.OwnerId == sample.OwnerId).ToList();

            sample.SampleTypes = context.SampleTypes.ToList();

            return sample;
        }

        public IEnumerable<SampleType> GetSampleTypes()
        {
            return context.SampleTypes.ToList();
        }

        public IEnumerable<Artefact> GetArtefactsForUser(string userId)
        {
            return context.Artefacts
                .Where(a => a.OwnerId == userId)
                .ToList();
        }

        public void Update(SampleFormViewModel updatedSample)
        {

            var sample = context.Samples
                .Where(x => x.Id == updatedSample.Id)
                .Single();

            sample.Name = updatedSample.Name;
            sample.IsAnalysed = updatedSample.IsAnalysed;
            sample.ArtefactId = updatedSample.ArtefactId;
            sample.SampleTypeId = updatedSample.SampleTypeId;
            sample.IsPublic = updatedSample.IsPublic;

            context.SaveChanges();
        }

        public void Create(Sample sample)
        {
            context.Samples.Add(sample);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var sample = context.Samples.Where(a => a.Id == id).FirstOrDefault();
            context.Samples.Remove(sample);
            context.SaveChanges();
        }
    }
}