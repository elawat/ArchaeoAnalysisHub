using ArchaeoAnalysisHub.BLL.Interfaces;

namespace ArchaeoAnalysisHub.BLL
{
    public class AnalysesLoader : IAnalysesLoader
    {
        private string _incrementCountSessionVarName = "IncrementCount";

        public AnalysesLoader()
        {

            if (System.Web.HttpContext.Current.Session[_incrementCountSessionVarName] == null)
            {
                System.Web.HttpContext.Current.Session[_incrementCountSessionVarName] = IncrementCount;
            }
            else
            {
                IncrementCount = (int)System.Web.HttpContext.Current.Session[_incrementCountSessionVarName];
            }
        }

        public int IncrementCount { get; private set; } = 1;

        public void Increment()
        {
            IncrementCount = IncrementCount + 1;
            UpdateSession(IncrementCount);
        }

        private void UpdateSession(int incrementCount)
        {
            System.Web.HttpContext.Current.Session[_incrementCountSessionVarName] = incrementCount;
        }
    }
}