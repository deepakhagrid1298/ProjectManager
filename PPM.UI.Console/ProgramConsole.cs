using PPM.Domain;
using PPM.Model;
using System;

namespace PPM.UI.Cons
{
    public class ProgramConsole
    {
        public void SubjectMenu()
        {
            ProjectManager m1 = new ProjectManager();
            EmployeeManager m2 = new EmployeeManager();
            RoleManager m3 = new RoleManager();
            Console.WriteLine("My Menu:-");
            Console.WriteLine("1:- Add Project");
            Console.WriteLine("2:- View Projects");
            Console.WriteLine("3:- Add Employee");
            Console.WriteLine("4:- View Employees");
            Console.WriteLine("5:- Add Role");
            Console.WriteLine("6:- View Roles");
            Console.WriteLine("7:- Add Employee to project");
            Console.WriteLine("8:- Delete Employee from project");
            Console.WriteLine("9:- View project Detail");
            Console.WriteLine("10:- Quit");
            bool i = true;
            while (i)
            {
                Console.Write("select from 1 to 10 ");
                Console.WriteLine("");
                int num = int.Parse(Console.ReadLine());
                switch (num)
                {

                    case 1:
                        AddProject();
                        break;
                    case 2:
                        var d1 = m1.GetProject();
                        int c = 0;
                        foreach (Project p in d1.results)
                        {
                            Console.WriteLine("Project " + c);
                            Console.WriteLine("project Id:" + p.ProjectId);
                            Console.WriteLine("project Name:" + p.ProjectName);
                            Console.WriteLine("project Start Date:" + p.StartDate);
                            Console.WriteLine("project Budget:" + p.Budget);
                            c++;
                        }
                        break;
                    case 3:
                        AddEmployee();
                        break;
                    case 4:
                        int j = 0;
                        var d2 = m2.GetEmployee();
                        foreach (Employee item in d2.results)
                        {
                            Console.WriteLine("Employee no " + i);
                            Console.WriteLine("Employee id:" + item.EmpId);
                            Console.WriteLine("Employee FirstName:" + item.FirstName);
                            Console.WriteLine("Employee Lastname:" + item.LastName);
                            Console.WriteLine("Employee Email:" + item.Email);
                            j++;
                        }
                        break;
                    case 5:
                        AddRole();
                        break;
                    case 6:
                        int count = 0;
                        var d3 = m3.GetRole();
                        foreach (Role r in d3.results)
                        {
                            Console.WriteLine("Role no " + count);
                            Console.WriteLine("Role id:" + r.RoleId);
                            Console.WriteLine("Role Name:" + r.RoleName);

                            count++;
                        }
                        break;
                    case 7:
                        AddEmpToProject();
                        break;
                    case 8:
                        RemoveEmpFromProject();
                        break;
                    case 9:
                        Console.WriteLine("Project Details with Employee Assigned:-");
                        var resultPro = m1.GetProject();
                        if (resultPro.IsSuccess)
                        {
                            foreach (Project result in resultPro.results)
                            {
                                Console.WriteLine("Project ID: " + result.ProjectId + "\nProject Name: " + result.ProjectName + "\nStarting Date: " + result.StartDate + "\nBudget: " + result.Budget);
                                Console.WriteLine("Employee Assigned: ");
                                if (result.ProEmplist != null)
                                {
                                    foreach (Employee e in result.ProEmplist)
                                    {
                                        Console.WriteLine("Employee Id: " + e.EmpId + " " + "Employee First Name: " + e.FirstName);
                                    }
                                }

                            }
                        }
                        else
                        {
                            Console.WriteLine(resultPro.Status);
                        }
                        break;
                    case 10:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid Option");
                        break;
                }
            }
        }

        private void AddEmployee()
        {
            Employee employee = new Employee();
            try
            {
                Console.Write("Enter Employee Id: ");
                employee.EmpId = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter Employee FirstName: ");
                employee.FirstName = Console.ReadLine();
                Console.Write("Enter Employee LastName: ");
                employee.LastName = Console.ReadLine();
                Console.Write("Enter Employee Email ");
                employee.Email = Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error Occoured!" + e.ToString());
                ProgramConsole pc = new ProgramConsole();
                pc.SubjectMenu();
            }
            EmployeeManager employeeManager = new EmployeeManager();
            var resultEmployee = employeeManager.AddEmployee(employee);
            if (!resultEmployee.IsSuccess)
            {
                Console.WriteLine("Employee failed to Add");
                Console.WriteLine(resultEmployee.Status);
            }
            else
            {
                Console.WriteLine(resultEmployee.Status);
            }
            

        }

