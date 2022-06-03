// #define LOG_INFO
using System;
using System.Reflection;
using LoggingComponent;
// [assembly:AssemblyVersion("2.0.1")]
[assembly: AssemblyDescription("Description")]

internal class Program
{
    private static void Main(string[] args)
    {
        Logging.LogToScreen("Hello World");
    }

    public static void OutputGlobalAttributeInformation()
    {
        Assembly thisAssemb = typeof(Program).Assembly;
        AssemblyName thisAssembName = thisAssemb.GetName();
        Version thisAssembVersion = thisAssembName.Version!=null?thisAssembName.Version:new Version(0,0,0,0);
        object[] attributes = thisAssemb.GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
        var thisAssemDescrAttrib = attributes[0] as AssemblyDescriptionAttribute;
        Console.WriteLine("Assembly Name: {0}", thisAssembName.Name);
        Console.WriteLine("Assembly Version: {0}", thisAssembVersion.ToString());
        Console.WriteLine("Assembly Description: {0}", thisAssemDescrAttrib!=null?thisAssemDescrAttrib.Description:"");
    }
}