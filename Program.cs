using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Versioning;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Assignment1
{
    
    class Program
    {

        static void Main(string[] args)
        {
            //Using Colleaction List for Vehicle class and Initializing values to it.
            List<Vehicle> Vehicles = new List<Vehicle>();
            Vehicles.Add(new Vehicle(Vehicles.Count, "Mercedes", "Touring", 2019, "New"));
            Vehicles.Add(new Vehicle(Vehicles.Count, "Civic", "Sports", 2019, "Used"));
            Vehicles.Add(new Vehicle(Vehicles.Count, "Elentra", "SI", 2015, "New"));

            //Using Colleaction List for Inventory class and Initializing values to it.
            List<Inventory> inventory = new List<Inventory>();
            inventory.Add(new Inventory(inventory.Count, 1, 4, 20, 45));
            inventory.Add(new Inventory(inventory.Count,2, 10, 30, 50));

            //Using Colleaction List for Repair class and Initializing values to it.
            List<Repair> repair = new List<Repair>();
            repair.Add(new Repair(repair.Count, 3, "Oil Filter Change"));
            repair.Add(new Repair(repair.Count, 4, "Replace Air Filter"));
            repair.Add(new Repair(repair.Count, 5, "New Tires"));

            bool check = false; //used for do While Condition
            var choice1=0;  //Taking choice for Main Menu
           do
            {
                try
                {    
                    //Main Menu
                    Console.WriteLine("Welcome Please Choose a Command");
                    Console.WriteLine("Press 1 to modify vehicle");
                    Console.WriteLine("Press 2 to modify inventory");
                    Console.WriteLine("Press 3 to modify repair");
                    Console.WriteLine("Press 4 to exit program");
                    choice1 = Convert.ToInt32(Console.ReadLine());

                    switch (choice1)
                    {

                        case 1:
                            //Menu(1) for Vehicles
                            Console.WriteLine("Press 1 to list all vehicle");
                            Console.WriteLine("Press 2 to add a new vehicle");
                            Console.WriteLine("Press 3 to update vehicle");
                            Console.WriteLine("Press 4 to delete vehicle");
                            Console.WriteLine("Press 5 to return to main menu");
                            var choice2 = Convert.ToInt32(Console.ReadLine());
                            
                            //List all Vehicles
                            if (choice2 == 1)
                            {
                                //Select all from Vehicle class linq Query
                                var res = from veh1 in Vehicles
                                          select veh1;

                                Console.WriteLine("|ID\t   MAKE \t MODEL \t  YEAR \t  TYPE");
                                Console.WriteLine("================================================");
                                foreach (var item in res.Distinct())
                                   Console.WriteLine(item);
                             }
                            
                            //Add a new Vehicle
                            else if (choice2 == 2)
                            {
                                Console.WriteLine("|ID\t   MAKE \t MODEL \t  YEAR \t  TYPE");
                                Console.WriteLine("================================================");
                                //display data.
                                var option = from veh1 in Vehicles
                                             select veh1;
                                foreach (var display in option)
                                {
                                    Console.WriteLine(display);
                                }
                                Console.WriteLine("Enter a Car Make:");
                                var newMake = Console.ReadLine();

                                Console.WriteLine("Enter a Car Model:");
                                var newModel = Console.ReadLine();

                                Console.WriteLine("Enter a Car Year");
                                var newYear = Convert.ToInt32(Console.ReadLine());

                                Console.WriteLine("Enter a Car Type(Used/New)");
                                var newType = Console.ReadLine();

                                //Adding new enteries to Vehicle Class
                                Vehicles.Add(new Vehicle(Vehicles.Count, newMake, newModel, newYear, newType));

                                //Select Query
                                var addQuery = from veh1 in Vehicles
                                               select veh1;
                                Console.WriteLine("Your Data has Successfully Added");
                                Console.WriteLine("|ID\t   MAKE \t MODEL \t  YEAR \t  TYPE");
                                Console.WriteLine("================================================");
                                foreach (var add in addQuery)
                                {
                                    Console.WriteLine(add);
                                      

                                }
                            }

                            //Update an entry for a Vehicle
                            else if (choice2 == 3)
                            {
                                Console.WriteLine("|ID\t   MAKE \t MODEL \t  YEAR \t  TYPE");
                                Console.WriteLine("================================================");
                                //display data.
                                var option = from veh1 in Vehicles
                                             select veh1;
                                foreach (var display in option)
                                {
                                    Console.WriteLine(display);
                                }
                                Vehicle veh = new Vehicle();
                                Console.WriteLine("Enter a ID to update the Value");
                                var upt = Convert.ToInt32(Console.ReadLine());
                                if (upt > Vehicles.Count || upt < 0 )
                                {
                                    Console.WriteLine("ID Does not Exit");
                                }
                                else
                                {
                                   
                                    Console.WriteLine("Update Vehicale Make: ");
                                    var Make = Console.ReadLine();

                                    Console.WriteLine("Update Vehicale Model: ");
                                    var Model = Console.ReadLine();

                                    Console.WriteLine("Update Vehicale Year: ");
                                    var Year = Convert.ToInt32(Console.ReadLine());

                                    Console.WriteLine("Update Vehicale Type: ");
                                    var Type = Console.ReadLine();
                                    //Update Query
                                    var uptQuery = from veh1 in Vehicles
                                                   where veh1.ID.Equals(upt)
                                                   select veh1;
                                    Console.WriteLine("|ID\t   MAKE \t MODEL \t  YEAR \t  TYPE");
                                    Console.WriteLine("================================================");
                                    foreach (var uptitems in uptQuery)
                                    {
                                        uptitems.Make = Make;
                                        uptitems.Model = Model;
                                        uptitems.Year = Year;
                                        uptitems.Type = Type;
                                        Console.WriteLine(uptitems);
                                    }
                                    Console.WriteLine("Your data has been updated successfully");
                                    //Select Query
                                    var selectQuery = from veh1 in Vehicles
                                                      select veh1;
                                    Console.WriteLine("|ID\t   MAKE \t MODEL \t  YEAR \t  TYPE");
                                    Console.WriteLine("================================================");
                                    foreach (var select in selectQuery)
                                    {
                                        Console.WriteLine(select);
                                    }
                                    Console.WriteLine("Updated Data");

                                }
                            }

                            //Delete an entry from Vehicle Class
                            else if (choice2 == 4)
                            {
                                Console.WriteLine("|ID\t   MAKE \t MODEL \t  YEAR \t  TYPE");
                                Console.WriteLine("================================================");
                                //display data.
                                var option = from veh1 in Vehicles
                                             select veh1;
                                foreach(var display in option)
                                {
                                    Console.WriteLine(display);
                                }
                                Console.WriteLine("Enter Id to delete:");
                                var del = Convert.ToInt32( Console.ReadLine());
                                if (del > Vehicles.Count || del < 0)
                                {
                                    Console.WriteLine("ID Does Not Exit, Plese Enter Again");

                                }
                                else
                                {
                                    //Delete Query
                                    var dis = from v in Vehicles
                                              where v.ID.Equals(del)
                                              select v;

                                    Vehicles.RemoveAt(Convert.ToInt32(del));
                                    Console.WriteLine("The Vehicle Entry has sucuessfully Removed from the List");

                                    Console.WriteLine("|ID\t   MAKE \t MODEL \t  YEAR \t  TYPE");
                                    Console.WriteLine("================================================");
                                    var selectDelete = from veh1 in Vehicles
                                                       select veh1;
                                    foreach (var sel in selectDelete)
                                        Console.WriteLine(sel);
                                }
                            }
                           
                            break;
                        case 2:
                            Console.WriteLine("Press 1 to insert new inventor");
                            Console.WriteLine("Press 2 view inventory for a vehicle");
                            Console.WriteLine("Press 3 Update inventory for a vehicle");
                            Console.WriteLine("Press 4 Delete inventory for a vehicle");
                            Console.WriteLine("Press 5 to return to main menu");
                            var choice3 = Convert.ToInt32(Console.ReadLine());


                            if (choice3 == 1)
                            {
                                Console.WriteLine("|ID \t VEHICLEID NUMBERONHANDS PRICE \t  COST");
                                Console.WriteLine("================================================");
                                var display = from inv1 in inventory
                                              select inv1;
                                foreach (var show in display)
                                {
                                    Console.WriteLine(show);
                                }
                                Console.WriteLine("Enter NumberOnHands:");
                                var noh = Convert.ToInt32(Console.ReadLine());

                                Console.WriteLine("Enter the Price:");
                                var pr = Convert.ToInt32(Console.ReadLine());

                                Console.WriteLine("Enter the Cost:");
                                var co = Convert.ToInt32(Console.ReadLine());

                                inventory.Add(new Inventory(inventory.Count, Vehicles.Count, noh, pr, co));
                                //Insert Query
                                var insertInv = from ins in inventory
                                                join m in Vehicles on ins.ID equals m.ID into vehicles
                                                select ins;
                                Console.WriteLine("|ID \t VEHICLEID NUMBERONHANDS PRICE \t  COST");
                                Console.WriteLine("================================================");
                                foreach (var inv in insertInv)
                                {
                                    Console.WriteLine(inv);
                                }
                                Console.WriteLine("\nYour Data Has Successfully added");
                            }
                            else if (choice3 == 2)
                            {
                                Console.WriteLine("|ID \t VEHICLEID NUMBERONHANDS PRICE \t  COST");
                                Console.WriteLine("================================================");
                                //Display data for Inventory class
                                var display = from inv1 in inventory
                                              select inv1;
                                foreach (var show in display)
                                {
                                    Console.WriteLine(show);
                                }

                                Console.WriteLine("Enter the VehicleId to view its Inventory Record :");
                                var vehId = Convert.ToInt32(Console.ReadLine());

                                if (vehId > Vehicles.Count || vehId < 0)
                                {
                                    Console.WriteLine("ID DOES NOT EXIT");
                                }
                                else
                                {
                                    var disp = from inv1 in inventory
                                               where inv1.VehicleId.Equals(vehId)
                                               select inv1;

                                    foreach (var d in disp)
                                    {
                                        Console.WriteLine(d);
                                    }
                                }
                            }
                            else if (choice3 == 3)
                            {
                                Console.WriteLine("|ID \t VEHICLEID NUMBERONHANDS PRICE \t  COST");
                                Console.WriteLine("================================================");
                                //display data.
                                var option = from inv1 in inventory
                                             select inv1;
                                foreach (var display in option)
                                {
                                    Console.WriteLine(display);
                                }
                               
                                Console.WriteLine("Enter a ID to update the Value");
                                var upt = Convert.ToInt32(Console.ReadLine());
                                if (upt > inventory.Count || upt < 0)
                                {
                                    Console.WriteLine("ID Does not Exit");
                                }
                                else
                                {
                                    Console.WriteLine("Enter NumbersOnHand");
                                    var noh = Convert.ToInt32(Console.ReadLine());

                                    Console.WriteLine("Enter Price:");
                                    var pr = Convert.ToInt32(Console.ReadLine());

                                    Console.WriteLine("Enter Cost");
                                    var Co = Convert.ToInt32(Console.ReadLine());


                                    //Update Query
                                    var uptQuery = from inv1 in inventory
                                                   where inv1.ID.Equals(upt)
                                                   select inv1;
                                    Console.WriteLine("|ID \t VEHICLEID NUMBERONHANDS PRICE \t  COST");
                                    Console.WriteLine("================================================");
                                    foreach (var uptitems in uptQuery)
                                    {
                                        uptitems.NumberOnHand = noh;
                                        uptitems.Price = pr;
                                        uptitems.Cost = Co;

                                        Console.WriteLine(uptitems);
                                    }
                                    Console.WriteLine("Your data has been updated successfully");
                                    //Select Query
                                    var selectQuery = from inv1 in inventory
                                                      select inv1;
                                    Console.WriteLine("|ID \t VEHICLEID NUMBERONHANDS PRICE \t  COST");
                                    Console.WriteLine("================================================");
                                    foreach (var select in selectQuery)
                                    {
                                        Console.WriteLine(select);
                                    }
                                    Console.WriteLine("Updated Data");

                                }
                            
                    }
                            else if (choice3 == 4)
                            {
                                Console.WriteLine("|ID \t VEHICLEID NUMBERONHANDS PRICE \t  COST");
                                Console.WriteLine("================================================");
                                //display data.
                                var option = from inv1 in inventory
                                             select inv1;
                                foreach (var display in option)
                                {
                                    Console.WriteLine(display);
                                }
                                Console.WriteLine("Enter Id to delete:");
                                var del = Convert.ToInt32(Console.ReadLine());
                                if (del > inventory.Count || del < 0)
                                {
                                    Console.WriteLine("ID Does Not Exit, Plese Enter Again");

                                }
                                else
                                {
                                    //Delete Query
                                    var dis = from inv1 in inventory
                                              where inv1.ID.Equals(del)
                                              select inv1;

                                    Vehicles.RemoveAt(Convert.ToInt32(del));
                                    Console.WriteLine("The Inventory Entry has sucuessfully Removed from the List");

                                    Console.WriteLine("|ID \t VEHICLEID NUMBERONHANDS PRICE \t  COST");
                                    Console.WriteLine("================================================");
                                    var selectDelete = from inv1 in inventory
                                                       select inv1;
                                    foreach (var sel in selectDelete)
                                        Console.WriteLine(sel);
                                }
                            }


                            break;

                        case 3:
                            Console.WriteLine("Press 1 to view all repair");
                            Console.WriteLine("Press 2 to Insert data to repair");
                            Console.WriteLine("Press 3 to Update data to repair");
                            Console.WriteLine("Press 4 to Delete data to repair");
                            Console.WriteLine("Press 5 return to the main menu");
                            var choice4 = Convert.ToInt32(Console.ReadLine());

                            if (choice4 == 1)
                            {
                                Console.WriteLine("|ID \t INVENTORY_ID WHATTOREPAIR");
                                Console.WriteLine("================================================");
                                var show = from rep in repair
                                           select rep;
                                foreach (var sh in show)
                                {
                                    Console.WriteLine(sh);
                                }
                            }
                            else if (choice4 == 2)
                            {

                                Console.WriteLine("|ID \t INVENTORY_ID WHATTOREPAIR");
                                Console.WriteLine("================================================");
                                //Displaying data for Repair Class.
                                var show = from rep in repair
                                           select rep;
                                foreach (var sh in show)
                                {
                                    Console.WriteLine(sh);
                                }

                                Console.WriteLine("Enter What to Repair:");
                                var wToRepair = Console.ReadLine();
                                int check1;
                                bool isNumber = int.TryParse(wToRepair, out check1);
                            
                                if ((wToRepair.Equals("") || isNumber || wToRepair.Length > 10) || (isNumber && wToRepair.Equals("")) || (isNumber && wToRepair.Length > 10) || (wToRepair.Equals("") || isNumber && wToRepair.Length > 10))
                                {
                                    Console.WriteLine("\nYou have entered wrong value!Please add valid value to insert Data");
                                }
                               else
                                {
                                    var addRepair = from rep in repair
                                                    where rep.WhatToRepair.Equals(wToRepair)
                                                    select rep;

                                    repair.Add(new Repair(repair.Count, inventory.Count, wToRepair));
                                    foreach (var add in addRepair)
                                    {
                                        Console.WriteLine(add);
                                    }
                                    Console.WriteLine("Data has been inserted successfully");

                                    Console.WriteLine("|ID \t INVENTORY_ID WHATTOREPAIR");
                                    Console.WriteLine("================================================");
                                    //Displaying data for Repair Class.
                                    var show1 = from rep in repair
                                                select rep;
                                    foreach (var sh in show1)
                                    {
                                        Console.WriteLine(sh);
                                    }

                                }
                            }
                            else if (choice4 == 3)
                            {
                                Console.WriteLine("|ID \t INVENTORY_ID WHATTOREPAIR");
                                Console.WriteLine("================================================");
                                //display data.
                                var option = from rep in repair
                                             select rep;
                                foreach (var display in option)
                                {
                                    Console.WriteLine(display);
                                }
                                //Vehicle veh = new Vehicle();
                                Console.WriteLine("Enter a ID to update the Value");
                                var upt = Convert.ToInt32(Console.ReadLine());
                                if (upt > repair.Count || upt < 0)
                                {
                                    Console.WriteLine("ID Does not Exit");
                                }
                                else
                                {
                                    Console.WriteLine("Enter What to Repair");
                                    var wR = Console.ReadLine();

                                    //Update Query
                                    var uptQuery = from rep in repair
                                                   where rep.ID.Equals(upt)
                                                   select rep;
                                    Console.WriteLine("|ID \t INVENTORY_ID WHATTOREPAIR");
                                    Console.WriteLine("================================================");
                                    foreach (var uptitems in uptQuery)
                                    {
                                        uptitems.WhatToRepair = wR;

                                        Console.WriteLine(uptitems);
                                    }
                                    Console.WriteLine("Your data has been updated successfully");
                                    //Select Query
                                    var selectQuery = from rep in repair
                                                      select rep;
                                    Console.WriteLine("|ID \t INVENTORY_ID WHATTOREPAIR");
                                    Console.WriteLine("================================================");
                                    foreach (var select in selectQuery)
                                    {
                                        Console.WriteLine(select);
                                    }
                                    Console.WriteLine("Updated Data");

                                }

                            }
                            else if (choice4 == 4)
                            {
                                Console.WriteLine("|ID \t INVENTORY_ID WHATTOREPAIR");
                                Console.WriteLine("================================================");
                                //display data.
                                var option = from rep in repair
                                             select rep;
                                foreach (var display in option)
                                {
                                    Console.WriteLine(display);
                                }
                                Console.WriteLine("Enter Id to delete:");
                                var del = Convert.ToInt32(Console.ReadLine());
                                if (del > repair.Count || del < 0)
                                {
                                    Console.WriteLine("ID Does Not Exit, Plese Enter Again");

                                }
                                else
                                {
                                    //Delete Query
                                    var dis = from rep in repair
                                              where rep.ID.Equals(del)
                                              select rep;

                                    repair.RemoveAt(Convert.ToInt32(del));
                                    Console.WriteLine("The Repair Entry has sucuessfully Removed from the List");

                                    Console.WriteLine("|ID \t INVENTORY_ID WHATTOREPAIR");
                                    Console.WriteLine("================================================");
                                    var selectDelete = from rep in repair
                                                       select rep;
                                    foreach (var sel in selectDelete)
                                        Console.WriteLine(sel);
                                }
                            }



                            break;

                        case 4:
                            Environment.Exit(0);
                            break;

                        default:
                            
                                Console.WriteLine("Selection is in Valid! Please Enter number Between 1 to 4");
                            break;

                      }//END OF SWITCH CASE
                   }// END OF TRY BLOCK
                     catch (FormatException) { 
                    Console.WriteLine("InValid Input! Please Enter correct Data to processed");
                }// END OF CATCH BLOCK
            } while (!check); // END OF DO WHILE LOOP
        }//END OF MAIN 
    }//END OF PROGRAM
}//END OF NAMESPACE

