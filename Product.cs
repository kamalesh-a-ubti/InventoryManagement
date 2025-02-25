using System;

namespace InventoryManagement{

    public class Product{
    //creating the variables to store the values passed through using constructor
    public string Name {
        //get is used to get the value of the name
        //set is used to set the value of the name
        get;set;
    }
    public double Price {
        get;set;
    }


    //geting the values of the above variables using constructor
    public Product(string name , double price ){
        Name=name;
        Price=price;
    }

}
}