using System;
using System.Net.Http.Json;
using System.Text.Json;
using BlazorAPI.Models;

namespace BlazorAPI.Service;

//Klass för att hantera allt som rör nummerupplysningen
public class NumberService
{
    //Field för en körande instans av HttpClient
    public HttpClient _httpClient;

    // Behövs om vi ska nyttja IConfiguration mer än i konstruktorn.
    // public IConfiguration _configuration;'

    //Field för ett NumberModel-objekt
    public NumberModel _numberModel;
    //Field för vår api-key
    private readonly string _api;

    //Property för en lista av favoriter
    public List<NumberModel> ListOfFavourites { get; set; } = new List<NumberModel>();

    // Tidigare lösning innan IConfiguration

    // public ApiKeyHandler _api;

    // public NumberService(HttpClient http, ApiKeyHandler apiKey)
    // {
    //   _httpClient = http;
    //   _api = apiKey.GetKey();
    // }

    //Konstruktor tar emot en instans av HttpClient, och en Iconfiguration. Registreras som global tjänst i program.cs
    public NumberService(HttpClient http, IConfiguration configuration)
    {
        //Tillsätter dem till våra fields
        _httpClient = http;
        _api = configuration["NumberApiKey"];
    }

    //Funktion som hanterar vår lista av favorit-nummer
    public void ManageFavourites(NumberModel numberModel)
    {

        if (numberModel.IsFavourite && !ListOfFavourites.Contains(numberModel))
        {
            ListOfFavourites.Add(numberModel);
        }
        else if (!numberModel.IsFavourite && ListOfFavourites.Contains(numberModel))
        {
            ListOfFavourites.Remove(numberModel);
        }
    }

    //Funktion som anropar publika API:n och hämtar information om objektet
    public async Task<NumberModel?> GetNumber(string number)
    {
        //URL och format får vi från dokumentation
        string url = $"https://apilayer.net/api/validate?access_key={_api}&number={number}";
        try
        {
            var response = await _httpClient.GetFromJsonAsync<NumberModel>(url);
            return response;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ett oväntat fel inträffade: {ex.Message}");
        }
        return null;
    }
}
