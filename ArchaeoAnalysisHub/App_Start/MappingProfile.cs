using ArchaeoAnalysisHub.Models;
using ArchaeoAnalysisHub.ViewModels;
using AutoMapper;

namespace ArchaeoAnalysisHub.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Analysis, AnalysisFormViewModel>();
            CreateMap<AnalysisDataPoint, AnalysisDataPointFormViewModel>();
        }
    }
}