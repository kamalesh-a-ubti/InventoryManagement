using System;

namespace InventoryManagement{

    class Program{

        //main method
        static void Main(string[] args){

            //Taking the no of Items
            Console.WriteLine("Enter the no of Products :");
            int noOfProducts = int.Parse(Console.ReadLine());

            //creating the array to store the details of items
            Item[] inventory = new Item[noOfProducts];

            //Getting the details of Items from inputs
            for (int i=0 ; i < noOfProducts ; i++){
                Console.WriteLine($"Enter the details for Item {i+1} :");
                //name
                Console.WriteLine("ItemName : ");
                string name = Console.ReadLine();
                //price
                Console.WriteLine("Price :");
                double price = double.Parse(Console.ReadLine());
                //quantity
                Console.WriteLine("Quantity : ");
                int quantity = int.Parse(Console.ReadLine());

                //putting them into array
                inventory[i]=new Item(name,price,quantity);

            } 

            //calculating the totalvalue of inventory
            double totalValue = calculateTotalValue(inventory);
            //Finding the highest quantity item
            Item highestQuantityItem = calculateHighestItem(inventory);

            //printing the both.
            Console.WriteLine($"Total value of inventory: {totalValue}");
            Console.WriteLine($"Item with the highest quantity: {highestQuantityItem.Name} (Quantity: {highestQuantityItem.Quantity})");
        }

        static double calculateTotalValue(Product[] inventory){

            //intialising the totalvalue as zero
            double totalvalue = 0;

            //now loop through the array and then add the values to totalvalue
            foreach(var product in inventory){
                if(product is Item item ){
                    totalvalue+=item.Price * item.Quantity; 
                }
            }

            //return the total value
            return totalvalue;
        }

        static Item calculateHighestItem(Product[] inventory){

            //initialize the item as null
            Item highestQuantityItem = null;

            //iterate through the array and find the highest quantity item

            foreach(var product in inventory){
                //check the product is item
                if (product is Item item){
                    //check the highest Quantity item
                    if(highestQuantityItem==null || item.Quantity>highestQuantityItem.Quantity){
                        highestQuantityItem=item;
                    }
                }
            }

            return highestQuantityItem;
        }
    }
}


