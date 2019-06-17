using ArchaeoAnalysisHub.BLL.Interfaces;
using ArchaeoAnalysisHub.Models;
using System.Collections.Generic;

namespace ArchaeoAnalysisHub.BLL
{
    public class AnalysesBasket : IAnalysesBasket
    {
        public List<Analysis> Analyses { get; set; } = new List<Analysis>();

        public void Add(Analysis analysis)
        {
            int index = Analyses.FindIndex(a => a.Id == analysis.Id);
            if (index < 0)
            {
                Analyses.Add(analysis);
            }
            else
            {
                throw new System.InvalidOperationException("Already selected for plotting.");
            }
                
        }

        public void Remove(int analysisId)
        {
            int index = Analyses.FindIndex(a => a.Id == analysisId);
            if (index > -1)
            {
                Analyses.RemoveAt(index);
            }
            else
            {
                throw new System.InvalidOperationException("Already removed.");
            }
        }

    }
}