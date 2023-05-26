// See https://aka.ms/new-console-template for more information
using MTGParser.Models;
using System.Text;
using System.Text.Json;

Console.WriteLine("Download the bulk data json file from https://scryfall.com/docs/api/bulk-data");
Console.WriteLine("Place file in the same directory as this executable file.");
Console.WriteLine("Press a key to continue");
var re = Console.Read();


var files = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.json");
foreach (var file in files)
{
    if(file.Contains("MTGParser."))
    {
        continue;
    }

    if(Path.GetExtension(file) != ".json")
    {
        continue;
    }
    var data = System.IO.File.ReadAllText(file);
    Console.WriteLine($"Processing file: {file}");

    var bulkData = JsonSerializer.Deserialize<List<Card>>(data);


    using (StreamWriter output = new StreamWriter(Directory.GetCurrentDirectory() + "/output.csv"))
    {
        output.WriteLine($"Name, URL, USD, USD_FOIL, USD_ETCHED, EUR, EUR_FOIL, TIX");

        foreach (var bdata in bulkData)
        {
            output.WriteLine($"{bdata.name}, { bdata.related_uris.gatherer }, {bdata.prices.usd}, {bdata.prices.usd_foil}, {bdata.prices.usd_etched}, {bdata.prices.eur}, {bdata.prices.eur_foil}, {bdata.prices.tix}");
        }
    }

    Console.WriteLine("Finished processing: File \"output.csv\" was created in the same directory as this executable.");
    Console.ReadLine();
}