using System;
using System.Collections.Generic;
using System.Text;

namespace PPM.Model.Common
{
    public class ActionResult
    {
        public bool IsSuccess { get; set; }
        public string Status { get; set; }
    }
    public class DataResult<T> : ActionResult
    {
        public IEnumerable<T> results;
    }
}
