using System;

double CALORIE_TO_JOULE = 4.184;
double JOULE_TO_CALORIE = 0.2390;

int input = getMethodInput();
double result = 0;
if (input == 1) result = energyConverter(CALORIE_TO_JOULE);
if (input == 2) result = energyConverter(JOULE_TO_CALORIE);
Console.WriteLine(result);

int getMethodInput()
{
    Console.WriteLine("Select an option:\n1 ) Calories to joules\n2 ) Joules to calories");
    string input = Console.ReadLine();
    int output;
    if (!int.TryParse(input, out output)) return getMethodInput();
    if (output != 1 && output != 2) return getMethodInput();
    return output;
}

double getConverstionInput()
{
    Console.Write("Input amount to convert: ");
    string input = Console.ReadLine();
    double output;
    if (!double.TryParse(input, out output)) return getConverstionInput();
    return output;
}

double energyConverter(double formula)
{
    double amount = getConverstionInput();
    return (double)amount * formula;
}
