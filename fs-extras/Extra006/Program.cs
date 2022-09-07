using System;
using System.Collections.Generic;

int loopAmount = GetInput();
FizzBuzz(1, loopAmount);

int FizzBuzz(int i, int ii)
{
    string response = "";
    if (i % 15 == 0)
    {
        response = "Fire and Electric";
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine(i + " " + response);
        Console.ResetColor();
    }
    else if (i % 5 == 0)
    {
        response = "Electric";
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(i + " " + response);
        Console.ResetColor();
    }
    else if (i % 3 == 0)
    {
        response = "Fire";
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(i + " " + response);
        Console.ResetColor();
    }
    else
    {
        response = "Normal";
        Console.WriteLine(i + " " + response);
            
    } 
    if (i == ii) return i;
    return FizzBuzz(i + 1, loopAmount);
}

int GetInput()
{
    Console.Write("Input a number: ");
    string input = Console.ReadLine();

    // When input is an integer, break from recursive loop
    if (int.TryParse(input, out int res)) return res;

    // Recursively ask for integer
    return GetInput();
}
