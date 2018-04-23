using System;
using System.ComponentModel.DataAnnotations;

namespace TaskTracker.Common.Models
{
    public class ProjectModel
    {
        [Key]
        public Guid ProjectID { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public Guid LastModifiedBy { get; set; }
    }
}