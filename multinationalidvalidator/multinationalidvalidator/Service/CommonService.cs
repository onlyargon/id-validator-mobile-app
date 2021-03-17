using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using multinationalidvalidator.Models.Country;
using Newtonsoft.Json;

namespace multinationalidvalidator.Service
{
    public class CommonService
    {
        public List<Country> GetCountries()
        {
            var assembly = typeof(CommonService).GetTypeInfo().Assembly;
            foreach (var res in assembly.GetManifestResourceNames())
            {
                if (res.Contains("CountryList.json"))
                {
                    Stream stream = assembly.GetManifestResourceStream(res);

                    using (var reader = new StreamReader(stream))
                    {
                        string json = reader.ReadToEnd();
                        return JsonConvert.DeserializeObject<List<Country>>(json);
                    }
                }
            }

            return null;
        }
    }
}
