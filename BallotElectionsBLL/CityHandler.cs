using BallotElectionsDAL.DTOS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BallotElectionsBLL
{
    public class CityHandler
    {
        public async Task<List<City>> GetList(string search)
        {
            string uri = "https://data.gov.il/api/3/action/datastore_search?resource_id=d4901968-dad3-4845-a9b0-a57d027f11ab&limit=15&q="+search;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                string jsonString = reader.ReadToEnd();

                List<City> result = Newtonsoft.Json.JsonConvert.DeserializeObject<List<City>>(jsonString);

                return result;
            }
        }
    }
}
