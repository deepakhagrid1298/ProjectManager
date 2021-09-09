using System;

namespace PPM
{
    internal class Project
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public DateTime StartDate { get; set; }
        public long Budget { get; set; }
    }
}