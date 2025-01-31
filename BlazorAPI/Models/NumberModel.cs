using System;
using System.Text.Json.Serialization;

namespace BlazorAPI.Models;

//Model f�r numberservice, f�s via dokumentation
public class NumberModel
{
    //Jsonpropertyname m�jligg�r att namns�tta properties (som ska ha stora bokst�ver) som kommer ifr�n JSON responsen
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

    //Tillagd f�r hantering av favorit, kommer ej mappas av JSON respons
    public bool IsFavourite { get; set; }

}


