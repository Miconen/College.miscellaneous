using System;
using System.Text.RegularExpressions;

public class Program
{
    public enum NumberIndex
    {
        One,
        Ten,
        Hundred,
        Thousand,
        Million,
        Billion,
    }

    public int CUTOFF_ONE = 1;
    public int CUTOFF_TEN = 2;
    public int CUTOFF_HUNDRED = 3;
    public int CUTOFF_THOUSAND = 4;
    public int CUTOFF_MILLION = 7;
    public int CUTOFF_BILLION = 10;

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

    public void numberConverter(string snumber)
    {
        int number = int.Parse(snumber);
        int numberSize = getIntSize(number);
        for (int i = snumber.Length; i < 0; i--)
        {
            NumberIndex index = sizeToIndex(i);
            Console.WriteLine(singleNumberToString(snumber[i], index));
        }
    }

    public string singleNumberToString(char digit, NumberIndex numberSize)
    {
        int num = digit - '0';
        string prefix = numberToString(num);
        string suffix = numberSizeToString((int)numberSize);
        return prefix + suffix;
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

    public string numberSizeToString(int number)
    {
        NumberIndex index = (NumberIndex)number;
        switch (index)
        {
            case (NumberIndex.Ten):
                return "kymmentä";
            case (NumberIndex.Hundred):
                return "sataa";
            case (NumberIndex.Thousand):
                return "tuhatta";
            case (NumberIndex.Million):
                return "miljoonaa";
            case (NumberIndex.Billion):
                return "miljardia";
            default:
                return "";
        }
    }

    public NumberIndex sizeToIndex(int number)
    {
        if (number == this.CUTOFF_ONE) return NumberIndex.One;
        if (number == this.CUTOFF_TEN) return NumberIndex.Ten;
        if (number == this.CUTOFF_HUNDRED) return NumberIndex.Hundred;
        if (number >= this.CUTOFF_THOUSAND && number <= this.CUTOFF_MILLION - 1) return NumberIndex.Thousand;
        if (number >= this.CUTOFF_MILLION && number <= this.CUTOFF_BILLION - 1) return NumberIndex.Million;
        return NumberIndex.Billion;
    }

    public bool matchIndex(int number)
    {
        if (number == this.CUTOFF_ONE) return true;
        if (number == this.CUTOFF_TEN) return true;
        if (number == this.CUTOFF_HUNDRED) return true;
        if (number == this.CUTOFF_THOUSAND) return true;
        if (number == this.CUTOFF_MILLION) return true;
        if (number == this.CUTOFF_BILLION) return true;
        return false;
    }

    public int getIntSize(int number)
    {
        int count = 0;
        // Keep going while the last digit is 0
        while (number > 0)
        {
            number = number / 10;
            count++;
        }

        return count;
    }

    public string getInput()
    {
        Console.Write("Give a string with numbers inside: ");
        string? input = Console.ReadLine();
        if (input == "" || input == null) return getInput();
        return input;
    }
}
