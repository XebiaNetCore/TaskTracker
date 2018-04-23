using System;

namespace TaskTracker.Common.Models
{
    public class TaskModel
    {
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public Guid TaskOwnerID { get; set; }
        public Guid SprintID { get; set; }
        public Guid FeatureID { get; set; }
        public Guid ProjectID { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public Guid LastModifiedBy { get; set; }
        public string CurrentStatus { get; set; }
    }
}