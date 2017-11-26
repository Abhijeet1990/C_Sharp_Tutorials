using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IronPython.Hosting; // make us use Python

namespace RunPythonScript
{
    class UsingIronPython
    {
        static void Main(string[] args)
        {

            int a = 1;
            int b = 2;

            Microsoft.Scripting.Hosting.ScriptEngine py = Python.CreateEngine(); // allow us to run ironpython programs
            Microsoft.Scripting.Hosting.ScriptScope s = py.CreateScope(); // you need this to get the variables
            py.Execute("x = " + a + "+" + b, s); // this is your python program
            Console.WriteLine(s.GetVariable("x")); // get the variable from the python program
            Console.ReadLine(); // wait for the user to press a button
        }
    }
}
