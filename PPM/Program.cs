using System;
using System.Collections.Generic;

namespace PPM
{
    class Program
    {
        static List<Employee> emplist = new List<Employee>();
        static List<Project> prolist = new List<Project>();
        static List<Role> rolelist = new List<Role>();

        static void Main(string[] args)
        {
            Console.WriteLine("My Menu:-");
            Console.WriteLine("1:- Add Project");
            Console.WriteLine("2:- View Projects");
            Console.WriteLine("3:- Add Employee");
            Console.WriteLine("4:- View Employees");
            Console.WriteLine("5:- Add Role");
            Console.WriteLine("6:- View Roles");
            Console.WriteLine("7:- Quit");
            int n1 = MyMenu();
            PerformAction(n1);
            Console.Read();
        }
        public static void PerformAction(Int32 n)
        {
            switch (n)
            {
                case 1:
                    AddProject();
                    break;
                case 2:
                    DisplayProject();
                    Int32 n2 = MyMenu();
                    PerformAction(n2);
                    break;
                case 3:
                    AddEmployee();
                    break;
                case 4:
                    DisplayEmployee();
                    Int32 n1 = MyMenu();
                    PerformAction(n1);
                    break;
                case 5:
                    AddRole();
                    break;
                case 6:
                    DisplayRole();
                    Int32 n3 = MyMenu();
                    PerformAction(n3);
                    break;
                case 7:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Error!! Please Re-Enter");
                    n1 = MyMenu();
                    PerformAction(n1);
                    break;
            }
        }
        public static int MyMenu()
        {
            Console.WriteLine("Please Select from 1 to 7");
            
            Int32 n = Convert.ToInt32(Console.ReadLine());
            
            return n;
        }
        public static List<Project> AddProject()
        {
            Project pro = new Project();
                Console.WriteLine("Enter Project ID");
                pro.ProjectId = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Project Name");
                pro.ProjectName = Console.ReadLine();
                Console.WriteLine("Enter Project Start Date");
                pro.StartDate = Convert.ToDateTime(Console.ReadLine());
                Console.WriteLine("Enter Project Budget");
                pro.Budget = Convert.ToInt64(Console.ReadLine());
                if (prolist.Count > 0)
                {
                    if (prolist.Exists(proj => proj.ProjectId == pro.ProjectId))
                    {
                        Console.WriteLine("Project already exists with id:" + pro.ProjectId);
                    }
                    else

                        prolist.Add(pro);

                }
                else
                {
                    prolist.Add(pro);
                    Console.WriteLine("Project Added successfully");
                }
            Console.WriteLine(@"Do you want to add more Project? Y\N\n");
            char choice = Console.ReadKey().KeyChar;
            switch (Char.ToUpper(choice))
            {
                case 'Y':
                    AddProject();
                    break;
                case 'N':
                    Int32 n1 = MyMenu();
                    PerformAction(n1);
                    break;
                default:
                    Console.WriteLine("Error");
                    n1 = MyMenu();
                    PerformAction(n1);
                    break;
            }
            return prolist;
        }
        public static void DisplayProject()
        {
            Console.WriteLine("Project Detail:-");
            foreach (Project proj in prolist)
            {
                Console.WriteLine(" Project ID:" + proj.ProjectId + "\nProject Name:" + proj.ProjectName + "\nStart Date:" + proj.StartDate + "\nBudget:" + proj.Budget);
                Console.WriteLine("");
            }
        }
        public static List<Employee> AddEmployee()
        {
            Employee employee = new Employee();
            Console.WriteLine("Enter Employee ID");
            employee.EmpId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter FirstName");
                employee.FirstName  = Console.ReadLine();
                Console.WriteLine("Enter LastName ");
                employee.LastName = Console.ReadLine();
                Console.WriteLine("Enter Email");
                employee.Email = Console.ReadLine();
                if (emplist.Count > 0)
                {
                    if (emplist.Exists(emp => employee.EmpId == employee.EmpId))
                    {
                        Console.WriteLine("Employee already exists with Name:" + employee.EmpId);
                    }
                    else
                    {
                        emplist.Add(employee);
                    }
                }
                else
                {
                    emplist.Add(employee);
                    Console.WriteLine("Employee Added successfully");
                }
                Console.WriteLine(@"Do you want to add more Employee? Y\N\n");
                char choice = Console.ReadKey().KeyChar;
                switch (Char.ToUpper(choice))
                {
                    case 'Y':
                        AddEmployee();
                        break;
                    case 'N':
                        Int32 n1 = MyMenu();
                    PerformAction(n1);
                        break;
                    default:
                        Console.WriteLine("Error !! Please ReEnter");
                        n1 =MyMenu();
                    PerformAction(n1);
                        break;
                }
            return emplist;
        }
        public static void DisplayEmployee()
        {
            Console.WriteLine("Employee Detail:-");
            foreach (Employee emp in emplist)
            {
                Console.WriteLine("Employee EmpId:" + emp.EmpId +"\nEmployee FirstNmae:" + emp.FirstName + "\nEmployee LastName:" + emp.LastName + "\nEmail:" + emp.Email);
                Console.WriteLine("");
            }
        }
        public static List<Role> AddRole()
        {
            Role r = new Role();
                Console.WriteLine("Enter Role ID");
                r.RoleId = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Role Name");
                r.RoleName = Console.ReadLine();
            if (rolelist.Count > 0)
                {
                    if (emplist.Exists(emp => r.RoleId == r.RoleId))
                    {
                        Console.WriteLine("Role already exists with Name:" + r.RoleId);
                    }
                    else
                    {
                        rolelist.Add(r);
                    }
                }
                else
                {
                    rolelist.Add(r);
                    Console.WriteLine("Role Added successfully");
                }
                Console.WriteLine(@"Do you want to add more Role? Y\N\n");
                char choice = Console.ReadKey().KeyChar;
                switch (Char.ToUpper(choice))
                {
                    case 'Y':
                        AddRole();
                        break;
                    case 'N':
                        Int32 n1 = MyMenu();
                    PerformAction(n1);
                        break;
                    default:
                        Console.WriteLine("Error! Please ReEnter");
                        n1 = MyMenu();
                    PerformAction(n1);
                        break;
                }
            return rolelist;
        }
        private static void DisplayRole()
        {
            Console.WriteLine("Desplaying Role:-");
            foreach (Role role in rolelist)
            {
                Console.WriteLine("Role ID:" + role.RoleId + " \nRole Name:" + role.RoleName);
                Console.WriteLine("");
            }
        }
    }
}
