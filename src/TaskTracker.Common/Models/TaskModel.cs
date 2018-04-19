using System;

namespace TaskTracker.Common.Models
{
    public class TaskModel
    {
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public string TaskOwnerID { get; set; }
        public string SprintID { get; set; }
        public string FeatureID { get; set; }
        public string ProjectID { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public string LastModifiedBy { get; set; }
        public string CurrentStatus { get; set; }
    }
}