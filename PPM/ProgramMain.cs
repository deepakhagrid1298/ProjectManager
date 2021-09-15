using System;
using System.Collections.Generic;
using PPM.Model;
using PPM.Domain;
using PPM.UI.Cons;

namespace PPM
{
    public class ProgramMain
    {
        /*static ProgramConsole pc;
        ProgramMain()
        {
           pc = new ProgramConsole();
        }*/
        public static void Main(string[] args)
        {
            if (args is null)
            {
                throw new ArgumentNullException(nameof(args));
            }
            ProgramConsole pc = new ProgramConsole();
            pc.SubjectMenu();
            //ProgramDomain.PerformAction(n1);
            //Console.Read();
        }


        
    }    
        
}
