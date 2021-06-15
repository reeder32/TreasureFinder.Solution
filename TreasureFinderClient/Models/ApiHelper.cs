using System.Threading.Tasks;
using RestSharp;
using System.Collections.Generic;
using System;

namespace TreasureFinder.Models
{
  class ApiHelper
  {
    public static async Task<string> GetAll(string title, string description, string address, string startdate, string enddate, string condition, bool images)
    {
      RestClient client = new RestClient("http://localhost:4000/api");
      RestRequest request = new RestRequest($"items", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }


    public static async Task<string> GetWithId(int id)
    {
      RestClient client = new("http://localhost:4000/api");
      RestRequest request = new($"items/{id}", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    public static async Task<string> Post(string newItem)
    {
      RestClient client = new ("http://localhost:4000/api");
      RestRequest request = new($"items", Method.POST);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newItem);
      var response = await client.ExecuteTaskAsync(request);

      return response.Content;
    }

    public static async Task Delete(int id)
    {
      RestClient client = new ("http://localhost:4000/api");
      RestRequest request = new($"items/{id}", Method.DELETE);
      request.AddHeader("Content-Type", "application/json");
      var _=await client.ExecuteTaskAsync(request);
    }
  }
}