using System;

Console.Write("How much money do you have?: ");
double moneys = double.Parse(Console.ReadLine());
Console.Write("Price of food: ");
double price = double.Parse(Console.ReadLine());
string response = (enoughMoney(moneys, price)) ? "Money left: " + Convert.ToString(moneys - price) : "Paastoamaan!";

Console.WriteLine($"{response}");

bool enoughMoney(double moneys, double price)
{
    return moneys >= price;
}
