using System;

namespace TaskTracker.Common.Models
{
    public class SprintModel
    {
        public string SprintID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
  	    public DateTime CreatedDate { get; set; }
  	    public string CreatedBy { get; set; }
  	    public DateTime LastModifiedDate { get; set; }
  	    public string LastModifiedBy { get; set; }
    }
}