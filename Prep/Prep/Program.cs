using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prep
{
  class Program
  {
    static void Main(string[] args)
    {
      string[] array = new string[]
      {
        "Hello",
        "Something",
        "Another"
      };
      var a = array.Where(s => s.Equals("Something"));
      Console.WriteLine(a.First());
      Console.WriteLine(fib(0, 1, 0));
      Console.WriteLine(fib(0, 1, 1));
      Console.WriteLine(fib(0, 1, 2));
      Console.WriteLine(fib(0, 1, 3));
      Console.WriteLine(fib(0, 1, 4));

      //var list = fib(new List<int>(), 10);
      //foreach(int item in list)
      //{
      //  Console.WriteLine(item);
      //}
      Console.WriteLine(fib(1));
      Console.WriteLine(fib(2));

      Console.WriteLine(fib(3));
      Console.WriteLine(fib(4));
      Console.WriteLine(fib(5));
      Console.WriteLine(fib(6));
      Console.WriteLine(fib(7));
      //1,2,3
      int[] a1 = new int[] { 1, 2, 3, 4, 5, 3, 4, 9 };
      int[] a2 = new int[] { 4, 5, 1, 6, 7, 2, 8, 9 };
      Console.WriteLine(findInFirstNotSecond(a1, a2));

      string[] s1 = new string[] { "Hey", "word", "something", "else" };
      string[] s2 = new string[] { "Hey", "word1", "something", "else1" };
      List<string> listS = ListOfDuplicates(s1, s2);
      foreach (string item in listS)
      {
        Console.WriteLine(item);
      }

      string st = "hello";
      Console.WriteLine(   st[0] + "ok");
      //Console.WriteLine(ReverseString(new StringBuilder("Hello".con)));
      string str = "HeyLove";
      Console.WriteLine(  ReverseString(str));
      Console.Read();
    }
    private static string ReverseString(string s)
    {
      if (s.Length == 1)
      {
        return s;
      }
      if (s.Length == 2)
      {
        return s[0].ToString() + s[1].ToString();
      }
      return s[s.Length-1]+ReverseString(s.Substring(1,s.Length-2))+s[0];
    }
    private static List<string> ListOfDuplicates(string[] s1, string[] s2)
    {
      List<string> duplicates = new List<string>();
      for (int i = 0; i < s1.Length; i++)
      {
        for (int i2 = 0; i2 < s2.Length; i2++)
        {
          if (s1[i] == s2[i2])
          {
            duplicates.Add(s1[i]);
          }
        }
      }
      return duplicates;
    }

    //public static string Reverse(string str)
    //{

    //}

    public static int findInFirstNotSecond(int[] a1, int[] a2)
    {
      bool found = false;
      for (int i = 0; i < a1.Length; i++)
      {
        for (int i2 = 0; i2 < a2.Length; i2++)
        {
          if (a1[i] == a2[i2])
          {
            found = true;
          }
        }
        if (found == false)
        {
          return a1[i];
        }
        found = false;
      }
      return -1;
    }
    private static int fac(int number)
    {
      return number * (number - 1);
    }
    private static int fib(int first, int second, int index)
    {
      if (index == 0)
        return first;
      return fib(second, first + second, index - 1);
    }
    private static int fib(int x)
    {
      if (x == 0 || x == 1)
      {
        return x;
      }
      return fib(x - 1) + fib(x - 2);
    }
    //private static int fib(int x)
    //{
    //  if (x <= 0)
    //  {
    //    return 0;
    //  }
    //  if (x == 2 )
    //  {
    //    return 1;
    //  }
    //  return fib(x-2) + fib(x-1);
    //}
    private static List<int> fib(List<int> seq, int upTo)
    {
      if (upTo == 0)
      {
        return seq;
      }
      seq.Add(seq.ElementAt(seq.Count() - 1) + seq.ElementAt(seq.Count() - 2));
      return fib(seq, upTo - 1);
    }
  }
}
