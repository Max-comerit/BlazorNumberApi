using System;

namespace BlazorAPI.Service;

//Det här är en microservice som skötte kommunikationen med vår appsettings.json
//Används inte.
//Vi använder IConfiguration istället i den klassen som behöver nyckeln.
public class ApiKeyHandler
{
  private readonly string _apiKey;

  public ApiKeyHandler(string apiKey){
    _apiKey = apiKey;
  }

  public string GetKey() {
    return _apiKey;
  }
}
