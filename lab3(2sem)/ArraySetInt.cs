using System.IO;
using System;

public class ArraySetInt : ISetInt
{
    ILogger logger = null;
        FileLogger flog = new FileLogger();
         
    private int [] _items;
    private int _size;
    public ArraySetInt()
    {
       _items=new int[16];
       _size = 0;
    } 
    public int Count()
    { 
        Console.WriteLine(_size);
         return _size; 
    }

    public bool Add(int value)
    {    logger = flog;
        logger.Log("Starting...");
        int index=this.FindIndex(value);
        if (index>=0)
        {
            Console.WriteLine("False");
            logger.LogError("Error,"+value+" dont Added");
            logger.Log("Stopping...");
            return false;
           
        }
        else{Console.WriteLine("True");}
        if(_size == _items.Length)
        {
            Array.Resize(ref _items,_size*2);
           
        }
        _items[_size]= value;
        _size++;
        logger.Log("Add  "+ value);
        logger.Log("Stopping...");
        return true;
      
    }

    public void Clear()
    {logger = flog;
     logger.Log("Starting...");
     logger.Log("Glear...");
        _size =0;
        Console.WriteLine("True");
         logger.Log("Stopping...");
    }
    public bool Write (string file)
    {
     logger.Log("Starting...");    
StreamWriter sw = new StreamWriter(file);

logger.Log("Write in "+file);
while (true)
{
  for(int i =0;i<_size;i++)
  {
     
 
   sw.WriteLine(_items[i]);
}

sw.Close();
logger.Log("Stopping...");
    return true;
    }}
    public bool Read(string file)
    {
         logger.Log("Starting...");  
     StreamReader sr = new StreamReader(file);
     string s ="";
     int k=0;
     logger.Log("Read with "+file);
     while (true)
      {
        s =sr.ReadLine();
  
   if (s != null)
   {
   k=int.Parse(s);
   int value=k;
   Add(value);
   }
   else
   {break;}     
}
sr.Close();
logger.Log("Stopping...");
return true;

    }

    public bool Contains(int value)
    { logger.Log("Starting...");  
        int index=this.FindIndex(value);
        if(index>=0)
        {
            logger.Log("Have "+ value);
           Console.WriteLine("True");
        }
        else
        {
            Console.WriteLine("False") ;
            logger.Log("Not have "+ value);
        }
        logger.Log("Stopping...");
        return index>=0;
        
    }
    public int[] Arr()
    {
        int []wer=new int [_size];
        for(int i=0;i<_size;i++)
        {
            wer[i]=_items[i];

        }
        return wer;
    }
    private int FindIndex(int value)
    {
       
        for(int i=0;i<_size;i++)
        {
            if (_items[i]==value)
            {
                return i;  
                 
            }
        }
         
        return -1;
    }
    public void Log()
    { logger.Log("Starting..."); 
for(int i =0;i<_size;i++)
     {
        Console.Write(_items[i]+" ");
     }  logger.Log("Ready");
     Console.WriteLine();
    logger.Log("Stopping...");
    }

    public void CopyTo(int[] array)
    {
     for(int i =0;i<_size;i++)
     {
         _items[i]=array[i];
     }
    }

    public bool Remove(int value)
    {logger.Log("Starting..."); 
        int index=this.FindIndex(value);
        if (index==-1)
        {
           Console.WriteLine("False");
            logger.Log(value+" not deleted");
            return false;

        }
        else{Console.WriteLine("True");logger.Log(value+" deleted");}
        for(int i=index+1; i<_size-1;i++)
        {
            _items[i]=_items[i+1];
        }
        this._size--;
        logger.Log("Stopping...");
        return true;
    }
}
