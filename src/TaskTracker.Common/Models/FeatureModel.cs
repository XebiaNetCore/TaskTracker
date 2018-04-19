using System;

namespace TaskTracker.Common.Models
{
    public class FeatureModel
    {
        public string FeatureName { get; set; }
        public string FeatureDescription { get; set; }
        public string ProjectID { get; set; }
        public string SprintID { get; set; }
        // public string Tags[] { get; set; }
        // public string RankID { get; set; }
        public string FeatureOwnerID { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public string LastModifiedBy { get; set; }
    }    
}