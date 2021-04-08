using System;
class FileLogger : ILogger
{
   private string logFilePath;
   private string errorFilePath;
  public FileLogger()
   {   string s =DateTime.Now.ToString("yyyy-MM-ddTHH-mm-ss.fff", System.Globalization.CultureInfo.InvariantCulture) + ".txt";
       this.logFilePath =s;
       this.errorFilePath =s ;
   }
   public void Log(string message)
   {
       string[] lines = new string[1];
       lines[0] = message;
       System.IO.File.AppendAllLines(this.logFilePath, lines);
   }
 
   public void LogError(string message)
   {
       string[] lines = new string[1];
       lines[0] = message;
       System.IO.File.AppendAllLines(this.errorFilePath, lines);
   }
}
