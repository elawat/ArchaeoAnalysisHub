using ArchaeoAnalysisHub.Models;
using System.Collections.Generic;

namespace ArchaeoAnalysisHub.BLL.Interfaces
{
    public interface IAnalysesNormalizer
    {
        Analysis GetNormalisedDataPointsForSelectedSymbols
            (List<string> symbols, Analysis analysis);
        List<AnalysisDataPoint> NormaliseTotal(List<AnalysisDataPoint> dataPoints);

    }
}
