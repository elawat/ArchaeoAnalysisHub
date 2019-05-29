using ArchaeoAnalysisHub.Models;
using System.Collections.Generic;

namespace ArchaeoAnalysisHub.Data.Repository.Interfaces
{
    public interface ISampleRepository
    {
        void Add(Sample sample);
        List<Sample> GetAll();
    }
}
