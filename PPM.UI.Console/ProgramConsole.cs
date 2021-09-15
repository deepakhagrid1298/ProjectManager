using PPM.Model;
using System;
using PPM.Domain;
using PPM.Model.Common;

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
            Console.WriteLine("7:- Quit");

            bool i = true;
            while (i)
            {
                Console.Write("select from 1 to 7 ");
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

                        /*if (prolist.Exists(prolist => prolist.projectId == p2.ProjectId))
                        {
                            Console.WriteLine("project already exists");
                        }
                        else
                        {
                            prolist.Add(p2);
                        }*/
                        
                        var ar=m1.AddProject(p2);
                        Console.WriteLine(ar.Status);

                        break;
                    case 2:
                        var d1=m1.GetProject();
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
                        Employee emp = new Employee();

                        Console.WriteLine("Enter Employee Id");
                        emp.EmpId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter Employee Fullname");
                        emp.FirstName = Console.ReadLine();
                        Console.WriteLine("Enter Employee Contact");
                        emp.LastName = Console.ReadLine();
                        Console.WriteLine("Enter Employee Email");
                        emp.Email = Console.ReadLine();

                        var ar2=m2.AddEmployee(emp);
                        Console.WriteLine(ar2.Status);
                        /*if (emplist.Exists(emplist => emplist.Id == emp.Id))
                        {
                            Console.WriteLine("employee already exists");
                        }
                        else
                        {
                            emplist.Add(emp);
                        }*/
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
                        var ar3=m3.AddRole(rol);
                        Console.WriteLine(ar3.Status);
                        /*if (rolelist.Exists(rolelist => rolelist.RoleId == role.RoleId))
                        {
                            Console.WriteLine("Role already exists");
                        }
                        else
                        {
                            rolelist.Add(rol);
                        }*/



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
                        Environment.Exit(0);
                        break;



                    default:
                        Console.WriteLine("Invalid Option");
                        break;
                }
            }

        }

            /*private bool AddEmployee()
            {

                Employee employee = new Employee();
                Console.Write("Enter Employee Id(give integer value only):");
                employee.EmpId = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter Employee FirstName: ");
                employee.FirstName = Console.ReadLine();
                Console.Write("Enter Employee LastName: ");
                employee.LastName = Console.ReadLine();
                Console.Write("Enter Employee Email: ");
                employee.Email = Console.ReadLine();

                EmployeeManager employeeManager = new EmployeeManager();
                var result = employeeManager.AddEmployee(employee);
                if (!result.IsSuccess)
                {
                    Console.WriteLine("Employee Failed to add!");
                    Console.WriteLine(result.Status);
                }
                else
                {
                    Console.WriteLine(result.Status);
                }
                return result.IsSuccess;

            }

            private bool AddRole()
            {
                Role role = new Role();
                Console.Write("Enter Role Id ");
                role.RoleId = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter Role Name: ");
                role.RoleName = Console.ReadLine();

                RoleManager roleManager = new RoleManager();
                var result = roleManager.AddRole(role);
                if (!result.IsSuccess)
                {
                    Console.WriteLine("Role Failed to Add");
                    Console.WriteLine(result.Status);
                }
                else
                {
                    Console.WriteLine(result.Status);
                }
                return result.IsSuccess;
            }

            private bool AddProject()
            {
                Project project = new Project();
                Console.Write("Enter Project ID(give integer value only): ");
                project.ProjectId = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter Project Name: ");
                project.ProjectName = Console.ReadLine();
                Console.Write("Enter Project Budget: ");
                project.Budget = Convert.ToInt64(Console.ReadLine());
                Console.Write("Enter Project Start Date");
                project.StartDate = Convert.ToDateTime(Console.ReadLine());

                ProjectManager projectManager = new ProjectManager();
                var result = projectManager.AddProject(project);
                if (!result.IsSuccess)
                {
                    Console.WriteLine("Project failed to Add");
                    Console.WriteLine(result.Status);
                }
                else
                {
                    Console.WriteLine(result.Status);
                }
                return result.IsSuccess;
            }*/

        }
    }
