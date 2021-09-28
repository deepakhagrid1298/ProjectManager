using NUnit.Framework;
using PPM.Domain;
using PPM.Model;
using PPM.Model.Common;
using System;

namespace PPM.Test
{
    public class Tests
    {
        [Test]
        public void AddProject_Test()
        {
            ProjectManager pm = new ProjectManager();
            Project p1 = new Project();
            
            p1.ProjectId = 1;
            p1.ProjectName = "Deepak";
            p1.StartDate = Convert.ToDateTime("09-08-2020");
            p1.Budget = 4000;
            var result = pm.AddProject(p1);
            if(result.IsSuccess)
            {
                Assert.Pass();
            }
         else
            {
                Assert.Fail();
            }
            
        }
        [Test]
        public void AddEmployee_Test()
        {
            EmployeeManager em = new EmployeeManager();
            Employee e1 = new Employee();

            e1.EmpId = 1;
            e1.FirstName = "Deepak";
            e1.LastName = "Poddar";
            e1.Email = "dk@gmail.com";
            var result1 = em.AddEmployee(e1);
            if (result1.IsSuccess)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }

        }
        [Test]
        public void AddRole_Test()
        {
            RoleManager rm = new RoleManager();
            Role r1 = new Role();

            r1.RoleId = 1;
            r1.RoleName = "Student";
            var result2 = rm.AddRole(r1);
            if (result2.IsSuccess)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }

        }
        [Test]
        public void AddEmptoProjectTest1()
        {

            ProjectManager proj = new ProjectManager();
            Employee emp = new Employee();
            Project P2 = new Project();
            P2.ProjectId = 1;
            emp.EmpId = 1;
            var result = proj.AddEmpToProject(emp, P2.ProjectId);
            if (!result.IsSuccess)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }
        [Test]
        public void DeleteEmpFromProjectTest2()
        {
            ProjectManager proj = new ProjectManager();
            Employee emp = new Employee();
            Project P2 = new Project();
            P2.ProjectId = 1;
            emp.EmpId = 1;
            var result = proj.DeleteEmpFromProject(P2.ProjectId,emp);
            if (!result.IsSuccess)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }
    }
}