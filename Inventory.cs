using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class Inventory
    {
        private int _ID;
        private int _vehicleID;
        private int _numberOnHand;
        private double _price;
        private double _cost;

        public Inventory(int id, int vehid, int noh, double pr, double co)
        {
            ID = id;
            _vehicleID = vehid;
            _numberOnHand = noh;
            _price = pr;
            _cost = co;

           
}

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public int VehicleId
        {
            get { return _vehicleID; }
            set { _vehicleID = value; }
        }
        public int NumberOnHand
        {
            get { return _numberOnHand; }
            set { _numberOnHand = value; }
        }
        public double Price
        {
            get { return _price; }
            set { _price = value; }
        }
        public double Cost
        {
            get { return _cost; }
            set { _cost = value; }
        }

        public override string ToString()
        {
            string inv1 = String.Format("|{0,-9}|{1,-10}|{2,-10}|{3,-10}|{4,-10}", ID, VehicleId, NumberOnHand, Price,Cost);





            return inv1;
        }

    }
}
