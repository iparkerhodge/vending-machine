using System;
using System.Collections.Generic;
using System.Linq;

namespace Vending {
    class Program {
        static void Main (string[] args) {
            Console.WriteLine ("Welcome to the Vending Machine!");

            VendingMachine machine = new VendingMachine ();

            while (true) {
                Console.WriteLine ();

                int selection = Menu ();
                switch (selection) {
                    case 1:
                        List<Product> allProudcts = machine.GetAll ();
                        Console.WriteLine ("All Products:");
                        foreach (Product p in allProudcts) {
                            p.Display ();
                        }
                        Console.WriteLine ($"Total Count: {allProudcts.Count}");
                        break;
                    case 2:
                        List<string> names = machine.GetProductNames ();
                        Console.WriteLine ("All Product Names:");
                        foreach (string name in names) {
                            Console.WriteLine ($" {name}");
                        }
                        break;
                    case 3:
                        Console.Write ("Name> ");
                        string nameCriteria = Console.ReadLine ();
                        List<Product> productsByName = machine.SearchByName (nameCriteria);

                        if (productsByName.Any ()) {
                            Console.WriteLine ("Results:");
                            foreach (Product p in productsByName) {
                                Console.Write (" ");
                                p.Display ();
                            }
                        } else {
                            Console.WriteLine ("Product not found.");
                        }
                        break;
                    case 4:
                        Console.Write ("Min Price> ");
                        string strMin = Console.ReadLine ();
                        double min = double.Parse (strMin);
                        Console.Write ("Max Price> ");
                        string strMax = Console.ReadLine ();
                        double max = double.Parse (strMax);

                        List<Product> productsByPrice = machine.SearchByPrice (min, max);

                        Console.WriteLine ("Results:");
                        foreach (Product p in productsByPrice) {
                            Console.Write (" ");
                            p.Display ();
                        }
                        break;
                    case 5:
                        Product cheapest = machine.GetCheapest ();
                        cheapest.Display ();
                        break;
                    case 6:
                        Product expensive = machine.GetMostExpensive ();
                        expensive.Display ();
                        break;
                    case 7:
                        Console.Write ("Product ID> ");
                        int productId = int.Parse (Console.ReadLine ());
                        Product productToPurchase = machine.GetById (productId);
                        if (productToPurchase != null) {
                            machine.RemoveProduct (productToPurchase);
                        }
                        break;
                    case 8:
                        Console.WriteLine ("Enter Product Details");

                        Console.Write ("ID> ");
                        int newId = int.Parse (Console.ReadLine ());

                        Console.Write ("Name> ");
                        string newName = Console.ReadLine ();

                        Console.Write ("Price> ");
                        double newPrice = double.Parse (Console.ReadLine ());

                        Product newProduct = new Product () {
                            Id = newId,
                            Name = newName,
                            Price = newPrice,
                        };
                        machine.AddProduct (newProduct);
                        break;
                    case 9:
                        Console.WriteLine ($"Total Value: {machine.TotalValue}");
                        break;
                    case 0:
                        Console.WriteLine ("Goodbye");
                        return;
                    default:
                        throw new Exception ("Something went wrong...invalid selection");
                }
            }
        }

        static int Menu () {
            int selection = -1;

            while (selection < 0 || selection > 9) {
                Console.WriteLine ("Main Menu");
                Console.WriteLine (" 1) View All (ordered by price)");
                Console.WriteLine (" 2) View All Names (ordered alphabetically)");
                Console.WriteLine (" 3) Search by Name");
                Console.WriteLine (" 4) Search by Price");
                Console.WriteLine (" 5) Find Cheapest");
                Console.WriteLine (" 6) Find Most Expensive");
                Console.WriteLine (" 7) Purchase Product");
                Console.WriteLine (" 8) Add Product");
                Console.WriteLine (" 9) Total Machine Value");
                Console.WriteLine (" 0) Exit");

                Console.Write ("> ");
                string choice = Console.ReadLine ();
                try {
                    selection = int.Parse (choice);
                } catch {
                    Console.WriteLine ("Invalid Selection. Please try again.");
                }
                Console.WriteLine ();
            }

            return selection;
        }
    }
}