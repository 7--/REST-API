using System;
using System.IO;

public class SomeClass
{
  public delegate int Calculate(int x, int y);
  public int Add(int x, int y) { return x + y; }
  public int Multiply(int x, int y) { return x * y; }
  public void No(int x, int y) { Console.WriteLine(); }
  public delegate void CovarianceDel(StreamWriter sw);
  public void Cov(TextWriter sw) { return; }
  public Action SomeAction { get; set; }
  public Func<int, int, int> SomeFunc { get; set; }
  public void UseDelegate()
  {

    Calculate a = Add;
    Console.WriteLine(a(1, 4));
    Calculate b = Multiply;
    a += Multiply;
    Delegate del = a.GetInvocationList()[0];
    Console.WriteLine(a(3, 5));
    a -= Multiply;
    Console.WriteLine(a(3, 5));
    a = (x, y) => (x * y);
    a = (x, y) => { x = 2 * 2; return x + y; };
    Func<int, int, int> fun = Add;
    Action<int, int> calc = (x, y) =>
    {
      Console.WriteLine(x + y);
    };
    CovarianceDel cd = Cov;

    SomeAction += () => Console.WriteLine("Action event ");
    SomeFunc += (x, y) => { return (x + y); };
  }
  public class MyArgs : EventArgs
  {
    public int Value { get; set; }
    public MyArgs(int value)
    {
      Value = value;
    }
  }
  public class Pub
  {
    public event EventHandler<MyArgs> OnChange = delegate{};
    public void Raise()
    {
      OnChange(this, new MyArgs(42));
    }
  }

  public static void Main()
  {
    SomeClass sc = new SomeClass();
    sc.UseDelegate();


    Pub p = new Pub();
    p.OnChange += (sender, e)
    => Console.WriteLine("Event raised: {0}", e.Value);
    p.OnChange += (sender, e)
   => Console.WriteLine("Event raised: {0}", e.Value);
    p.Raise();
    p.Raise();

    Console.Read();
  }
}
