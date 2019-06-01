using ArchaeoAnalysisHub.Controllers;
using ArchaeoAnalysisHub.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace ArchaeoAnalysisHub.ViewModels
{
    public class ArtifactFormViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public int ArtifactTypeId { get; set; }
        public ArtifactType ArtifactType { get; set; }
        public bool IsPublic { get; set; }
        public string Country { get; set; }
        public string Site { get; set; }
        public string Heading { get; set; }
        public IEnumerable<ArtifactType> ArtifactTypes { get; set; }
        public ApplicationUser Owner { get; set; }
        public string OwnerId { get; set; }
        public IEnumerable<Sample> Samples { get; set; }
        public string Action
        {
            get
            {
                Expression<Func<ArtifactsController, ActionResult>> update =
                    (c => c.Update(this));

                Expression<Func<ArtifactsController, ActionResult>> create =
                    (c => c.Create(this));

                var action = (Id != 0) ? update : create;
                return (action.Body as MethodCallExpression).Method.Name;
            }
        }

    }
}