        private void AddRole()
        {
            Role role = new Role();
            try
            {
                Console.Write("Enter Role Id: ");
                role.RoleId = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter Role Name: ");
                role.RoleName = Console.ReadLine().ToUpper();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error Occoured!" + e.ToString());
                ProgramConsole pc = new ProgramConsole();
                pc.SubjectMenu();
            }


            RoleManager roleManager = new RoleManager();
            var resultRole = roleManager.AddRole(role);
            if (!resultRole.IsSuccess)
            {
                Console.WriteLine("Role Failed to Add");
                Console.WriteLine(resultRole.Status);
            }
            else
            {
                Console.WriteLine(resultRole.Status);
            }
            
        }

        private static void AddProject()
        {
            Project project = new Project();
            try
            {
                Console.Write("Enter Project ID: ");
                project.ProjectId = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter Project Name: ");
                project.ProjectName = Console.ReadLine().ToUpper();
                Console.Write("Enter Project Start Date");
                project.StartDate = Convert.ToDateTime(Console.ReadLine());
                Console.Write("Enter Project Budget: ");
                project.Budget = Convert.ToInt64(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine("Error Occoured!" + e.ToString());
                ProgramConsole pc = new ProgramConsole();
                pc.SubjectMenu();
            }

            ProjectManager projectManager = new ProjectManager();
            var resultProject = projectManager.AddProject(project);
            if (!resultProject.IsSuccess)
            {
                Console.WriteLine("Project failed to Add");
                Console.WriteLine(resultProject.Status);
            }
            else
            {
                Console.WriteLine(resultProject.Status);
            }
            
        }

        private static void AddEmpToProject()
        {
            ProjectManager projectManager = new ProjectManager();
            EmployeeManager employeeManager = new EmployeeManager();
            Employee employee = new Employee();
            Console.WriteLine("Choose Project From Below Project List:");
                Console.WriteLine("PROJECT ID: PROJECT NAME");
            var resPro = projectManager.GetProject();
            if (resPro.IsSuccess)
            {
                foreach (Project result in resPro.results)
                {
                    Console.WriteLine(result.ProjectId + " : " + result.ProjectName);
                }
            }
            else
            {
                Console.WriteLine(resPro.Status);
            }
            Console.Write("Provide the project Id: ");
            int projectId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Below is the Employee ID and respective Name to choose:");
            var res = employeeManager.GetEmployee();
            if (res.IsSuccess)
            {
                foreach (Employee e in res.results)
                {
                    Console.WriteLine(e.EmpId + " : " + e.FirstName + " : "+ e.LastName);
                }
            }
            else
            {
                Console.WriteLine(res.Status);
            }
            Console.Write("Enter the Id of the employee which you want to add: ");
            employee.EmpId = Convert.ToInt32(Console.ReadLine());
            var valid = employeeManager.IsValidEmp(employee);
            if (valid.IsSuccess)
            {

                var obj = employeeManager.GetEmployeeByRole(employee);
                employee.FirstName = obj.FirstName;
                var result = projectManager.AddEmpToProject(employee, projectId);

                if (!result.IsSuccess)
                {
                    Console.WriteLine("Failed to Add Employee into project");
                    Console.WriteLine(result.Status);
                }
                else
                {
                    Console.WriteLine(result.Status);
                }
                
            }
            else
            {
                Console.WriteLine(valid.Status);
            }
           
        }

        private static void RemoveEmpFromProject()
        {
            ProjectManager projectManager = new ProjectManager();
            Employee employee = new Employee();
            Console.WriteLine("Choose Project From Below Project List:");
            Console.WriteLine("Project ID: Project Name");
            var resPro = projectManager.GetProject();
            if (resPro.IsSuccess)
            {
                foreach (Project res in resPro.results)
                {
                    Console.WriteLine(res.ProjectId + " : " + res.ProjectName);
                }
            }
            else
            {
                Console.WriteLine(resPro.Status);
            }

            Console.Write("Enter The project Id From Employee Should Be removed: ");
            int projectId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Choose The Employee Id in Selected Project Id: {projectId} From the Following List: Employee ID : Employee Name");
            var empList = projectManager.GetProjectByID(projectId);
            foreach (Employee res in empList.ProEmplist)
            {
                Console.WriteLine(res.EmpId + " : " + res.FirstName);
            }
            Console.Write("Enter the ID of the Employee to remove: ");
            employee.EmpId = Convert.ToInt32(Console.ReadLine());
            var result = projectManager.DeleteEmpFromProject(projectId, employee);
            if (!result.IsSuccess)
            {
                Console.WriteLine("Failed to Delete Employee into project");
                Console.WriteLine(result.Status);
            }
            else
            {
                Console.WriteLine(result.Status);
            }
        }
    }
}