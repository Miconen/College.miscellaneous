using System;

namespace Exercise030
{
  public class Program
  {
    public static void Main(string[] args)
    {
      // Initialize all possible grades with their point ranges and grade
      Grade[] GRADING = new Grade[] {new Grade(0, 49, -1), new Grade(50, 59, 1), new Grade(60, 69, 2), new Grade(70, 79, 3), new Grade(80, 89, 4), new Grade(90, 100, 5)};

      // Get input
      Console.WriteLine("Give your percent [0 - 100]:");
      int percent = Convert.ToInt32(Console.ReadLine());

      // Weed out edge cases
      if (0 > percent) Console.Write("Impossible");
      if (100 < percent) Console.Write("Outstanding!");

      // Loop through each set of grades checking if our input falls in their range
      string res = "";
      foreach (Grade item in GRADING)
      {
        if (!item.InRange(percent)) continue;
        if (item.Grading == -1) res = "Fail";
        else res = $"Grade: {item.Grading}";
      }

      Console.WriteLine(res);
    }
  }

  public class Grade
  {
    public int Low;
    public int High;
    public int Grading;

    public Grade(int nLow, int nHigh, int nGrade)
    {
      Low = nLow;
      High = nHigh;
      Grading = nGrade;
    }

    public bool InRange(int percentage)
    {
      if (percentage >= this.Low && percentage <= this.High)
      {
        return true;
      }
      return false;
    }
  }
}
