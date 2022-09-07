using System;

int input = getInput();
Console.WriteLine(reverseNumber(input));

int getInput()
{
    Console.Write("Input: ");
    string input = Console.ReadLine();
    int output;
    if (int.TryParse(input, out output)) return output;
    return getInput();
}

int reverseNumber (int input)
{
    return input * -1;
}
