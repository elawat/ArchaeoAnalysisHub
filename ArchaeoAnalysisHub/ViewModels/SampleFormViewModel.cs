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
        [Required]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Analysed")]
        public bool IsAnalysed { get; set; }
        [Required]
        public int ArtefactId { get; set; }
        public Artefact Artefact { get; set; }
        [Required]
        public int SampleTypeId { get; set; }
        public SampleType SampleType { get; set; }
        public ICollection<Analysis> Analyses { get; set; }
        public ApplicationUser Owner { get; set; }
        public string OwnerId { get; set; }
        [Required]
        public bool IsPublic { get; set; }
        public bool IsDeleted { get; set; }
        public string Heading { get; set; }
        public IEnumerable<Artefact> Artefacts { get; set; }
        public IEnumerable<SampleType> SampleTypes { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public System.DateTime AddedDate { get; set; }
        public bool ShowActionButtons { get; set; }

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