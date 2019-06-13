using ArchaeoAnalysisHub.Controllers;
using ArchaeoAnalysisHub.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace ArchaeoAnalysisHub.ViewModels
{
    public class ArtefactFormViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int ArtefactTypeId { get; set; }
        public ArtefactType ArtefactType { get; set; }
        [Required]
        public bool IsPublic { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string Site { get; set; }
        public string Heading { get; set; }
        public IEnumerable<ArtefactType> ArtefactTypes { get; set; }
        public ApplicationUser Owner { get; set; }
        public string OwnerId { get; set; }
        public IEnumerable<Sample> Samples { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public System.DateTime AddedDate { get; set; }
        [Required]
        public string Period { get; set; }
        public string Action
        {
            get
            {
                Expression<Func<ArtefactsController, ActionResult>> update =
                    (c => c.Update(this));

                Expression<Func<ArtefactsController, ActionResult>> create =
                    (c => c.Create(this));

                var action = (Id != 0) ? update : create;
                return (action.Body as MethodCallExpression).Method.Name;
            }
        }

    }
}