using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;



    class Program
    {
        

        static void Main(string[] args)
        {

            IXmlWork work =new XmlClass();
            IXmlVariant variant=new VariantClass();

 while(true)
        {
            Console.WriteLine("Enter comand:");
         string comand= Console.ReadLine();
           string[] subcomands = comand.Split(' ');
           if (subcomands[0]=="load")
           {
               string filename=subcomands[1];
               work.Load( filename);
           }
           else if (subcomands[0]=="print")
           {
               int pageNum=int.Parse(subcomands[1]);
               work.Print(pageNum);
           }
           else if (subcomands[0]=="save")
           {
              string filename=subcomands[1];
               work.Save(filename);
           }
           else if (subcomands[0]=="subjects")
           {
              
               variant.Subjects();
           }
           else
           {
               Console.WriteLine("Error");
               break;
           }
        }

        }
    }


