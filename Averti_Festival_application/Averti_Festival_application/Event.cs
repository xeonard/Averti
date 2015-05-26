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
        private int maxtickets;
        private int maxcamping;
        private string date;
        private string description;
        private string location;
        private int minage;

        public Event(int minage, string date, string location, int nrofpeople, string name, int maxcamping, string des)
        {
            this.Minage = minage;
            this.Name = name;
            this.Maxcamping = maxcamping;
            this.Location = location;
            this.Maxtickets = nrofpeople;
            this.Date = date;
            this.Maxcamping = maxcamping;
            this.Description = des;
        
        }
        public Event(int minage,int id, string date, string location, int nrofpeople, string name, int maxcamping, string des ){
            this.Minage = minage;
            this.Name = name;
            this.Eventid = id;
            this.Maxcamping = maxcamping;
            this.Location = location;
            this.Maxtickets = nrofpeople;
            this.Date = date;
            this.Maxcamping = maxcamping;
            this.Description = des;
        }


        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        
        public int Eventid
        {
            get { return this.eventid; }
            set { this.eventid = value; }
        }

        public int Maxcamping
        {
            get { return this.maxcamping; }
            set { this.maxcamping = value; }
        }

        public int Maxtickets
        {
            get { return this.maxtickets; }
            set { this.maxtickets = value; }
        }

        public string Date
        {
            get { return date; }
            set { date = value; }
        }


        public string Location
        {
            get { return location; }
            set { location = value; }
        }

        public string Description
        {
            get { return this.description; }
            set { this.description = value; }
        }


        public int Minage
        {
            get { return minage; }
            set { minage = value; }
        }



    }
}
