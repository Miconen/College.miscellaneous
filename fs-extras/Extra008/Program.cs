using System;

Console.Write("How much money do you have?: ");
int moneys = int.Parse(Console.ReadLine());
Console.Write("Price of food: ");
int price = int.Parse(Console.ReadLine());
string response = (enoughMoney(moneys, price)) ? "Money left: " + Convert.ToString(moneys - price) : "Paastoamaan!";

Console.WriteLine($"{response}");

bool enoughMoney(int moneys, int price)
{
    return moneys >= price;
}
