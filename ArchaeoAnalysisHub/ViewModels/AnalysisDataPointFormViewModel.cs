using ArchaeoAnalysisHub.Controllers;
using ArchaeoAnalysisHub.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace ArchaeoAnalysisHub.ViewModels
{
    public class AnalysisDataPointFormViewModel
    {
        public int Id { get; set; }
        public string Symbol { get; set; }
        [Display(Name = "Amount (%)")]
        public double ResultInPercentage { get; set; }
        public string Heading { get; set; }
        public ICollection<string> Symbols;
        public int AnalysisId { get; set; }
        public Analysis Analysis { get; set; }

        public string Action
        {
            get
            {
                Expression<Func<AnalysisDataPointsController, ActionResult>> update =
                    (c => c.Update(this));

                Expression<Func<AnalysisDataPointsController, ActionResult>> create =
                    (c => c.Create(this));

                var action = (Id != 0) ? update : create;
                return (action.Body as MethodCallExpression).Method.Name;
            }
        }

    }
}