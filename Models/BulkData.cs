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
            legalities = new Legalities();
        }

        public Legalities legalities { get; set; }
        public string? setname { get; set; }
        public string? power { get; set; }
        public string? toughness { get; set; }
        public string? rarity { get; set; }
        public string? mana_cost { get; set; }
        public string[] colors { get; set; }
        public string[] color_identity { get; set; }
        public string[] keywords { get; set; }
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

    public class Legalities
    {
        public string? standard { get; set; }
        public string? future { get; set; }
        public string? historic { get; set; }
        public string? gladiator { get; set; }
        public string? pioneer { get; set; }
        public string? explorer { get; set; }
        public string? modern { get; set; }
        public string? legacy { get; set; }
        public string? pauper { get; set; }
        public string? vintage { get; set; }
        public string? penny { get; set; }
        public string? commander { get; set; }
        public string? oathbreaker { get; set; }
        public string? brawl { get; set; }
        public string? historicbrawl { get; set; }
        public string? alchemy { get; set; }
        public string? paupercommander { get; set; }
        public string? duel { get; set; }
        public string? oldschool { get; set; }
        public string? premodern { get; set; }
        public string? predh { get; set; }

    }
}
