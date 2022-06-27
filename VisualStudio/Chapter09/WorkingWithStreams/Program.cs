using System.Xml;
using System;
using System.IO;

//WorkWithText();
WorkWithXml();

static void WorkWithXml()
{
    //define a file to write to
    string xmlFile = Path.Combine(Environment.CurrentDirectory, "stream.xml");
    //create a file stream
    FileStream xmlFileStream = File.Create(xmlFile);
    //wrap the file stream in a XML writer helper
    //and automatically indent nested elements
    XmlWriter xmlWriter = XmlWriter.Create(xmlFileStream, new XmlWriterSettings { Indent = true });
    //write the XML declaration
    xmlWriter.WriteStartDocument();
    //write a root element 
    xmlWriter.WriteStartElement("callsigns");
    // enumerate the strings writing each one to the stream
    foreach (string item in Viper.Callsigns)
    {
        xmlWriter.WriteElementString("callsign", item);
    }
    xmlWriter.WriteEndElement();
    xmlWriter.Close();
    xmlFileStream.Close();
    // output all the contents of the file
    Console.WriteLine("{0} contains {1:N0} bytes.",
      arg0: xmlFile,
      arg1: new FileInfo(xmlFile).Length);
    Console.WriteLine(File.ReadAllText(xmlFile));
}



static void WorkWithText()
{
    //define a file to write to
    string textFile = Path.Combine(Environment.CurrentDirectory, "stream.txt");
    //create a text file and return a helper writer
    StreamWriter text = File.CreateText(textFile);
    // enumerate the strings, writing each one
    // to the stream on a separate line
    foreach (string item in Viper.Callsigns)
    {
        text.WriteLine(item);
    }
    text.Close(); // release resources
                  // output the contents of the file
    Console.WriteLine("{0} contains {1:N0} bytes.",
      arg0: textFile,
      arg1: new FileInfo(textFile).Length);
    Console.WriteLine(File.ReadAllText(textFile));
}
static class Viper
{
    // define an array of Viper pilot call signs
    public static string[] Callsigns = new[]
    {
        "Husker", "Starbuck", "Apollo", "Boomer",
        "Bulldog", "Athena", "Helo", "Racetrack"
    };
}