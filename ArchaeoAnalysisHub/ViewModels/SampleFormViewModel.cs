using ArchaeoAnalysisHub.Controllers;
using ArchaeoAnalysisHub.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace ArchaeoAnalysisHub.ViewModels
{
    public class SampleFormViewModel
    {
        public int Id { get; set; }
        public bool IsAnalysed { get; set; }
        public int ArtifactId { get; set; }
        public Artifact Artifact { get; set; }
        [Required]
        public int SampleTypeId { get; set; }
        public SampleType SampleType { get; set; }
        public ICollection<Analysis> Analyses { get; set; }
        public ApplicationUser Owner { get; set; }
        [Required]
        public string OwnerId { get; set; }
        public bool IsPublic { get; set; }
        public bool IsDeleted { get; set; }
        public string Heading { get; set; }
        public IEnumerable<Artifact> Artifacts { get; set; }
        public IEnumerable<SampleType> SampleTypes { get; set; }

        public string Action
        {
            get
            {
                Expression<Func<SamplesController, ActionResult>> update =
                    (c => c.Update(this));

                Expression<Func<SamplesController, ActionResult>> create =
                    (c => c.Create(this));

                var action = (Id != 0) ? update : create;
                return (action.Body as MethodCallExpression).Method.Name;
            }
        }
    }
}