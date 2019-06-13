using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArchaeoAnalysisHub.Models
{
    public class Sample
    {
        [Key]
        [Display(Name ="Sample id")]
        public int Id { get; set; }
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
        [Required]
        public string OwnerId { get; set; }
        public bool IsPublic { get; set; }
        public IEnumerable<Artefact> Artefacts { get; set; }
        public IEnumerable<SampleType> SampleTypes { get; set; }
        [Column(TypeName = "DateTime2")]
        public DateTime AddedDate { get; set; }
    }
}