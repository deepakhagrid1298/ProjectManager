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
        public static List<Project> prolist = new List<Project>();
        
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
        public Project GetProjectByID(int id)
        {
            Project project = new Project();
            project.ProEmplist = prolist.Single(p => p.ProjectId == id).ProEmplist;
            return project;
        }

        public ActionResult AddEmpToProject(Employee employee, int id)
        {
            ActionResult result = new ActionResult() { IsSuccess = true };

            try
            {
                if (prolist.Count > 0)
                {
                    if (prolist.Exists(p => p.ProjectId == id))
                    {
                        if (prolist.Single(p => p.ProjectId == id).ProEmplist == null)
                        {
                           prolist.Single(p => p.ProjectId == id).ProEmplist = new List<Employee>();
                        }

                        if (prolist.Single(p => p.ProjectId == id).ProEmplist.Exists(e => e.EmpId == employee.EmpId))
                        {
                            result.Status = $"Employee Id : {employee.EmpId} already exists in this project: {id}";
                        }
                        else
                        {
                            prolist.Single(p => p.ProjectId == id).ProEmplist.Add(employee);
                            result.Status = "Employee is Added to project";

                        }

                    }
                    else
                    {
                        result.IsSuccess = false;
                        result.Status = "Project Id not found!" + id;
                    }
                }
                else
                {
                    result.IsSuccess = false;
                    result.Status = "Project list is Empty!";
                }

            }
            catch (Exception e)
            {
                result.IsSuccess = false;
                result.Status = "Exception Occured : " + e.ToString();
            }
            return result;

        }

        public ActionResult DeleteEmpFromProject(int id, Employee employee)
        {
            Project project = new Project();
            ActionResult action = new ActionResult() { IsSuccess = true };
            try
            {
                if (prolist.Exists(p => p.ProjectId == id))
                {
                    if (prolist.Single(s => s.ProjectId == id).ProEmplist.Exists(n => n.EmpId == employee.EmpId))
                    {
                        var itemToRemove = prolist.Single(s => s.ProjectId == id).ProEmplist.Single(e => e.EmpId == employee.EmpId);
                        prolist.Single(s => s.ProjectId == id).ProEmplist.Remove(itemToRemove);
                        action.Status = "Employee is Deleted Successfully " + employee.EmpId;
                    }
                    else
                    {
                        action.IsSuccess = false;
                        action.Status = "Given Employee ID is not Present in the particular Project " + employee.EmpId;
                    }
                }
                else
                {
                    action.IsSuccess = false;
                    action.Status = "Project Id is not in the List!" + id;
                }
            }
            catch (Exception e)
            {
                action.IsSuccess = false;
                action.Status = "Exception Occured : " + e.ToString();
            }
            return action;
        }

    }
}