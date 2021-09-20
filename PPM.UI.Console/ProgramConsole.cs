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
            Employee emp = new Employee();
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
                        Project p2 = new Project();

                        Console.WriteLine("Enter Project id");
                        p2.ProjectId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter Project Name");
                        p2.ProjectName = Console.ReadLine();
                        Console.WriteLine("Enter Project Start Date");
                        p2.StartDate = Convert.ToDateTime(Console.ReadLine());
                        Console.WriteLine("Enter Project Budget");
                        p2.Budget = Convert.ToInt64(Console.ReadLine());

                        var ar = m1.AddProject(p2);
                        Console.WriteLine(ar.Status);

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


                        Console.WriteLine("Enter Employee Id");
                        emp.EmpId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter Employee FirstName");
                        emp.FirstName = Console.ReadLine();
                        Console.WriteLine("Enter Employee LastName");
                        emp.LastName = Console.ReadLine();
                        Console.WriteLine("Enter Employee Email");
                        emp.Email = Console.ReadLine();

                        var ar2 = m2.AddEmployee(emp);
                        Console.WriteLine(ar2.Status);
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
                        string[] role = new string[2];
                        Role rol = new Role();

                        Console.WriteLine("Enter Role Id");
                        rol.RoleId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter RoleName");
                        rol.RoleName = Console.ReadLine();
                        var ar3 = m3.AddRole(rol);
                        Console.WriteLine(ar3.Status);
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
                        Console.WriteLine("Enter Project id in which u want to enter employee:");
                        int p1 = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter employee id which u want add");
                        int p3 = Convert.ToInt32(Console.ReadLine());
                        var v1 = m1.AddEmpToProject(emp, p1);
                        Console.WriteLine(v1.Status);
                        break;
                    case 8:
                        Console.WriteLine("Enter Employee id which u want delete:");
                        int n1 = Convert.ToInt32(Console.ReadLine());
                        var v2 = m1.DeleteEmpFromProject(n1, emp);
                        Console.WriteLine(v2.Status);
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
                                        Console.WriteLine("Employee Id: " + e.EmpId + " " + "Employee First Name: " + e.FirstName + " " + "Employee Last: " + e.LastName);
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
    }
}