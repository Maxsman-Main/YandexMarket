using System.Collections.Generic;
using System.Xml.Serialization;

namespace YandexMarket.Model
{
    [XmlRoot("yml_catalog")]
    public struct Catalog
    {
        [XmlElement("shop")]
        public Shop Shop { get; set; }
    }

    public struct Shop
    {
        [XmlElement("offers")]
        public Offers Offers { get; set; }
    }

    public struct Offers
    {
        [XmlElement("offer")]
        public List<Offer> OfferList { get; set; }
    }

    public struct Offer
    {
        [XmlAttribute("id")]
        public string Id { get; set; }

        [XmlAttribute("type")]
        public string Type { get; set; }

        [XmlAttribute("bid")]
        public string Bid { get; set; }

        [XmlAttribute("available")]
        public string Available { get; set; }

    }
}