using System;
using System.Linq;

class Program
    {
        static void  SymmetricExceptWithA(ISetInt B,ISetInt A,ILogger logger)
  { logger.Log("Starting...");
      int k=0;
    int[] c =new int[16];
    var result = A.Arr().Except(B.Arr());
    foreach (int s in result)
    k++;
    A.Clear();
    foreach (int value in result)
        A.Add(value);
        logger.Log("Stopping...");
  }
         static void  SymmetricExceptWithB(ISetInt B,ISetInt A,ILogger logger)
  {  logger.Log("Starting...");
      int k=0;
    int[] c =new int[16];
    var result = B.Arr().Except(A.Arr());
    foreach (int s in result)
    k++;
    B.Clear();
    foreach (int value in result)
        B.Add(value);
         logger.Log("Ready");
        logger.Log("Stopping...");
  }

        static void IsSuperSet(ISetInt B,ISetInt A,ILogger logger)
  {logger.Log("Starting...");
      int c=0;
      
    for(int i =0; i<B.Arr().Length;i++)
    {
        for(int j =0; j<A.Arr().Length;j++)
        {
         if(B.Arr()[i]==A.Arr()[j])
         {
           c++;
         }
          
      }
        
    }if(c==B.Arr().Length&&c==A.Arr().Length)
    {
        Console.WriteLine("А = В");
        logger.Log("A=B");
    }
    else if(c==B.Arr().Length)
    {
        Console.WriteLine("А - надмножина В");
        logger.Log("А - надмножина В");
    }
    else if(c==A.Arr().Length)
    {
        Console.WriteLine("B - надмножина A");
         logger.Log("B - надмножина A");
    }
    else
    {
        Console.WriteLine("Нема надмножин");
         logger.Log("Нема надмножин");
    }
    logger.Log("Stopping...");
  }

        static void ProccesB(ISetInt B,string[] subcomands,ISetInt A,ILogger logger)
  {
      if (subcomands[1]=="add")
      {  int value;
          if (!Int32.TryParse(subcomands[2],out value))
      {
          Console.WriteLine("Error: subcomands[2]");
      }
      else{B.Add( value);}
       
        
      }
      else if (subcomands[1]=="count")
      {
         B.Count() ;
      }
       else if (subcomands[1]=="contains")
      {
        int value;
          if (!Int32.TryParse(subcomands[2],out value))
      {
          Console.WriteLine("Error: subcomands[2]");
      }
      else{ B.Contains(value);}
       
      }
      else if (subcomands[1]=="remove")
      {
        int value;
          if (!Int32.TryParse(subcomands[2],out value))
      {
          Console.WriteLine("Error: subcomands[2]");
      }
      else{ B.Remove(value);}
        
      }
      else if (subcomands[1]=="clear")
      {
        B.Clear();
      }
       else if (subcomands[1]=="read")
      {
        string file= subcomands[2]; 
          B.Read(file);
      }
       else if (subcomands[1]=="log")
      {
          B.Log();
      }
       else if (subcomands[1]=="write")
      {
        string file= subcomands[2]; 
        B.Write(file);
      }
      else if (subcomands[1]=="symmetricexceptwith")
      {
          SymmetricExceptWithB(B,A,logger);
      }
      else
      {
          Console.WriteLine("ERROR:subcomands[1]!");
      }


  }
        static void ProccesA(ISetInt A,string[] subcomands,ISetInt B,ILogger logger)
  {
       if (subcomands[1]=="add")
      {// logger.Log("Starting..."); 
       int value;
          if (!Int32.TryParse(subcomands[2],out value))
      {
          Console.WriteLine("Error: subcomands[2]");
      }
      else{   A.Add( value);} 
     // logger.Log("Stopping...");
      }
      else if (subcomands[1]=="count")
      {
         A.Count() ;
      }
       else if (subcomands[1]=="contains")
      {
        int value;
          if (!Int32.TryParse(subcomands[2],out value))
      {
          Console.WriteLine("Error: subcomands[2]");
      }
      else{  A.Contains(value);
       } 
      }
      else if (subcomands[1]=="remove")
      {
         int value;
          if (!Int32.TryParse(subcomands[2],out value))
      {
          Console.WriteLine("Error: subcomands[2]");
      }
      else{  A.Remove(value);} 
       
      }
      else if (subcomands[1]=="clear")
      {
        A.Clear();
      }
       else if (subcomands[1]=="read")
      {
        string file= subcomands[2]; 
          A.Read(file);
      }
      else if (subcomands[1]=="log")
      {
          A.Log();
      }
       else if (subcomands[1]=="write")
      {
        string file= subcomands[2]; 
        A.Write(file);
          
      }
       else if (subcomands[1]=="symmetricexceptwith")
      {
          SymmetricExceptWithA(B,A,logger);
      }
      else
      {
          Console.WriteLine("ERROR:subcomands[1]!");
      }
  }

        static void Main(string[] args)
        {ISetInt iset = new ArraySetInt();
         ISetInt iset1 = new ArraySetInt();  
         ILogger logger = null;
         FileLogger flog = new FileLogger();
         logger = flog;  
            while(true)
        {

            
            Console.WriteLine("Enter comand:");
           string comand= Console.ReadLine();
           string[] subcomands = comand.Split(' ');
           if (subcomands[0]=="a")
           {
              ProccesA(iset,subcomands,iset1,logger);
           }
           else if(subcomands[0]=="b")
           {
                ProccesB(iset1,subcomands, iset,logger);
           }
           else if(subcomands[0]=="issuperset")
           {
               IsSuperSet(iset1,iset, logger);
           }
           else
           {
              Console.WriteLine("ERROR:subcomands[0]!"); 
              break;
           }
        } 
    }
}