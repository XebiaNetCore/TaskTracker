using System;
using System.ComponentModel.DataAnnotations;

namespace TaskTracker.Common.Models
{
    public class FeatureModel
    {
        public string FeatureName { get; set; }
        public string FeatureDescription { get; set; }
        [Key]
        public Guid FeatureID { get; set; }
        public Guid ProjectID { get; set; }
        public Guid SprintID { get; set; }
        //public string[] Tags { get; set; }
        public int RankID { get; set; }
        public Guid FeatureOwnerID { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public string LastModifiedBy { get; set; }
    }    
}