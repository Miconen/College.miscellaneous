using System;
using System.Collections.Generic;

Dictionary<int, string> dict = new Dictionary<int, string>();

dict.Add(0, "hylätty");
dict.Add(1, "välttävä");
dict.Add(2, "tyydyttävä");
dict.Add(3, "hyvä");
dict.Add(4, "kiitettävä");
dict.Add(5, "erinomainen");

Console.Write("Give a number (0-5): ");
int dictKey = int.Parse(Console.ReadLine());
if (dict.ContainsKey(dictKey))
{
    string response = dict[dictKey];
    Console.WriteLine(response);
}
else
{
    Console.WriteLine("Invalid input");
}
