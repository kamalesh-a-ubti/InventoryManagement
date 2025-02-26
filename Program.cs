using System;

namespace InventoryManagement
{
    class Program
    {
        // Main method
        static void Main(string[] args)
        {
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
                double totalValue = CalculateTotalValue(inventory);
                // Finding the highest quantity item
                Item highestQuantityItem = CalculateHighestItem(inventory);

                // Printing both
                Console.WriteLine($"Total value of inventory: {totalValue}");
                Console.WriteLine($"Item with the highest quantity: {highestQuantityItem.Name} (Quantity: {highestQuantityItem.Quantity})");
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
        }

        static double CalculateTotalValue(Product[] inventory)
        {
            double totalValue = 0;

            try
            {
                // Loop through the array and add the values to total value
                foreach (var product in inventory)
                {
                    if (product is Item item)
                    {
                        totalValue += item.Price * item.Quantity;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error calculating total value: {ex.Message}");
            }

            // Return the total value
            return totalValue;
        }

        static Item CalculateHighestItem(Product[] inventory)
        {
            Item highestQuantityItem = null;

            try
            {
                // Iterate through the array and find the highest quantity item
                foreach (var product in inventory)
                {
                    // Check if the product is an item
                    if (product is Item item)
                    {
                        // Check for the highest quantity item
                        if (highestQuantityItem == null || item.Quantity > highestQuantityItem.Quantity)
                        {
                            highestQuantityItem = item;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error finding highest quantity item: {ex.Message}");
            }

            return highestQuantityItem;
        }
    }
}
