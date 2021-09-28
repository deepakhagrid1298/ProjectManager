using System;
using System.Collections.Generic;
using System.Linq;
using PPM.Model;
using PPM.Model.Common;

namespace PPM.Domain
{
    public class EmployeeManager
    {
        private static List<Employee> emplist = new List<Employee>();
        public ActionResult AddEmployee(Employee emp1)
        {
            ActionResult result = new ActionResult() { IsSuccess = true };
            try
            {
                if (emplist.Count > 0)
                {
                    if (emplist.Exists(em => em.EmpId == emp1.EmpId))
                    {
                        result.IsSuccess = false;
                        result.Status = "ID Already Exists " + emp1.EmpId;
                    }
                    else
                    {
                        emplist.Add(emp1);
                        result.Status = "Employee Added";
                    }
                }
                else
                {
                    emplist.Add(emp1);
                    result.Status = "Employee Added Successfully";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("error occured" + ex.ToString());
                result.IsSuccess = false;
            }
            return result;

        }
        public DataResult<Employee> GetEmployee()
        {
            DataResult<Employee> employeeResult = new DataResult<Employee>() { IsSuccess = true };
            if (emplist.Count > 0)
            {
                employeeResult.results = emplist;
            }
            else
            {
                employeeResult.IsSuccess = false;
                employeeResult.Status = "No Employee in the list";
            }
            return employeeResult;
        }
        public ActionResult IsValidEmp(Employee employee)
        {
            ActionResult actionResult = new ActionResult() { IsSuccess = true };
            try
            {
                if (emplist.Exists(e => e.EmpId == employee.EmpId))
                {
                    actionResult.Status = "Validation Successful!";
                }
                else
                {
                    actionResult.IsSuccess = false;
                    actionResult.Status = "ID is not in the Employee List " + employee.EmpId;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("error occured" + e.ToString());
                actionResult.IsSuccess = false;
            }
            return actionResult;
        }

        public Employee GetEmployeeByRole(Employee employeeId)
        {
            Employee emp = new Employee();
            emp.FirstName = emplist.Single(e => e.EmpId == employeeId.EmpId).FirstName;
            emp.LastName = emplist.Single(e => e.EmpId == employeeId.EmpId).LastName;
            return emp;
        }
    }
}