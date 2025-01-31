using System;
using System.Text.Json.Serialization;

namespace BlazorAPI.Models;

//Model för numberservice, fås via dokumentation
public class NumberModel
{
    //Jsonpropertyname möjliggör att namnsätta properties (som ska ha stora bokstäver) som kommer ifrån JSON responsen
    [JsonPropertyName("valid")]
    public bool Valid { get; set; }

    [JsonPropertyName("number")]
    public string Number { get; set; }

    [JsonPropertyName("local_format")]
    public string Local_Format { get; set; }

    [JsonPropertyName("international_format")]
    public string International_Format { get; set; }

    [JsonPropertyName("country_name")]
    public string Country_Name { get; set; }

    //Tillagd för hantering av favorit, kommer ej mappas av JSON respons
    public bool IsFavourite { get; set; }

}


