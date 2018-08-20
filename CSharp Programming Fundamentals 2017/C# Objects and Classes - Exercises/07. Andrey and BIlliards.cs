using System;
using System.Collections.Generic;
using System.Linq;
 
namespace _07_Andrey_and_Billiard
{
    public class Andrey¿ndBilliard
    {
        public static void Main()
        {
            //Read all shop items
            int entities = int.Parse(Console.ReadLine());
            var shop = new Dictionary<string, decimal>();
            for (int entitiesCntIndex = 1; entitiesCntIndex <= entities; entitiesCntIndex++)
            {
                var tokens = Console.ReadLine().Split('-').ToArray();
                string product = tokens[0];
                decimal price = decimal.Parse(tokens[1]);
 
                if (shop.ContainsKey(product))
                {
                    shop[product] = price;
                }
                else
                {
                    shop.Add(product, price);
                }
            }
 
            //Read all customers
            string line = Console.ReadLine();
            List<Customer> customers = new List<Customer>();
            while (line != "end of clients")
            {
                var tokens = line.Split(new char[] { '-', ',' }).ToArray();
 
                //Get customer info
                string customerName = tokens[0];
                string customerProduct = tokens[1];
                int customerQuantity = int.Parse(tokens[2]);
 
                if (shop.ContainsKey(customerProduct))
                {
                    var customerShopList = new Dictionary<string, int>();
                    customerShopList.Add(customerProduct, customerQuantity);
                    decimal customerBill = shop[customerProduct] * customerQuantity;
 
                    var customer = new Customer(customerName, customerShopList, customerBill);
 
                    //If the user has been made a purchase already
                    if (customers.Any(x=>x.Name == customerName))
                    {
                        var currentCustomer = customers.First(x => x.Name == customerName);
 
                        if (currentCustomer.ShopList.ContainsKey(customerProduct))
                        {
                            //If the user re-purchase an item 
                            currentCustomer.ShopList[customerProduct] += customerQuantity;
                            currentCustomer.Bill += shop[customerProduct] * customerQuantity;
                        }
                        else
                        {
                            //If the user make a new order
                            currentCustomer.ShopList[customerProduct] = customerQuantity;
                            currentCustomer.Bill += shop[customerProduct] * customerQuantity;
                        }
                    }
                    else
                    {
                        customers.Add(customer);
                    }
                }
 
                line = Console.ReadLine();
            }
 
            //Print all customers and total bill
            foreach (var customer in customers.OrderBy(x => x.Name))
            {
                Console.WriteLine($"{customer.Name}");
                foreach (var shoplist in customer.ShopList)
                {
                    var product = shoplist.Key;
                    var quantitiy = shoplist.Value;
                    Console.WriteLine($"-- {product} - {quantitiy}");
                }
                Console.WriteLine($"Bill: {customer.Bill:f2}");
            }
            Console.WriteLine($"Total bill: {customers.Sum(x=>x.Bill):f2}");
        }
 
        class Customer
        {
            public Customer(string name, Dictionary<string, int> shopList, decimal bill)
            {
                Name = name;
                ShopList = shopList;
                Bill = bill;
            }
 
            public string Name { get; set; }
 
            public Dictionary<string, int> ShopList { get; set; }
 
            public decimal Bill { get; set; }
        }
    }
}