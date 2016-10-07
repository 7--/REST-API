using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.AccessControl;
using System.Web.Http;
using System.Runtime.Caching;
namespace REST.Controllers
{
  public class ColorController : ApiController
  {
    const string cacheString = "colorList";
    List<string>defaultColors = new List<string>(){ "Red", "Blue", "Purple", "Yellow", "Orange" };
    ObjectCache cache = MemoryCache.Default;
    CacheItemPolicy policy;
    public ColorController()
    {
      List<string> colors = cache[cacheString] as List<string>;
      if (colors == null)
      {
        policy = new CacheItemPolicy();
        policy.AbsoluteExpiration =
        DateTimeOffset.Now.AddDays(10);
        cache.Set("colorList", defaultColors, policy);
      }
    }

    [HttpGet]
    public HttpResponseMessage GetColors()
    {
      return Request.CreateResponse(HttpStatusCode.OK, cache[cacheString] as List<string>);
    }
    [HttpGet]
    public HttpResponseMessage GetColors(int id)
    {
      List<string> colors = cache[cacheString] as List<string>;
      if (id == 0)
      {
        return Request.CreateResponse(HttpStatusCode.OK, colors);
      }
      return Request.CreateResponse(HttpStatusCode.OK, colors.Take(id));
    }
    [HttpPost]
    public HttpResponseMessage PostColor([FromBody] Color color)
    {
      List<string> colors = cache[cacheString] as List<string>;
      colors.Add(color.Name);
      cache.Set("colorList", colors, policy);
      return Request.CreateResponse(HttpStatusCode.OK);
    }
    [HttpPut]
    public HttpResponseMessage PutColor([FromUri] int id,[FromBody] Color color)
    {
      List<string> colors = cache[cacheString] as List<string>;
      colors.Insert(id, color.Name);
      cache.Set("colorList", colors, policy);
      return Request.CreateResponse(HttpStatusCode.OK);
    }
    [HttpDelete]
    public HttpResponseMessage DeleteColor([FromUri] int id)
    {
      List<string> colors = cache[cacheString] as List<string>;
      colors.RemoveAt(id);
      cache.Set("colorList", colors, policy);
      return Request.CreateResponse(HttpStatusCode.OK);
    }
  }
}
