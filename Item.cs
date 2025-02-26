//Inheritence concept

using System;

namespace InventoryManagement{
    public class Item : Product {

        private int quantity;
        // getting the quantity of item of particular product.
        public int Quantity{
            get { return quantity;} 
            set{
                 if (value < 0)
                     throw new ArgumentException("Quantity cannot be negative");
                quantity = value;
            };
        }

        //giving the value to the quantity
        //base() is used to use the constructor of the parent class.
        public Item(string name,double price , int quantity) : base(name,price){
            Quantity = quantity;
        }
    }
}