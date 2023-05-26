// See https://aka.ms/new-console-template for more information
using MTGParser.Models;
using System.Text;
using System.Text.Json;

try
{
    Console.WriteLine("Download the bulk data json file from https://scryfall.com/docs/api/bulk-data");
    Console.WriteLine("Place file in the same directory as this executable file.");


    var files = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.json");
    foreach (var file in files)
    {
        if (file.Contains("MTGParser."))
        {
            continue;
        }

        if (Path.GetExtension(file) != ".json")
        {
            continue;
        }
        var data = System.IO.File.ReadAllText(file).Replace("set_name", "setname");
        Console.WriteLine($"Processing file: {file}");

        var bulkData = JsonSerializer.Deserialize<List<Card>>(data);


        using (StreamWriter output = new StreamWriter(Directory.GetCurrentDirectory() + "/output.csv"))
        {
            string legalityLabels = "LEGAL_standard, LEGAL_future, LEGAL_historic, LEGAL_gladiator, LEGAL_pioneer, LEGAL_explorer, LEGAL_modern, LEGAL_legacy, LEGAL_pauper, LEGAL_vintage, LEGAL_penny, LEGAL_commander, LEGAL_oathbreaker, LEGAL_brawl, LEGAL_historicbrawl, LEGAL_alchemy, LEGAL_paupercommander, LEGAL_duel, LEGAL_oldschool, LEGAL_premodern, LEGAL_predh".ToUpper();
            output.WriteLine($"Name, Set, COLORS, COLOR_IDENTITY, MANA_COST, RARITY, TYPE, TEXT, KEYWORDS, POWER, TOUGHNESS, URL, USD, USD_FOIL, USD_ETCHED, EUR, EUR_FOIL, TIX, {legalityLabels}");

            foreach (var bdata in bulkData)
            {
                string colors = string.Empty;
                foreach (string color in bdata.colors)
                {
                    colors = colors + color + " ";
                }

                string coloridentity = string.Empty;
                foreach (string color in bdata.color_identity)
                {
                    coloridentity = coloridentity + color + " ";
                }

                string keywords = string.Empty;
                foreach (string key in bdata.keywords)
                {
                    keywords = keywords + key + " | ";
                }


                if (bdata.color_identity.Count() > 0)
                {
                    coloridentity = coloridentity.Substring(0, coloridentity.Length - 1);
                }
                if (bdata.colors.Count() > 0)
                {
                    colors = colors.Substring(0, colors.Length - 1);
                }
                if (bdata.keywords.Count() > 0)
                {
                    keywords = keywords.Substring(0, keywords.Length - 3);
                }

                string L = $"{bdata.legalities.standard}, {bdata.legalities.future}, {bdata.legalities.historic}, {bdata.legalities.gladiator}, {bdata.legalities.pioneer}, {bdata.legalities.explorer}, {bdata.legalities.modern}, {bdata.legalities.legacy}, {bdata.legalities.pauper}, {bdata.legalities.vintage}, {bdata.legalities.penny}, {bdata.legalities.commander}, {bdata.legalities.oathbreaker}, {bdata.legalities.brawl}, {bdata.legalities.historicbrawl}, {bdata.legalities.alchemy}, {bdata.legalities.paupercommander}, {bdata.legalities.duel}, {bdata.legalities.oldschool}, {bdata.legalities.premodern}, {bdata.legalities.predh}";

                output.WriteLine($"{bdata.name}, {bdata.setname}, {colors}, {coloridentity}, {bdata.mana_cost}, {bdata.rarity}, {bdata.type_line.Replace(",", " ")}, {bdata.oracle_text.Replace(","," ")}, {keywords}, {bdata.power}, {bdata.toughness}, { bdata.related_uris.gatherer }, {bdata.prices.usd}, {bdata.prices.usd_foil}, {bdata.prices.usd_etched}, {bdata.prices.eur}, {bdata.prices.eur_foil}, {bdata.prices.tix}, {L}");
            }
        }

        Console.WriteLine("Finished processing: File \"output.csv\" was created in the same directory as this executable.");
        Console.WriteLine("Press the enter key to exit");
        Console.ReadLine();
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
    Console.ReadLine();
}