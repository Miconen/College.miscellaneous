using System;
using System.Text.RegularExpressions;

public class Program
{
    public static void Main(string[] args)
    {
        Program p = new Program();
        string match = p.getInput();
        // Match all numbers in string
        string pattern = @"\d+";
        Regex rx = new Regex(pattern);
        MatchCollection matches = rx.Matches(match);

        for (int count = 0; count < matches.Count; count++)  
        {
            p.numberConverter(matches[count].Value); 
        }
    }

    public void numberConverter(string sNumber)
    {
        // Holds and sends three numbers at a time to get "translated" to a string
        // This makes the translation process easier
        int[] numberTriplet = new int[3];
        string parsedResponse = "";
        for (int count = 0; count < sNumber.Length; count++)  
        {
            int nthRun = count + 1;
            numberTriplet[count % 3] = sNumber[count] - '0';
            // Assemble and send triplets forward to be parsed
            if (nthRun % 3 == 0)
            {
                // Round lenght down to closest number dividable by three
                int closestTriplet = (sNumber.Length - count) - (sNumber.Length - count) % 3;
                parsedResponse += tripletToString(numberTriplet, closestTriplet / 3);
                Array.Clear(numberTriplet, 0, numberTriplet.Length);
            }
            // Recover last numbers of input that didn't end up being a full triplet
            else if (nthRun == sNumber.Length)
            {
                Array.Clear(numberTriplet, 0, numberTriplet.Length);
                if (nthRun % 3 == 1)
                {
                    numberTriplet[2] = sNumber[count] - '0';
                }
                else if (nthRun % 3 == 2)
                {
                    numberTriplet[1] = sNumber[count - 1] - '0';
                    numberTriplet[2] = sNumber[count] - '0';
                }
                // Send numberTriplet forward if we are on the third OR the last iteration.
                // Round lenght down to closest number dividable by three
                int closestTriplet = (sNumber.Length - count) - (sNumber.Length - count) % 3;
                parsedResponse += tripletToString(numberTriplet, closestTriplet / 3);
            }
        }

        Console.WriteLine(parsedResponse);
    }

    public string tripletToString(int[] triplet, int nthRun)
    {
        string response = "";
        // Nth digit in number, IE 3 would be the 3rd number of 321 and 2 the second etc.
        int suffix = 2;
        foreach (int digit in triplet)
        {
            string format = "";
            // First filter out the weird grammatical edgecases in the Finnish language
            // Weed out leading zeros in hundreths place
            if (suffix == 2 && digit == 0)
            {
                response += "";
            }
            // Weed out leading zeros in tenths place if hundreths place is zero aswell
            else if (suffix == 1 && digit == 0 && triplet[0] == 0)
            {
                response += "";
            }
            // Singular hundreth place
            else if (suffix == 2 && digit == 1)
            {
                response += "sata";
            }
            // Handle spelling of numbers between 11-19
            else if (triplet[1] == 1 && triplet[2] != 0 && suffix != 2)
            {
                if (suffix == 0) response += $"{numberToString(digit)}toista";
            }
            else if (suffix == 1 && digit == 1)
            {
                response += "kymmenen";
            }
            // If triplet == [0, 0, 1], don't add formatting. Instead add a special fuffix at the end
            else if (nthRun > 0 && triplet[0] == 0 && triplet[1] == 0 && triplet[2] == 1)
            {
                response += "";
            }
            // Print the default format if no weird grammatical edgecases were met
            else 
            {
                response += $"{numberToString(digit)}{getTripletSuffix(suffix)}";
            }
            suffix--;
        }
        
        // If triplet == [0, 0, 1] return singular suffix, used as a prefix in this case. IE "TUHAT viisisataa"
        response += (nthRun > 0 && response == "") ? getSingularNumberSuffix(nthRun) : getNumberSuffix(nthRun);

        return response + " ";
    }

    public string getTripletSuffix(int suffix)
    {
        switch (suffix)
        {
            case (1):
                return "kymmentä";
            case (2):
                return "sataa";
            default:
                return "";
        }
    }

    public string numberToString(int number)
    {
        switch (number)
        {
            case (1):
                return "yksi";
            case (2):
                return "kaksi";
            case (3):
                return "kolme";
            case (4):
                return "neljä";
            case (5):
                return "viisi";
            case (6):
                return "kuusi";
            case (7):
                return "seitsemän";
            case (8):
                return "kahdeksan";
            case (9):
                return "yhdeksän";
            default:
                return "";
        }
    }

    public string getNumberSuffix(int suffix)
    {
        switch (suffix)
        {
            case (1):
                return "tuhatta";
            case (2):
                return "miljoonaa";
            case (3):
                return "miljardia";
            default:
                return "";
        }
    }

    public string getSingularNumberSuffix(int suffix)
    {
        switch (suffix)
        {
            case (1):
                return "tuhat";
            case (2):
                return "miljoona";
            case (3):
                return "miljardi";
            default:
                return "";
        }
    }

    public string getInput()
    {
        Console.Write("Give a string with numbers inside: ");
        string? input = Console.ReadLine();
        if (input == "" || input == null) return getInput();
        return input;
    }
}
