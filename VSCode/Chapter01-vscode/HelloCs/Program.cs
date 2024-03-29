﻿using System;
using System.Linq;
using System.Net.Http;
using System.Reflection;

// System.Data.DataSet ds;
// HttpClient cliente;
namespace HelloCs
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly assembly = Assembly.GetEntryAssembly();
            // loop through the assemblies that this app references
            foreach (AssemblyName name in assembly.GetReferencedAssemblies())
            {
                // load the assembly so we can read its details
                Assembly a = Assembly.Load(name);
                // declare a variable to count the number of methods
                int methodCount = 0;
                // loop through all the types in the assembly
                foreach (TypeInfo t in a.DefinedTypes)
                {
                    // add up the counts of methods
                    methodCount += t.GetMethods().Count();
                }
                // output the count of types and their methods
                Console.WriteLine(
                  "{0:N0} types with {1:N0} methods in {2} assembly.",
                  arg0: a.DefinedTypes.Count(),
                  arg1: methodCount, arg2: name.Name);
            }
        }
    }
}
