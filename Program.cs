using System;
using InventoryManagement.service;

namespace InventoryManagement
{
    class Program
    {
        // Main method
        private static CalculteService calculate = new CalculteService();
        static void Main(string[] args)
        {
            while(true){
                try
                {
                    // Taking the number of Items
                    Console.WriteLine("Enter the number of Products:");
                    int noOfProducts = int.Parse(Console.ReadLine());

                    // Creating the array to store the details of items
                    Item[] inventory = new Item[noOfProducts];

                    // Getting the details of Items from inputs
                    for (int i = 0; i < noOfProducts; i++)
                    {
                        Console.WriteLine($"Enter the details for Item {i + 1}:");
                        // Name
                        Console.WriteLine("Item Name:");
                        string name = Console.ReadLine();
                        // Price
                        Console.WriteLine("Price:");
                        double price = double.Parse(Console.ReadLine());
                        // Quantity
                        Console.WriteLine("Quantity:");
                        int quantity = int.Parse(Console.ReadLine());

                        // Putting them into array
                        inventory[i] = new Item(name, price, quantity);
                    }

                    // Calculating the total value of inventory
                    double totalValue = calculate.CalculateTotalValue(inventory);
                    // Finding the highest quantity item
                    Item highestQuantityItem = calculate.CalculateHighestItem(inventory);

                    // Printing both
                    Console.WriteLine($"Total value of inventory: {totalValue}");

                    Console.WriteLine($"Item with the highest quantity: {highestQuantityItem.Name} (Quantity: {highestQuantityItem.Quantity})");
                    break;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"Input error: {ex.Message}");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Argument error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Unexpected error: {ex.Message}");
                }
                finally
                {
                    Console.WriteLine("Execution of Main method completed.");
                }
            }
            
        }

        
    }
}
