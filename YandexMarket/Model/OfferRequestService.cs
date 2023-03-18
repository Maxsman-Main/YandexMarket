using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace YandexMarket.Model
{
    public class OfferRequestService
    {
        public async Task<List<Offer>> GetOffersAsync(string url)
        {
            try
            {
                using var client = new HttpClient();
                var response = await client.GetAsync(url);
                var xmlContent = await response.Content.ReadAsStringAsync();

                var serializer = new XmlSerializer(typeof(Catalog));
                using var reader = new StringReader(xmlContent);
                var catalog = (Catalog)serializer.Deserialize(reader);

                return catalog.Shop.Offers.OfferList;
            }
            catch(Exception exception)
            {
                throw exception;
            }
        }
    }
}