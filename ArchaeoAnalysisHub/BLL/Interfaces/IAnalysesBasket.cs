using ArchaeoAnalysisHub.Models;

namespace ArchaeoAnalysisHub.BLL.Interfaces
{
    public interface IAnalysesBasket
    {
        void Add(Analysis analysis);
        void Remove(int analysisId);
    }
}
