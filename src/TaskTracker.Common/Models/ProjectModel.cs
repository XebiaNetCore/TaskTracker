using System;
using System.ComponentModel.DataAnnotations;

namespace TaskTracker.Common.Models
{
    public class ProjectModel
    {
        [Key]
        public string ProjectID { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public string LastModifiedBy { get; set; }
    }
}