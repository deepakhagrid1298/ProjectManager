using System;

namespace PPM
{
    class Program
    {
        static void Main(string[] args)
        {
            MyType[] m = new MyType[7];
            m[0] = new AddProject();
            m[1] = new ViewProject();
            m[2] = new AddEmployee();
            m[3] = new ViewEmployee();
            m[4] = new AddRole();
            m[5] = new ViewRole();
            m[6] = new Quit();

            Console.WriteLine("Please Enter value in 1 to 7");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(m[n-1]);
            Console.ReadKey();
        }
    }
}
