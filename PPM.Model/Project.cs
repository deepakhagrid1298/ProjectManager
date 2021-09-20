using System;
using System.Collections.Generic;
using System.Text;

namespace PPM.Model
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public DateTime StartDate { get; set; }
        public long Budget { get; set; }
        public List<Employee> ProEmplist;
    }
}
