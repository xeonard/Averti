using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvertiFestivalApplication
{
    public class Event
    {
        private string name;
        private int eventid;
        public Event(string name, int id){
            this.Name = name;
            this.Eventid = id;

        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        
        public int Eventid
        {
            get { return eventid; }
            set { eventid = value; }
        }
       
    }
}
