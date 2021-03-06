﻿using System.ComponentModel.DataAnnotations;

namespace ArchaeoAnalysisHub.Models
{
    public class ArtefactType
    {
        public int Id { get; set; }
        [Display(Name = "Artefact type")]
        public string Name { get; set; }
    }
}