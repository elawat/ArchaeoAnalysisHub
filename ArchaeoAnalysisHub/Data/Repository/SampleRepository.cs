using ArchaeoAnalysisHub.Data.Repository.Interfaces;
using ArchaeoAnalysisHub.Models;
using System.Collections.Generic;

namespace ArchaeoAnalysisHub.Data.Repository
{
    public class SampleRepository : ISampleRepository
    {
        private List<Sample> samples = new List<Sample>();

        public SampleRepository()
        {
            //Add(new Sample() { IsAnalysed = true });
            //Add(new Sample() { IsAnalysed = true });
            //Add(new Sample() { IsAnalysed = false });
        }

        public void Add(Sample sample)
        {
            samples.Add(sample);
        }

        public List<Sample> GetAll()
        {
            return samples;
        }
    }
}