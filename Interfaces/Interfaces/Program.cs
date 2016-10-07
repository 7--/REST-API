using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Threading;

namespace SimpleCSConsole
{
  class Foo
  {
    public Bar GetEnumerator() => new Bar();

    public class Bar
    {
      int _count = 0;
      public bool MoveNext() => ++_count < 10;
      public object Current => _count;
    }
  }

  class Program
  {

    void Run()
    {
      var foo = new Foo();
      foreach (var bar in foo)
        Console.WriteLine(bar);
    }

    static void Main()
    {
      new Program().Run();
      Console.ReadKey();
    }
  }
}
