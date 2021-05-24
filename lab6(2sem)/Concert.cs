using System;
using Terminal.Gui;
    public class Concert
    {
        public long id;
        public string name;
        public string songers;
        public string place;
        public bool cost;
        public DateTime  startDate;

        public override string ToString()
        {
          return $"[{id}]  {name} - {songers}";
        }

    }
