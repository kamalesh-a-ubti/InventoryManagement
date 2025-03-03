using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.service
{
    public class CalculteService
    {
        public double CalculateTotalValue(Product[] inventory)
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
            finally
            {
                Console.WriteLine("Execution of CalculateTotalValue method completed.");
            }

            // Return the total value
            return totalValue;
        }

        public Item CalculateHighestItem(Product[] inventory)
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
            finally
            {
                Console.WriteLine("Execution of CalculateHighestItem method completed.");
            }

            return highestQuantityItem;
        }
    }
}