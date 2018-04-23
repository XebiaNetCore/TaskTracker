using System;

namespace TaskTracker.Common.Models
{
    public class SprintModel
    {
        public Guid SprintID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
  	    public DateTime CreatedDate { get; set; }
  	    public Guid CreatedBy { get; set; }
  	    public DateTime LastModifiedDate { get; set; }
  	    public Guid LastModifiedBy { get; set; }
    }
}