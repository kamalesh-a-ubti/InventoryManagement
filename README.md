# INVENTORYMANAGEMENT

## Product.cs
using System;

namespace InventoryManagement{

    public class Product{ //O(1)
    //creating the variables to store the values passed through using constructor

    //encapsulation 
    private string name; //O(1) - 1
    private double price; //O(1) - 1

    public string Name { //O(1) - 1 
        //get is used to get the value of the name
        //set is used to set the value of the name
        get{return name;} //O(1) -1
        set{name = value;}//O(1) - 1
    }
    public double Price { //O(1) - 1 
        get{return price; } //O(1) -1
        set{
                 if (value < 0) //O(1) - 1 
                     throw new ArgumentException("Price cannot be negative"); //O(1) - 1
                price = value; //O(1) - 1
            }
    }


    //geting the values of the above variables using constructor
    public Product(string name , double price ){ //O(1) -1
        try{
            Name=name; //O(1) -1 
            Price=price; //O(1) - 1
        }
        catch(ArgumentException ex){ 1
            Console.WriteLine($"Error :{ex.Message}"); //O(1) - 2
        }
        finally{
            Console.WriteLine("Object got created"); //O(1) - 1
        }
    }

}
}

##Item.cs


//Inheritence concept

using System;

namespace InventoryManagement{
    public class Item : Product { //O(1) - 1

        private int quantity; //O(1) - 1
        // getting the quantity of item of particular product.
        public int Quantity{ //O(1) - 1
            get { return quantity;} //O(1) - 1
            set{
                 if (value < 0) //O(1) - 1
                     throw new ArgumentException("Quantity cannot be negative"); //O(1) - 1
                quantity = value; //O(1) - 1
            }
        }

        //giving the value to the quantity
        //base() is used to use the constructor of the parent class.
        public Item(string name,double price , int quantity) : base(name,price){
            try{
                Quantity = quantity; //O(1) - 1
            }
            catch (ArgumentException ex) //O(1) - 1
            {
                Console.WriteLine($"Error: {ex.Message}"); //O(1) - 2
            }
            finally{
                Console.WriteLine("Object got created"); //O(1) - 1
            }
        }
    }
}

## Program.cs

using System;

namespace InventoryManagement
{
    class Program
    {
        private static CalculateService calculate = new CalculateService();
        // Main method
        static void Main(string[] args)
        {
            while(true){
            try
            {
                // Taking the number of Items
                Console.WriteLine("Enter the number of Products:"); //O(1) - 1
                int noOfProducts = int.Parse(Console.ReadLine()); //O(1) - 3

                // Creating the array to store the details of items
                Item[] inventory = new Item[noOfProducts]; //O(n) - n

                // Getting the details of Items from inputs
                for (int i = 0; i < noOfProducts; i++) //O(n) -n
                {
                    Console.WriteLine($"Enter the details for Item {i + 1}:"); //O(1) - 2
                    // Name
                    Console.WriteLine("Item Name:"); //O(1) - 1
                    string name = Console.ReadLine(); //O(1) - 2
                    // Price
                    Console.WriteLine("Price:"); //O(1) - 1
                    double price = GetValidInt(); //O(1) - 3
                    // Quantity
                    Console.WriteLine("Quantity:"); //O(1) - 1
                    int quantity = GetValidDouble(); //O(1) - 3

                    // Putting them into array
                    inventory[i] = new Item(name, price, quantity); //O(1) - 1
                }

                // Calculating the total value of inventory
                double totalValue = calculate.CalculateTotalValue(inventory); //O(n) - n
                // Finding the highest quantity item
                Item highestQuantityItem = calculte.CalculateHighestItem(inventory); //O(n) - n

                // Printing both
                Console.WriteLine($"Total value of inventory: {totalValue}"); //O(1) - 2
                Console.WriteLine($"Item with the highest quantity: {highestQuantityItem.Name} (Quantity: {highestQuantityItem.Quantity})"); //O(1) - 3
                break;
            }
            catch (FormatException ex) //O(1) - 1
            {
                Console.WriteLine($"Input error: {ex.Message}"); //O(1) - 2
            }
            catch (ArgumentException ex) //O(1) - 1
            {
                Console.WriteLine($"Argument error: {ex.Message}"); //O(1) - 2
            }
            catch (Exception ex) //O(1) - 1
            {
                Console.WriteLine($"Unexpected error: {ex.Message}"); //O(1) - 2
            }
            finally
            {
                Console.WriteLine("Execution of Main method completed."); //O(1) - 1
            }}
        }

        static int GetValidInt()
        {
            while (true) -1
            {
                try
                {
                    return int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer:");
                }
                }   
        }
        //input handling of the double

        static double GetValidDouble()
        {
            while (true) -1
            {
                try
                {
                    return double.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number:");
                }
            }
        }

## CalculateService.cs


        public double CalculateTotalValue(Product[] inventory) //O(n) - n
        {
            double totalValue = 0; //O(1) - 1

            try
            {
                // Loop through the array and add the values to total value
                foreach (var product in inventory) //O(n) - n
                {
                    if (product is Item item) //O(1) - 1
                    {
                        totalValue += item.Price * item.Quantity; //O(1) - 1
                    }
                }
            }
            catch (Exception ex) //O(1) - 1
            {
                Console.WriteLine($"Error calculating total value: {ex.Message}"); //O(1) - 2
            }
            finally
            {
                Console.WriteLine("Execution of CalculateTotalValue method completed."); //O(1) - 1
            }

            // Return the total value
            return totalValue; //O(1) - 1
        }

        public Item CalculateHighestItem(Product[] inventory) //O(n) - n
        {
            Item highestQuantityItem = null; //O(1) - 1

            try
            {
                // Iterate through the array and find the highest quantity item
                foreach (var product in inventory) //O(n) - n
                {
                    // Check if the product is an item
                    if (product is Item item) //O(1) - 1
                    {
                        // Check for the highest quantity item
                        if (highestQuantityItem == null || item.Quantity > highestQuantityItem.Quantity) //O(1) - 2
                        {
                            highestQuantityItem = item; //O(1) - 1
                        }
                    }
                }
            }
            catch (Exception ex) //O(1) - 1
            {
                Console.WriteLine($"Error finding highest quantity item: {ex.Message}"); //O(1) - 2
            }
            finally
            {
                Console.WriteLine("Execution of CalculateHighestItem method completed."); //O(1) - 1
            }

            return highestQuantityItem; //O(1) - 1
        }
    }
}

##The total complexity  is O(n).