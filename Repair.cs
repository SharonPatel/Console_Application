using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class Repair
    {
        private int _ID;
        private int _inventoryID;
        private string _whatToRepair;

        public Repair()
        {
        }

        public Repair(int id , int invId, string wtr)
        {
            ID = id;
            InventoryID = invId;
            WhatToRepair = wtr;
        }

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public int InventoryID
        {
            get { return _inventoryID; }
            set { _inventoryID = value; }
        }
        public string WhatToRepair
        {
            get { return _whatToRepair; }
            set { _whatToRepair = value; }
        }
        public override string ToString()
        {
            string rep = String.Format("|{0,-9}|{1,-10}|{2,-10}", ID, InventoryID, WhatToRepair);


            return rep;
        }
    }


  
}
