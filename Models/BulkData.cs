using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGParser.Models
{
    public class BulkData
    {
        public List<Card> Cards { get; set; }
        public BulkData()
        {
            Cards = new List<Card>();
        }
    }

    public class Card
    {
        public string? name { get; set; }
        public string? type_line { get; set; }
        public string? oracle_text { get; set; }
        public Price prices { get; set; }
        public RelatedURIS? related_uris { get; set; }
        public Card()
        {
            prices = new Price();
            related_uris = new RelatedURIS();
        }
    }

    public class Price
    {
        public string? usd { get; set; }
        public string? usd_foil { get; set; }
        public string? usd_etched { get; set; }
        public string? eur { get; set; }
        public string? eur_foil { get; set; }
        public string? tix { get; set; }
    }
    public class RelatedURIS
    {
        public string gatherer { get; set; }
    }
}
