using ArchaeoAnalysisHub.Models;
using System.Collections.Generic;

namespace ArchaeoAnalysisHub.Data.Repository.Interfaces
{
    public interface IAnalysisRepository
    {
        List<Analysis> GetAll();
    }
}
