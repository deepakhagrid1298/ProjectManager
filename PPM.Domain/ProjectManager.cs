using PPM.Model;
using PPM.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPM.Domain
{
    public class ProjectManager
    {
        private static List<Project> prolist = new List<Project>();
        //public ProjectManager()
        //{
        //    _projectList = new List<Project>();
        //}

        public ActionResult AddProject(Project pro)
        {
            ActionResult result = new ActionResult() { IsSuccess = true };
            try
            {
                if (prolist.Count > 0)
                {
                    if (prolist.Exists(proj => proj.ProjectId == pro.ProjectId))
                    {
                        result.IsSuccess = false;
                        result.Status = "Validation Failed";
                    }
                    else
                    {
                        prolist.Add(pro);
                        result.Status = "project Added";
                    }
                }
                else
                {
                    prolist.Add(pro);
                    result.Status = "New Project Added";
                }
            }
            catch (Exception e)
            {
                result.IsSuccess = false;
                result.Status = "Exception Occured : " + e.ToString();
            }
            return result;
        }

        public DataResult<Project> GetProject()
        {
            DataResult<Project> projResult = new DataResult<Project>() { IsSuccess = true };
            if (prolist.Count > 0)
            {
                projResult.results = prolist;
            }
            else
            {
                projResult.IsSuccess = false;
                projResult.Status = "No Projects in list";
            }
            return projResult;
        }

    }
}