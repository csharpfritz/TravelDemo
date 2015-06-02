using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Owin;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace TravelDemo.Secret
{
  public static class Extensions
  {

    public static void AddUserSecrets(this IAppBuilder app)
    {

      var thisContext = HttpContext.Current;
      var secretLocation = thisContext.Server.MapPath("~/usersecret.json");
      if (!File.Exists(secretLocation)) return;

      using (var file = File.OpenText(secretLocation))
      {
        using (var rdr = new JsonTextReader(file))
        {

          var secrets = (JObject)JToken.ReadFrom(rdr);

          if (secrets["appSettings"] != null)
          {
            var appSettings = secrets["appSettings"];
            foreach (var item in appSettings.Children())
            {
              ConfigurationManager.AppSettings.Set(item["name"].Value<string>(), item["value"].Value<string>());
            }
          }

        }
      }


    } 

  }
}
