using ArchaeoAnalysisHub.BLL.Interfaces;
using ArchaeoAnalysisHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ArchaeoAnalysisHub.BLL
{
    public class AnalysesNormalizer : IAnalysesNormalizer
    {
        public Analysis GetNormalisedDataPointsForSelectedSymbols
            (List<string> symbols, Analysis analysis)
        {
            var dataPoints = new List<AnalysisDataPoint>();
            foreach (var dp in analysis.AnalysisDataPoints
                .Where(dp => symbols.Contains(dp.Symbol)).ToList())
            {
                dataPoints.Add(
                    new AnalysisDataPoint()
                    {
                        Id = dp.Id,
                        AnalysisId = dp.AnalysisId,
                        Analysis = dp.Analysis,
                        ResultInPercentage = dp.ResultInPercentage,
                        Symbol = dp.Symbol
                    }
                 );
            }

            if (dataPoints.Count != 0)
            {
                var total = dataPoints.Sum(dp => dp.ResultInPercentage);

                foreach (var dp in dataPoints)
                {
                    dp.ResultInPercentage = Math.Round(dp.ResultInPercentage / total * 100, 2);
                }

                dataPoints = NormaliseTotal(dataPoints);
            }
            
            return new Analysis()
            {
                AnalysisDataPoints = dataPoints,
                Id = analysis.Id,
            };
        }

        public List<AnalysisDataPoint> NormaliseTotal(List<AnalysisDataPoint> dataPoints)
        {
            var total = dataPoints.Select(dp => dp.ResultInPercentage).Sum();

            if (total != 100)
            {
                var diff = 100 - total;
                var max = dataPoints.Select(dp => dp.ResultInPercentage).Max();
                var dpMax = dataPoints.Where(dp => dp.ResultInPercentage == max).FirstOrDefault();
                dpMax.ResultInPercentage = max - diff;
            }
            return dataPoints;
        }
    }
}