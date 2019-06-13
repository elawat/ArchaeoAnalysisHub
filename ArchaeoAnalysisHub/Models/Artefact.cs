using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArchaeoAnalysisHub.Models
{
    public class Artefact
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Artefact name")]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public int ArtefactTypeId { get; set; }
        public ArtefactType ArtefactType { get; set; }
        public ApplicationUser Owner { get; set; }
        [Required]
        public string OwnerId { get; set; }
        public bool IsPublic { get; set; }
        public string Country { get; set; }
        public string Site { get; set; }
        public IEnumerable<Sample> Samples { get; set; }
        [Column(TypeName = "DateTime2")]
        public DateTime AddedDate { get; set; }
        public string Period { get; set; }
    }
}