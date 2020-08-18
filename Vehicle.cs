using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class Vehicle
    {
        private int _ID;
        private string _make;
        private string _model;
        private int _year;
        private string _type;

        public Vehicle()
        {
        }

        public Vehicle(int id, string ma, string mo, int ye, string ty)
        {
            _ID = id;
            _make = ma;
            _model = mo;
            _year = ye;
            _type = ty;
        }

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public string Make
        {
            get { return _make; }
            set { _make = value; }
        }
        public string Model
        {
            get { return _model; }
            set { _model = value; }
        }
        public int Year
        {
            get { return _year; }
            set { _year = value; }
        }
        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public override string ToString()
        {
            string veh1 = 
                           String.Format("|{0,-9}|{1,-10}|{2,-10}|{3,-10}|{4,-10}", ID ,Make , Model ,Year ,Type);

              

            return veh1;
        }
    }
}
