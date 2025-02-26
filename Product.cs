using System;

namespace InventoryManagement{

    public class Product{
    //creating the variables to store the values passed through using constructor

    //encapsulation 
    private string name;
    private double price;

    public string Name {
        //get is used to get the value of the name
        //set is used to set the value of the name
        get{return name;}
        set{name = value;}
    }
    public double Price {
        get{return price; }
        set{
                 if (value < 0)
                     throw new ArgumentException("Price cannot be negative");
                price = value;
            }
    }


    //geting the values of the above variables using constructor
    public Product(string name , double price ){
        try{
            Name=name;
            Price=price;
        }
        catch(ArgumentException ex){
            Console.WriteLine($"Error :{ex.Message}");
        }
    }

}
}