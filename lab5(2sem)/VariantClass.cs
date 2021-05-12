using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Linq;
    public class VariantClass: IXmlVariant
    {
        [XmlRoot("root")]
        public class Root
{
   [XmlElement("course")]
   public List<Course> courses;
}
   public class Course
{
   public int reg_num;
   public string subj;
   public string instructor;
   public double units;
}

        public void Subjects()
        {int c =0;
XElement node = XElement.Load("variant.xml");
      FindAndReplace(node,c);
    
      node.Save("changed.xml");
        }
 static void FindAndReplace(XElement node,int c )
   {
       if (node.FirstNode == node.Elements("subj"))
       {
          
              c++;
       }
       Console.WriteLine(c);
 
       
   }

  
        public void Subject( string subj)
        {
              
        }
       public void instructors()
       {

       }
    }
