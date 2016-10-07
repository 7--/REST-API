using System;

delegate int NumberChanger(int n);
delegate int NumberChanger2(int n);
namespace OOP
{
  interface IPoint
  {
    // Property signatures:
    int x
    {
      get;
      set;
    }

    int y
    {
      get;
      set;
    }
  }
  interface INothing
  {

  }

  class Something : Point
  {
    public Something(int x, int y) : base(x,y)
    {
    }
    public  override int method(int e)
    {
      return e;
    }
  }
  class Point : IPoint, INothing
  {
    public virtual int method(int e)
    {
      return 0;
    }
    public  double method(double a)
    {
      return 0D;
    }
    // Fields:
    private int _x;
    private int _y;

    // Constructor:
    public Point(int x, int y)
    {
      _x = x;
      _y = y;
    }

    // Property implementation:
    public int x
    {
      get
      {
        return _x;
      }

      set
      {
        _x = value;
      }
    }

    public int y
    {
      get
      {
        return _y;
      }
      set
      {
        _y = value;
      }
    }
  }

  class MainClass
  {
    static void PrintPoint(IPoint p)
    {
      Console.WriteLine("x={0}, y={1}", p.x, p.y);
    }

    static void Main()
    {
      string[] s = { "1", "2" };
      foreach (string str in s)
      {
        string sss = str;
      }

      Point p = new Point(2, 3);
      Console.Write("My Point: ");
      PrintPoint(p);
      Console.ReadLine();
    }
  }
  // Output: My Point: x=2, y=3
}