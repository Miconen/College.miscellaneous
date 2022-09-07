using System;

int PIN_MAX_ATTEMPTS = 3;
int PIN_LENGTH = 4;
int PUK_MAX_ATTEMPTS = 3;
int PUK_LENGTH = 8;

int pin_attempts = 0;
Console.WriteLine("Insert your PIN");
string pin = getInput(PIN_LENGTH, pin_attempts, PIN_MAX_ATTEMPTS);
if (pin == "") return;

int puk_attempts = 0;
Console.WriteLine("Insert your PUK");
string puk = getInput(PUK_LENGTH, puk_attempts, PUK_MAX_ATTEMPTS);
if (puk == "") return;

Console.WriteLine(pin + " " + puk);

string getInput(int ruleLength, int attempts, int maxAttempts)
{
    if (attempts == maxAttempts) return ""; 

    Console.Write($"(Attempts left {maxAttempts - attempts}): ");
    string input = Console.ReadLine();

    if (input.Length != ruleLength) return getInput (ruleLength, attempts + 1, maxAttempts);
    if (!input.All(Char.IsDigit)) return getInput (ruleLength, attempts + 1, maxAttempts);

    return input;
}
