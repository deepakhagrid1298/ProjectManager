﻿using System;
using System.Collections.Generic;
using System.Linq;
using PPM.Model;
using PPM.Model.Common;

namespace PPM.Domain
{
    public class EmployeeManager
    {
        private static List<Employee> emplist = new List<Employee>();
        //public EmployeeManager()
        //{
        //    _employeeList = new List<Employee>();
        //}
        public ActionResult AddEmployee(Employee emp)
        {
            ActionResult result = new ActionResult() { IsSuccess = true };
            try
            {
                if (emplist.Count > 0)
                {
                    if (emplist.Exists(em => em.EmpId == emp.EmpId))
                    {
                        result.IsSuccess = false;
                        result.Status = "ID Already Exists " + emp.EmpId;
                    }
                    else
                    {
                        emplist.Add(emp);
                        result.Status = "Employee Added";
                    }
                }
                else
                {
                    emplist.Add(emp);
                    result.Status = "New Employee Added";
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
    }
}