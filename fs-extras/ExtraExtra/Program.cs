using System;
using Game;

namespace Game
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Program p = new Program();
            // Player 1
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Player 1 turn.");
            Console.ResetColor();

            int dragonDistance = getInput("How far is the dragon from the city?: ");

            // Set up game objects
            Dragon dragon = new Dragon(10, dragonDistance);
            City city = new City(15);

            // Player 2, game loop
            bool result = gameLoop(1, dragon, city, 0);
            Console.Clear();
            // true = win, false = loss
            if (result) Console.WriteLine("You won!");
            else Console.WriteLine("You lost.");
        }

        public static bool gameLoop(int round, Dragon dragon, City city, int lastShot)
        {
            // Update game objects
            city.Update(round);
            // dragon.Update(round);

            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Player 2 turn.");
            Console.ResetColor();

            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine($"SITUATION: Round: {round} City: {city.health}/{city.maxHealth} Dragon: {dragon.health}/{dragon.maxHealth}");

            // Handle cannon shots
            if (lastShot > dragon.distance)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Too high");
                Console.ResetColor();
            }
            else if (lastShot < dragon.distance)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Too low");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Hit");
                Console.ResetColor();
            }

            Console.WriteLine("");

            // Cannon text
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Cannon will deal {city.damage} this round.");
            Console.ResetColor();

            int shot = getInput("Next cannon shot at: ");

            // Damage calculations, return if either entity dies
            bool isHit = (shot == dragon.distance) ? true : false;
            if (isHit) city.Attack(dragon);
            if (dragon.Dead()) return true;
            dragon.Attack(city);
            if (city.Dead()) return false;

            round += 1;
            return gameLoop(round, dragon, city, shot);
        }

        public static int getInput(string message)
        {
            Console.Write($"{message}: ");

            Console.ForegroundColor = ConsoleColor.Blue;
            string? input = Console.ReadLine();
            Console.ResetColor();

            if (!int.TryParse(input, out int output)) return getInput(message);
            if (!inValidRange(output)) return getInput(message);
            return output;
        }

        public static bool inValidRange(int value)
        {
            bool response = false;
            if (value > 0 && value <= 100) response = true;
            return response;
        }
    }
}
