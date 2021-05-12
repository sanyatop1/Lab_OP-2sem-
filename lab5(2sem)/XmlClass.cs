using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Linq;

    public class XmlClass: IXmlWork
    {
       [XmlRoot("catalog")]
public class Catalog
{
   [XmlElement("book")]
   public List<Book> books;
}
public class Book
{
   public string id;
   public string author;
   public string title;
   public double price;
}
        public void Load(string filename)
        {
          
         
XmlSerializer ser = new XmlSerializer(typeof(Catalog));
StreamReader reader = new StreamReader(filename);
Catalog value = (Catalog)ser.Deserialize(reader);
reader.Close();
Console.WriteLine("True");
        }
        public void Print(int pageNum)
        {
          XElement root = XElement.Load("data.xml");
      Traverse(root, pageNum);
      root.Save("changed.xml");
        }
static void Traverse(XElement node,int pageNum)
  {int c=0;
      
 
      foreach (XElement el in node.Elements("book"))
      {
          
          if (c==pageNum)
          {
            Console.WriteLine($" {node.Value}");
          }
              c++;
      }
      Console.WriteLine("Кількість сторінок: "+c);
      if (c<pageNum)
      {
          Console.WriteLine("Немає такої сторінки");
      }
  }

        public void Save(string filename)
        {
            List<Book> books = new List<Book>
{
   new Book{id="bk101", author="Gambardella, Matthew",title="XML Developer's Guide",price=44.95},
   new Book{id="bk02", author="Ralls, Kim",title="Midnight Rain",price=5.95},
   new Book{id="bk03", author="Corets, Eva",title="Midnight Rain",price=5.95},
   new Book{id="bk04", author="Corets, Eva",title="Oberon's Legacy",price=5.95},
};

          
         XmlSerializer ser = new XmlSerializer(typeof(List<Book>));
System.IO.StreamWriter writer = new System.IO.StreamWriter(filename);
ser.Serialize(writer, books);
writer.Close();
        }
    }
