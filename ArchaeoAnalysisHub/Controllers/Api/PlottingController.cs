using ArchaeoAnalysisHub.BLL;
using ArchaeoAnalysisHub.Data.Repository;
using ArchaeoAnalysisHub.Dtos;
using ArchaeoAnalysisHub.Models;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace ArchaeoAnalysisHub.Controllers.Api
{
    public class PlottingController : ApiController
    {
        private AnalysesBasket analysesBasket;
        private AnalysesService analysesService;
        private string sessionVariable = "analysesBasket";

        public PlottingController()
        {
            this.analysesService = new AnalysesService(new AnalysisRepository(new Data.ApplicationDbContext()));
            this.analysesBasket = new AnalysesBasket();
            if (System.Web.HttpContext.Current.Session[sessionVariable] == null)
            {
                System.Web.HttpContext.Current.Session[sessionVariable] = analysesBasket.Analyses;
            }
            else
            {
                this.analysesBasket.Analyses = (List<Analysis>)System.Web.HttpContext.Current.Session[sessionVariable];
            }
        }

        [HttpPost]
        public IHttpActionResult Plot(PlottingDto dto)
        {
            var analysis = analysesService.GetAnalysis(dto.AnalysisId);
            if (analysis != null)
            {
                try
                {
                    this.analysesBasket.Add(analysis);
                    return Ok();
                }
                catch (InvalidOperationException e)
                {
                    return BadRequest(e.Message);
                }
            } 
            else
            {
                return BadRequest("Analysis not found");
            }
        }

        [HttpPost]
        public IHttpActionResult Unplot(PlottingDto dto)
        {
            var analysis = analysesService.GetAnalysis(dto.AnalysisId);
            if (analysis != null)
            {
                try
                {
                    this.analysesBasket.Remove(analysis.Id);
                    return Ok();
                }
                catch (InvalidOperationException e)
                {
                    return BadRequest(e.Message);
                }
            }
            else
            {
                return BadRequest("Analysis not found");
            }
        }

        public IEnumerable<PlottingDto> GetAnalysesToPlot()
        {
            List<PlottingDto> dto = new List<PlottingDto>();

            foreach (var analysis in this.analysesBasket.Analyses)
            {
                dto.Add(new PlottingDto()
                {
                    AnalysisId = analysis.Id
                });
            }

            return dto;

        }
    }
}
