using System;
using System.Collections.Generic;
using System.Text;

namespace IssueTracker.Data.Models
{
    public class BaseClass
    {
        public User CreatedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public User ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
