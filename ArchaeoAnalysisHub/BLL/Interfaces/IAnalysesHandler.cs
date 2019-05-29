using ArchaeoAnalysisHub.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchaeoAnalysisHub.BLL.Interfaces
{
    public interface IAnalysesHandler
    {
        List<AnalysisSummary> GetSummary();
    }
}
