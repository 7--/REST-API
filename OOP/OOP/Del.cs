using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
  class Del
  {
    int num = 10;
    public int AddNum(int p)
    {
      num += p;
      return num;
    }

    public int MultNum(int q)
    {
      num *= q;
      return num;
    }
    public int getNum()
    {
      return num;
    }
  }
}
