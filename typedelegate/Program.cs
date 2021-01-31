using System;
using System.Linq;

public class Program
{
    static void  ReverseString(string s)
    {
        var str= new string(s.Reverse().ToArray());
	Console.WriteLine(str);
    }

    static void PrintString(string s)
    {
	Console.WriteLine(s);
    }

    static void Main(string[] args)
    {
        Action<string> rev = ReverseString;
	Action<string> pri = PrintString;
	Action<string> comb = (Action<string>)Delegate.Combine(rev, pri);
	comb("Hello World!");
    }
}
