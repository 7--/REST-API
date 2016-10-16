using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chp1_1
{
  class Async
  {
    public Task SleepAsyncA(int millisecondsTimeout)
    {
      return Task.Run(() => Thread.Sleep(millisecondsTimeout));
    }
    public Task SleepAsyncB(int millisecondsTimeout)
    {
      TaskCompletionSource<bool> tcs = null;
      var t = new Timer(delegate { tcs.TrySetResult(true); }, null, -1, -1);
      tcs = new TaskCompletionSource<bool>(t);
      t.Change(millisecondsTimeout, -1);
      return tcs.Task;
    }
    public async void Button_Click()
    {
      HttpClient httpClient = new HttpClient();
      string content = await httpClient
      .GetStringAsync("http://www.microsoft.com")
      .ConfigureAwait(false);
      Console.WriteLine(content);
    }
    public static void doSomething()
    {
      Console.WriteLine("doSomething method");
      NotStatic();
      new Async().NotStatic();
     
    }
    public void NotStatic()
    {

    }
  }
}
